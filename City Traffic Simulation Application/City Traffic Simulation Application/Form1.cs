using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace City_Traffic_Simulation_Application
{
    public partial class Form1 : Form
    {
        Clock clock = new Clock();
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void TestPointsCar()
        {
            Waypoint N = new Waypoint(200, 100); // this makes some test waypoints
            Waypoint E = new Waypoint(300, 200, N);
            Waypoint S = new Waypoint(200, 300, E);
            Waypoint W = new Waypoint(100, 200, S);
            N.nextWaypoint = W;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x= pictureBox1.Left;
            pictureBox1.Left = x + 1;
        }
    }
}
