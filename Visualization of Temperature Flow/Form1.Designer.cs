﻿namespace Visualization_of_Temperature_Flow
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.panelControl = new System.Windows.Forms.GroupBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sideTxt = new System.Windows.Forms.TextBox();
            this.windowRadioBtn = new System.Windows.Forms.RadioButton();
            this.normalCellRadioBtn = new System.Windows.Forms.RadioButton();
            this.coldSourceRadioBtn = new System.Windows.Forms.RadioButton();
            this.heatSourceRadioBtn = new System.Windows.Forms.RadioButton();
            this.blockRadioBtn = new System.Windows.Forms.RadioButton();
            this.startBtn = new System.Windows.Forms.Button();
            this.parallelModeCheckBox = new System.Windows.Forms.CheckBox();
            this.colorMappingPanel1 = new Color_Mapping.ColorMappingPanel();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSize = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(6, 6);
            this.simpleOpenGlControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(800, 602);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
            this.simpleOpenGlControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseDown);
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.updateBtn);
            this.panelControl.Controls.Add(this.label1);
            this.panelControl.Controls.Add(this.sideTxt);
            this.panelControl.Controls.Add(this.windowRadioBtn);
            this.panelControl.Controls.Add(this.normalCellRadioBtn);
            this.panelControl.Controls.Add(this.coldSourceRadioBtn);
            this.panelControl.Controls.Add(this.heatSourceRadioBtn);
            this.panelControl.Controls.Add(this.blockRadioBtn);
            this.panelControl.Location = new System.Drawing.Point(823, 11);
            this.panelControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControl.Name = "panelControl";
            this.panelControl.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControl.Size = new System.Drawing.Size(223, 137);
            this.panelControl.TabIndex = 1;
            this.panelControl.TabStop = false;
            this.panelControl.Text = "Panel Control";
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(147, 54);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(64, 26);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Side:";
            // 
            // sideTxt
            // 
            this.sideTxt.Location = new System.Drawing.Point(169, 33);
            this.sideTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sideTxt.Name = "sideTxt";
            this.sideTxt.Size = new System.Drawing.Size(39, 20);
            this.sideTxt.TabIndex = 5;
            // 
            // windowRadioBtn
            // 
            this.windowRadioBtn.AutoSize = true;
            this.windowRadioBtn.Location = new System.Drawing.Point(4, 111);
            this.windowRadioBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.windowRadioBtn.Name = "windowRadioBtn";
            this.windowRadioBtn.Size = new System.Drawing.Size(63, 17);
            this.windowRadioBtn.TabIndex = 4;
            this.windowRadioBtn.TabStop = true;
            this.windowRadioBtn.Text = "Window";
            this.windowRadioBtn.UseVisualStyleBackColor = true;
            this.windowRadioBtn.CheckedChanged += new System.EventHandler(this.windowRadioBtn_CheckedChanged);
            // 
            // normalCellRadioBtn
            // 
            this.normalCellRadioBtn.AutoSize = true;
            this.normalCellRadioBtn.Location = new System.Drawing.Point(4, 92);
            this.normalCellRadioBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.normalCellRadioBtn.Name = "normalCellRadioBtn";
            this.normalCellRadioBtn.Size = new System.Drawing.Size(78, 17);
            this.normalCellRadioBtn.TabIndex = 3;
            this.normalCellRadioBtn.TabStop = true;
            this.normalCellRadioBtn.Text = "Normal Cell";
            this.normalCellRadioBtn.UseVisualStyleBackColor = true;
            this.normalCellRadioBtn.CheckedChanged += new System.EventHandler(this.normalCellRadioBtn_CheckedChanged);
            // 
            // coldSourceRadioBtn
            // 
            this.coldSourceRadioBtn.AutoSize = true;
            this.coldSourceRadioBtn.Location = new System.Drawing.Point(4, 73);
            this.coldSourceRadioBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.coldSourceRadioBtn.Name = "coldSourceRadioBtn";
            this.coldSourceRadioBtn.Size = new System.Drawing.Size(82, 17);
            this.coldSourceRadioBtn.TabIndex = 2;
            this.coldSourceRadioBtn.TabStop = true;
            this.coldSourceRadioBtn.Text = "Cold Source";
            this.coldSourceRadioBtn.UseVisualStyleBackColor = true;
            this.coldSourceRadioBtn.CheckedChanged += new System.EventHandler(this.coldSourceRadioBtn_CheckedChanged);
            // 
            // heatSourceRadioBtn
            // 
            this.heatSourceRadioBtn.AutoSize = true;
            this.heatSourceRadioBtn.Location = new System.Drawing.Point(4, 54);
            this.heatSourceRadioBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.heatSourceRadioBtn.Name = "heatSourceRadioBtn";
            this.heatSourceRadioBtn.Size = new System.Drawing.Size(84, 17);
            this.heatSourceRadioBtn.TabIndex = 1;
            this.heatSourceRadioBtn.TabStop = true;
            this.heatSourceRadioBtn.Text = "Heat Source";
            this.heatSourceRadioBtn.UseVisualStyleBackColor = true;
            this.heatSourceRadioBtn.CheckedChanged += new System.EventHandler(this.heatSourceRadioBtn_CheckedChanged);
            // 
            // blockRadioBtn
            // 
            this.blockRadioBtn.AutoSize = true;
            this.blockRadioBtn.Location = new System.Drawing.Point(4, 34);
            this.blockRadioBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.blockRadioBtn.Name = "blockRadioBtn";
            this.blockRadioBtn.Size = new System.Drawing.Size(49, 17);
            this.blockRadioBtn.TabIndex = 0;
            this.blockRadioBtn.TabStop = true;
            this.blockRadioBtn.Text = "Block";
            this.blockRadioBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.blockRadioBtn.UseVisualStyleBackColor = true;
            this.blockRadioBtn.CheckedChanged += new System.EventHandler(this.blockRadioBtn_CheckedChanged);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(970, 152);
            this.startBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(64, 26);
            this.startBtn.TabIndex = 6;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // parallelModeCheckBox
            // 
            this.parallelModeCheckBox.AutoSize = true;
            this.parallelModeCheckBox.Location = new System.Drawing.Point(827, 190);
            this.parallelModeCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.parallelModeCheckBox.Name = "parallelModeCheckBox";
            this.parallelModeCheckBox.Size = new System.Drawing.Size(135, 17);
            this.parallelModeCheckBox.TabIndex = 11;
            this.parallelModeCheckBox.Text = "Use Parallel Processing";
            this.parallelModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // colorMappingPanel1
            // 
            this.colorMappingPanel1.Location = new System.Drawing.Point(827, 231);
            this.colorMappingPanel1.Name = "colorMappingPanel1";
            this.colorMappingPanel1.Size = new System.Drawing.Size(234, 138);
            this.colorMappingPanel1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1107, 673);
            this.Controls.Add(this.colorMappingPanel1);
            this.Controls.Add(this.parallelModeCheckBox);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.GroupBox panelControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sideTxt;
        private System.Windows.Forms.RadioButton windowRadioBtn;
        private System.Windows.Forms.RadioButton normalCellRadioBtn;
        private System.Windows.Forms.RadioButton coldSourceRadioBtn;
        private System.Windows.Forms.RadioButton heatSourceRadioBtn;
        private System.Windows.Forms.RadioButton blockRadioBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.CheckBox parallelModeCheckBox;
        private Color_Mapping.ColorMappingPanel colorMappingPanel1;
    }
}

