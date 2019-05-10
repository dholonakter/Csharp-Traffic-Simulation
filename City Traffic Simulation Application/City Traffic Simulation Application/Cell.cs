using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace City_Traffic_Simulation_Application
{
    [Serializable]
    class Cell
    {
        private Point location;
        private bool taken;
        
        public Cell(Point location)
        {
            this.location = location;
            this.taken = false;
        }

        public Point Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public bool Taken
        {
            get { return this.taken; }
            set { this.taken = value; }
        }
    }
}
