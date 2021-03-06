﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Tao.OpenGl;
using Color_Mapping;
using System.IO;
using System.Threading;
namespace Visualization_of_Temperature_Flow
{
    public partial class Form1 : Form
    {
        int height, width;
        BackgroundWorker _worker = null;
        Mesh mesh;
        Mode mode;

        public Form1()
        {
            InitializeComponent();
            InitializeValues();
            FileLoader.LoadFiles();
        }

        void InitializeValues()
        {
            height = simpleOpenGlControl1.Height;
            width = simpleOpenGlControl1.Width;
            simpleOpenGlControl1.InitializeContexts();
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0, width, height, 0);

            mode = Mode.Serial;
            mesh = new Mesh(width, height, 20);
            mesh.targetType = CellType.Block;
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClearColor(0, 0, 0, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            mesh.Draw();
        }

        private void blockRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (blockRadioBtn.Checked)
                mesh.targetType = CellType.Block;
        }

        private void heatSourceRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (heatSourceRadioBtn.Checked)
                mesh.targetType = CellType.HeatSource;
        }

        private void coldSourceRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (coldSourceRadioBtn.Checked)
                mesh.targetType = CellType.ColdSource;
        }

        private void normalCellRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (normalCellRadioBtn.Checked)
                mesh.targetType = CellType.NormalCell;
        }

        private void windowRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (windowRadioBtn.Checked)
                mesh.targetType = CellType.Window;
        }

        private bool CheckConsistency()
        {
            if (parallelCppModeRadioBtn.Checked == true && n_threadsTxtBox.Text.Length == 0) return false;
            return true;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (CheckConsistency() == false)
            {
                MessageBox.Show("Please Enter Number of Threads.");
                return;
            }

            UpdateStartButton();
            StartWorker();
        }

        private void StartWorker()
        {
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;

            _worker.DoWork += new DoWorkEventHandler((state, args) =>
            {
                do
                {
                    if (_worker.CancellationPending || startBtn.Text == "Start")
                        break;

                    mesh.Update(mode);
                    simpleOpenGlControl1.Invalidate();
                } while (true);
            });
            _worker.RunWorkerAsync();
        }

        private void UpdateStartButton()
        {
            if (startBtn.Text == "Start") startBtn.Text = "Stop";
            else startBtn.Text = "Start";
        }

        CellType Priortype(CellType prev, CellType cur)
        {
            if (cur > prev) return cur;
            else return prev;
        }


        Mesh CopySmallToLarge(Mesh small, int division, int size)
        {

            Mesh big = new Mesh(width, height, size);
            for (int i = 0; i < big.rows; i++)
            {
                for (int j = 0; j < big.cols; j++)
                {
                    float temp = 0;
                    int Rend = i * division + division;
                    bool notAVG = false;
                    CellType prev = CellType.NormalCell, curr = CellType.NormalCell;
                    for (int R = i * division; R < Rend; R++)
                    {
                        int Cend = j * division + division;
                        for (int C = j * division; C < Cend; C++)
                        {
                            if (small.grid[R][C].type != CellType.NormalCell)
                            {
                                notAVG = true;
                            }
                            curr = small.grid[R][C].type;
                            curr = Priortype(prev, curr);
                            prev = curr;
                            temp += small.grid[R][C].temperature;
                        }
                    }
                    if (notAVG)
                    {
                        big.grid[i][j] = new Cell(big.grid[i][j].position, curr);
                    }
                    else
                    {
                        temp /= (division * division);
                        big.grid[i][j].temperature = temp;
                    }
                }
            }
            return big;
        }
        Mesh CopyLargToSmall(Mesh big, int division, int size)
        {
            Mesh small = new Mesh(width, height, size);
            for (int i = 0; i < big.rows; i++)
                for (int j = 0; j < big.cols; j++)
                {
                    int Rend = i * division + division;
                    for (int R = i * division; R < Rend; R++)
                    {
                        int Cend = j * division + division;
                        for (int C = j * division; C < Cend; C++)
                        {
                            small.grid[R][C].type = big.grid[i][j].type;
                            small.grid[R][C].temperature = big.grid[i][j].temperature;
                        }
                    }
                }
            return small;
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {

            int size = 0;
            bool isNumeric = int.TryParse(sideTxt.Text, out size);
            if (!isNumeric)
            {
                MessageBox.Show("Value is not Numeric.");
                return;
            }
            int prevsize = mesh.cellsize;

            if (prevsize < size)
            {
                if (size % prevsize != 0)
                {
                    MessageBox.Show("Size is Not divisible");
                    return;
                }
                int division = size / prevsize;
                CellType tmp = mesh.targetType;
                mesh = CopySmallToLarge(mesh, division, size);
                mesh.targetType = tmp;
            }
            else
            {
                if (prevsize % size != 0)
                {
                    MessageBox.Show("Size is Not divisible");
                    return;
                }
                int division = prevsize / size;
                CellType tmp = mesh.targetType;
                mesh = CopyLargToSmall(mesh, division, size);
                mesh.targetType = tmp;
            }

            UpdateStartButton();

            if (startBtn.Text == "Stop") startBtn.Text = "Start";

            // CellType tmp = mesh.targetType;
            // mesh = new Mesh(width, height, size);
            // mesh.targetType = tmp;
            simpleOpenGlControl1.Refresh();


        }

        private void simpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                int row = y / mesh.cellsize, col = x / mesh.cellsize;
                row = Math.Max(0, Math.Min(mesh.rows - 1, row));
                col = Math.Max(0, Math.Min(mesh.cols - 1, col));
                mesh.ChangeCell(row, col);
                simpleOpenGlControl1.Refresh();
            }
        }

        private void parallelCppModeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (parallelCppModeRadioBtn.Checked == true)
            {
                threadsLabel.Visible = n_threadsTxtBox.Visible = true;
                mode = Mode.ParallelOmp;
            }
        }

        private void serialModeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (serialModeRadioBtn.Checked == true)
            {
                threadsLabel.Visible = n_threadsTxtBox.Visible = false;
                mode = Mode.Serial;
            }
        }

        private void parallelCSRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (parallelCSRadioBtn.Checked == true)
            {
                threadsLabel.Visible = n_threadsTxtBox.Visible = false;
                mode = Mode.Parallel;
            }
        }

        private void n_threadsTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (n_threadsTxtBox.Text.Length == 0)
                return;
            TemperatureFlow.num_threads = int.Parse(n_threadsTxtBox.Text);
        }

        private void UpdateMinMax_Click(object sender, EventArgs e)
        {
            if (_worker != null && _worker.IsBusy)
            {
                _worker.CancelAsync();
            }
            mesh.UpdateCurrentMesh();
            if (startBtn.Text == "Stop")
            {
                StartWorker();
            }
        }

        private void simpleOpenGlControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int x = e.X, y = e.Y;
                int row = y / mesh.cellsize, col = x / mesh.cellsize;
                row = Math.Max(0, Math.Min(mesh.rows - 1, row));
                col = Math.Max(0, Math.Min(mesh.cols - 1, col));
                string msg = "Type : " + mesh.grid[row][col].type.ToString();
                cellInfoTP.AppendText(msg);
                cellInfoTP.AppendText(Environment.NewLine);
                msg = "Value : " + mesh.grid[row][col].temperature.ToString();
                cellInfoTP.AppendText(msg);
                cellInfoTP.AppendText(Environment.NewLine);
                msg = "Mouse Position : ";
                cellInfoTP.AppendText(msg);
                cellInfoTP.AppendText(Environment.NewLine);
                msg = " X =  " + x.ToString() + ",  Y =  " + y.ToString();
                cellInfoTP.AppendText(msg);

                cellInfoTP.Refresh();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                List<string> map = new List<string>();
                StreamReader sr = new StreamReader(fileName);
                string line;
                line = sr.ReadLine();
                while (line != null)
                {
                    map.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                string rowline;
                CellType tmp;
                for (int i = 0; i < mesh.rows; i++)
                {
                    rowline = map[i];
                    for (int j = 0; j < mesh.cols; j++)
                    {
                        int n = int.Parse(rowline[j].ToString());
                        tmp = (CellType)n;
                        mesh.grid[i][j] = new Cell(mesh.grid[i][j].position, tmp);
                    }
                }

                simpleOpenGlControl1.Invalidate();
            }
        }
        int count = 0;
        private void SaveButton_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text File | *.txt";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile());

                //Write a line of text
                for (int i = 0; i < mesh.rows; i++)
                {
                    string rowline = "";
                    for (int j = 0; j < mesh.cols; j++)
                    {
                        rowline += ((int)mesh.grid[i][j].type).ToString();
                    }
                    sw.WriteLine(rowline);
                }
                //Close the file
                sw.Close();
            }
        }

        private void Rest_Click(object sender, EventArgs e)
        {
            UpdateStartButton();

            if (startBtn.Text == "Stop") startBtn.Text = "Start";

            CellType tmp = mesh.targetType;
            mesh = new Mesh(width, height, mesh.cellsize);
             mesh.targetType = tmp;
            simpleOpenGlControl1.Refresh();
        }
    }
}
//switch (mesh.grid[i][j].type)
//                   { 
//                       case CellType.NormalCell:
//                           rowline += "N";break;

//                       case CellType.Block:
//                           rowline += "B"; break;
//                       case CellType.:
//                           rowline += "N"; break;
//                       case CellType.NormalCell:
//                           rowline += "N"; break;
//                       case CellType.NormalCell:
//                           rowline += "N"; break;
//                   }
