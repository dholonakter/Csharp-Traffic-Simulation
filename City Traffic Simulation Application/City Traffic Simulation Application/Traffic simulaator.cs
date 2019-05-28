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
        Grid grid;
        Point mouseDown;
        bool dragTypeOne;
        int selectedCell = 0;
        int firstSelection = 0;
        bool runningSimulation;

        Point loc = new Point(300, 50);
        //creating the draw area 
        Car car;
        List<Car> carListNorth;
        List<Car> carListEast;
        List<Car> carListSouth;
        List<Car> carListWest;
        List<Car> traffics;
        Graphics drawarea;
        Graphics drawarea2;
        Graphics drawarea3;

        Crossing[] crossings =  new Crossing [4];
        public Traffic_simulaator()
        {
            InitializeComponent();
            runningSimulation = false;
            pb3.AllowDrop = true;
            pb2.AllowDrop = true;
            p1.AllowDrop = true;
            pb4.AllowDrop = true;
            // car speed
            
            
            grid = new Grid();
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
            timer1.Interval = 10;
            timer2.Interval = 10;


            crossings[0] = new Crossing();
            crossings[0].CreatePoints(pb3.Width,pb3.Height);
            crossings[0].TestCar();
            Array values = Enum.GetValues(typeof(TrafficLight.Directions));
            Random random = new Random();
            TrafficLight.Directions randomDirection = (TrafficLight.Directions)values.GetValue(random.Next(values.Length));
            crossings[0].cars[0].path = (int)randomDirection;
        }

        private void CarWaypoints()
        {
            Waypoint w1 = new Waypoint(0, 140);
            Waypoint w2 = new Waypoint(200, 140);
            Waypoint w3 = new Waypoint(280, 140);
            Waypoint w4 = new Waypoint(450, 140);
        }

        private void determineCell(DragEventArgs e)
        {
            //Point cursor = PointToClient(Cursor.Position);
            //int column = ((cursor.X - panel1.Left) / 300) + 1;
            //int row = (cursor.Y - panel1.Top) / 300;
            //selectedCell = row * 4 + column;

        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            // Allows the drag and drop
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            //List<Panel> listP = new List<Panel>();
            // Takes the image from where you selected, the one to be dropped and showed in panel
            Panel destination = (Panel)sender;
            destination.Size = new Size(250, 250);
            destination.BackgroundImage = (Bitmap)e.Data.GetData(typeof(Bitmap));


            Point cursor = PointToClient(Cursor.Position);
            Point drawPoint = new Point();

            //Finding out which cell the crossing is dropped on
            determineCell(e);
            drawPoint = grid.Cells[selectedCell - 1].Location;
            //if (e.AllowedEffect == DragDropEffects.Move)
            //{
            //    foreach (Panel p in listP)
            //    {
            //        if(p.Location == mouseDown && !grid.Cells[selectedCell - 1].Taken)
            //        {
            //            p.Location = drawPoint;
            //            destination.Location = drawPoint;

            //            grid.Cells[selectedCell - 1].Taken = true;

            //        }
            //    }
            //}



        }
        // for creating the traffic light
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

        public void drawtrafficgreen2()
        {
            Pen p = new Pen(Color.Green);
            drawarea3.DrawRectangle(p, 200, 150, 10, 10);
            SolidBrush s = new SolidBrush(Color.Green);
            drawarea3.FillEllipse(s, 200, 150, 10, 10);
            // drawarea3.Dispose();
        }

        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            //Point cursor = PointToClient(Cursor.Position);
            //int column = ((cursor.X - panel1.Left) / 300) + 1;
            //int row = (cursor.Y - panel1.Top) / 300;
            //selectedCell = row * 4 + column;
            //mouseDown = grid.Cells[selectedCell - 1].Location;
            //firstSelection = selectedCell;
        }

        private void pbcrossing1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragTypeOne = true;
                pbcrossing1.DoDragDrop(pbcrossing1.Image, DragDropEffects.Copy);
            }
        }

        private void pbcrossing2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragTypeOne = true;
                pbcrossing2.DoDragDrop(pbcrossing2.Image, DragDropEffects.Copy);
            }
        }

        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;// to set some default effect  when it is drag and drop
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            pbcrossing1.DoDragDrop(pbcrossing1.Image, DragDropEffects.Copy);
        }

        private void pbcrossing1_MouseClick(object sender, MouseEventArgs e)
        {
            pbcrossing1.DoDragDrop(pbcrossing1.Image, DragDropEffects.Copy);
        }

        //private void panel1_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.Bitmap) &&
        //    (e.AllowedEffect & DragDropEffects.Copy) != 0)
        //    {
        //        // Allow this.
        //        e.Effect = DragDropEffects.Copy;
        //    }
        //    else
        //    {
        //        // Don't allow any other drop.
        //        e.Effect = DragDropEffects.None;
        //    }
        //}

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //Displays the image on panel when mouse click is released
            Panel source = (Panel)sender;
            DoDragDrop(source.BackgroundImage,
                       DragDropEffects.Copy);
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            Panel destination = (Panel)sender;
            destination.Size = new Size(250, 250);
            destination.BackgroundImage = (Bitmap)e.Data.GetData(typeof(Bitmap));
        }

        //private void panel2_DragEnter(object sender, DragEventArgs e)
        //{
        //    //if (e.Data.GetDataPresent(DataFormats.Bitmap) &&
        //    //(e.AllowedEffect & DragDropEffects.Copy) != 0)
        //    //{
        //    //    // Allow this.
        //    //    e.Effect = DragDropEffects.Copy;
        //    //}
        //    //else
        //    //{
        //    //    // Don't allow any other drop.
        //    //    e.Effect = DragDropEffects.None;
        //    //}
        //}

        private void panel2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Panel source = (Panel)sender;
            DoDragDrop(source.BackgroundImage,
                       DragDropEffects.Copy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Start();
            timer2.Start();
            // Pen p = new Pen(Color.Yellow);
            // car.Drawtrafic(Graphics(250,200,20,20));
           


        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            p1.Refresh();
            this.drawtraffic();
            this.drawtrafficgreen();
            this.drawtrafficgreen();

            //pb2.Refresh();
            foreach (Car c in carListNorth)
            {
                c.Location = new Point(c.Location.X, c.Location.Y + 1);
                c.Draw(ref drawarea);
            }

            foreach (Car c in carListEast)
            {
                c.Location = new Point(c.Location.X + 1, c.Location.Y);
                c.Draw(ref drawarea);
                ////c.Draw(ref drawarea2);
                //if (c.Location == new Point(450, 140))
                //{
                //    pb2.Refresh();
                //    foreach (Car c2 in carListEast)
                //    {
                //        c2.Location = new Point(c2.Location.X + 1, c2.Location.Y);
                //        c2.Draw(ref drawarea2);
                //    }
                //}
            }

            foreach (Car c in carListSouth)
            {
                c.Location = new Point(c.Location.X, c.Location.Y - 1);
                c.Draw(ref drawarea);
            }

            foreach (Car c in carListWest)
            {
                c.Location = new Point(c.Location.X - 1, c.Location.Y);
                c.Draw(ref drawarea);
            }
        }


        private void pb4_DragDrop(object sender, DragEventArgs e)
        {
            pb3.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }


        private void pb4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pb1_Click(object sender, EventArgs e)
        {

        }


        private void pb1_DragDrop(object sender, DragEventArgs e)
        {
            pb1.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pb1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pb2_DragDrop(object sender, DragEventArgs e)
        {
            pb2.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void pb2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pb4_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pb4_DragDrop_1(object sender, DragEventArgs e)
        {
            pb4.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }



        private void p1_DragDrop(object sender, DragEventArgs e)
        {
            p1.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void p1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void p1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pb2.Refresh();
            crossings[0].MoveCars();
            foreach (Car c2 in crossings[0].cars)
            {
                c2.Draw(ref drawarea2);
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
            drawtraffic();
        }
    }
    
}