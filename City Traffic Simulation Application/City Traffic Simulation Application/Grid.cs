﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace City_Traffic_Simulation_Application
{
    [Serializable]
    class Grid
    {
        private List<Cell> cells;

        [NonSerialized]
        private Timer car_timer;
        private long time;
        private int junctionDefinition;

        public Grid()
        {
            this.cells = new List<Cell>();
            //this.crossings = new List<Crossing>();
            this.junctionDefinition = 40;
            //this.InitializeCarTimer();
            this.AddCells();
        }

        public List<Cell> Cells
        {
            get
            {
                return cells;
            }
        }

        //public int Junction
        //{
        //    get { return junctionDefinition; }
        //    set { junctionDefinition = value; }
        //}

        //public void InitializeCarTimer()
        //{
        //    car_timer = new Timer();
        //    car_timer.Interval = 40;
        //    car_timer.Tick += car_timer_Tick;
        //}

        public void AddCells()
        {
            int rows = 3;
            int columns = 4;

            int cellWidth = 300;
            int cellHeight = 300;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.Cells.Add(new Cell(new Point(0 + j * cellWidth, 0 + i * cellHeight)));
                }
            }
        }
    }
}
