﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Visualization_of_Temperature_Flow
{
   public class Mesh
    {
       
       Cell[,] grid;
       public int cellsize;
       int rows , cols;
       public Mesh(int width,int height,int cellsize)
       {
           this.cellsize = cellsize;
           rows = (height/cellsize)+1;
           cols = (width/cellsize)+1;
           grid = new Cell[rows,cols];
           for (int i = 0; i < rows; i++)
               for (int j = 0; j < cols; j++)
                   grid[i, j] = new Cell(new Point(j * cellsize, i * cellsize),Color.Green,CellType.NormalCell);
       }
       public void Update()
       { }
       public void Draw()
       {
           for (int i = 0; i < rows; i++)
               for (int j = 0; j < cols; j++)
                   grid[i, j].Draw(cellsize);
       }

       public CellType targetType;
       public void ChangeCell(int row , int col)
       {
           switch (targetType)
           { 
               case CellType.Block:
                   grid[row, col] = new Cell(new Point(col * cellsize, row * cellsize), Color.Black, CellType.Block);
                   break;

               case CellType.ColdSource:
                   grid[row, col] = new Cell(new Point(col * cellsize, row * cellsize), Color.Blue, CellType.ColdSource);      
                   break;

               case CellType.HeatSource:
                   grid[row, col] = new Cell(new Point(col * cellsize, row * cellsize), Color.Red, CellType.HeatSource);
                   break;

               case CellType.NormalCell:
                   grid[row, col] = new Cell(new Point(col * cellsize, row * cellsize), Color.Green, CellType.NormalCell);
                   break;

               case CellType.Window:
                   grid[row, col] = new Cell(new Point(col * cellsize, row * cellsize), Color.Yellow, CellType.Window);
                   break;
           }
       }
    }
}