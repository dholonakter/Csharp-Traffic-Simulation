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
    public partial class Traffic_simulaator : Form
    {


        Point loc = new Point(300, 50);
        //creating the draw area 
        List<Car> carListNorth;
        List<Car> carListEast;
        List<Car> carListSouth;
        List<Car> carListWest;
        List<Car> traffics;
        Graphics drawarea;
        Graphics drawarea2;
        Graphics drawarea3;

        public int delay = 999;

        Crossing[] crossings =  new Crossing [4];
        public Traffic_simulaator()
        {
            InitializeComponent();
            pb3.AllowDrop = true;
            pb2.AllowDrop = true;
            p1.AllowDrop = true;
            pb4.AllowDrop = true;
            // car speed
            
            
            // instanciating the draw area 
            carListNorth = new List<Car>();
            carListEast = new List<Car>();
            carListSouth = new List<Car>();
            carListWest = new List<Car>();
            traffics = new List<Car>();
            //North
            carListNorth.Add(new Car(new Point(225, 25), 15, 15));
            carListNorth.Add(new Car(new Point(225, 50), 15, 15));
           
            carListNorth.Add(new Car(new Point(225, 5), 15, 15));
            //East
            carListEast.Add(new Car(new Point(0, 140), 8, 8));
            carListEast.Add(new Car(new Point(25, 140), 8, 8));
            //South
            carListSouth.Add(new Car(new Point(265, 230), 15, 15));
            //West
            carListWest.Add(new Car(new Point(450, 115), 15, 15));
            traffics.Add(new Car(new Point(0, 140), 15, 15));
            //carList.Add(new Car(new Point(300, 50), 15, 15));
            drawarea = p1.CreateGraphics(); // to create the cars on the picture box with the crossing
            drawarea2 = pb2.CreateGraphics();
            drawarea3 = p1.CreateGraphics();

            
            timer2.Interval = 10;
            //todo synch with framerate?

            crossings[0] = new Crossing();
            crossings[0].CreatePoints(pb3.Width,pb3.Height);
            crossings[0].TestCar();
            foreach (Car c in crossings[0].cars)
            {
                Array values = Enum.GetValues(typeof(TrafficLight.Directions));
                Random random = new Random();
                System.Threading.Thread.Sleep(50);
                TrafficLight.Directions randomDirection = (TrafficLight.Directions)values.GetValue(random.Next(values.Length));
                c.path = (int)randomDirection;
            }
            
        }

 
        public void drawtraffic()
        {
            Pen p = new Pen(Color.Red);
            drawarea3.DrawRectangle(p,280,110,10,10);
            SolidBrush s = new SolidBrush(Color.Red);
            drawarea3.FillEllipse(s,280,110,10,10);
           // drawarea3.Dispose();
        }

        public void drawtrafficgreen()
        {
            Pen p = new Pen(Color.Green);
            drawarea3.DrawRectangle(p, 280, 150, 10, 10);
            SolidBrush s = new SolidBrush(Color.Green);
            drawarea3.FillEllipse(s, 280, 150, 10, 10);
            // drawarea3.Dispose();
        }




        private void pbcrossing1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //dragTypeOne = true;
                pbcrossing1.DoDragDrop(pbcrossing1.Image, DragDropEffects.Copy);
            }
        }

        private void pbcrossing2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //dragTypeOne = true;
                pbcrossing2.DoDragDrop(pbcrossing2.Image, DragDropEffects.Copy);
            }
        }

        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;// to set some default effect  when it is drag and drop
        }


        private void pbcrossing1_MouseClick(object sender, MouseEventArgs e)
        {
            pbcrossing1.DoDragDrop(pbcrossing1.Image, DragDropEffects.Copy);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }


        private void pb1_Click(object sender, EventArgs e)
        {

        }


        private void pb1_DragDrop(object sender, DragEventArgs e)
        {
            if (sender.GetType() == typeof(PictureBox))
            {

                PictureBox Box = sender as PictureBox;

                Box.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            }

        }

        private void pb1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void p1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            pb2.Refresh();
            crossings[0].MoveCars();
            foreach (Car c2 in crossings[0].cars)
            {
                c2.Draw(ref drawarea2);
            }
            foreach (Waypoint w in crossings[0].points)
            {
                w.Draw(ref drawarea2);
            }


            delay -= timer2.Interval;
            if (delay <= 0)
            {
                crossings[0].TestCar();
                

                

                delay = 973;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
           //todo restart functionality
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawtraffic();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Waypoint w in crossings[0].redlights)
                w.RedLight = !w.RedLight;
        }
    }
    
}