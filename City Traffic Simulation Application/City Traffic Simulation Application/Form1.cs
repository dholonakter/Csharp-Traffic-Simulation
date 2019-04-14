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
        City city = new City();
        List<PictureBox> Boxes;
        int i =0;
        Point initialpoint;
        public Form1()
        {
            
            InitializeComponent();
            initialpoint = pictureBox1.Location;
            TestPointsCar();
        }



        private void TestPointsCar()
        {

            Waypoint w2 = new Waypoint(waypoint2.Location,new Waypoint((double)this.Width/2, (double)this.Height) );
            Waypoint w1 = new Waypoint(waypoint1.Location, w2); // this makes some test waypoints
            Waypoint w3 = new Waypoint(waypoint3.Location, new Waypoint((double)this.Width+100, (double)this.Height/2));
            w1.waypointLeft = w3;


            Crossing crossing = new Crossing();
            crossing.crossingID = 1;
            
            
            Car car = new Car(pictureBox1.Location, w1, pictureBox1.Width, pictureBox1.Height, i);
            
            crossing.cars.Add(car);
            city.allCrossings.Add(crossing);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            List<object> carData = city.Frame(1); //puts out a list of points for how to move picture boxes
            /*
            foreach(PictureBox i in Boxes)
            {
                // change the location of the boxes       // code is supposed to run for all pictureboxes
                Point x = i.Location;
                
                foreach (object o in carData)
                {
                    int[] array = (int[])o;
                    
                    if ("Car"+array[2].ToString()  == i.Name)
                    {
                        i.Location = new Point(array[0], array[1]);
                    }
                }
                //x.Offset(1, 0); todo consider whether to use offset instead?
            }
            */
            foreach (object o in carData) //temporary testing code for a single picturebox
            {
                int[] array = (int[])o;

                
                    pictureBox1.Location = new Point(array[0], array[1]);
                
            }

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = initialpoint;
            if (i == 0)
                i = 2;
            else
                i = 0;
            city = new City();
            TestPointsCar();
            timer1.Stop();
            
        }
    }
}
