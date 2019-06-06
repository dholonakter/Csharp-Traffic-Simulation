using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace City_Traffic_Simulation_Application
{
    public partial class Traffic_simulaator : Form
    {


        Entity entity;
        int TrafficSwitch = 10000;
        int CarDelay = 1000;
        Random r = new Random();

        Crossing[,] crossings =  new Crossing [2,2];
        public Traffic_simulaator()
        {
            InitializeComponent();
            pb3.AllowDrop = true;
            pb2.AllowDrop = true;
            p1.AllowDrop = true;
            pb4.AllowDrop = true;
            // car speed
            
            
            timer2.Interval = 10;
            //todo synch with framerate?
            entity = new Entity();

           
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

                Crossing c = new Crossing(Box.CreateGraphics(),Box, (int)Math.Round((double)Box.Location.X / 500), (int)Math.Round((double)Box.Location.Y / 300),ref crossings);
                c.CreatePoints(Box.Width, Box.Height);
                crossings[(int)Math.Round((double)Box.Location.X / 500), (int)Math.Round((double)Box.Location.Y / 300)]=c;
                
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
            TrafficSwitch -= timer2.Interval;
            CarDelay -= timer2.Interval;

            foreach (Crossing c in crossings)
            {

                if (c != null)
                {
                    c.MoveCars();
                    c.Draw(false);//flip this bool to draw all waypoints instead of just traffic lights
                    if (TrafficSwitch < 0)
                        c.nextPattern();
                }
            }

            if (TrafficSwitch < 0)
                TrafficSwitch = 10000;

            if (CarDelay < 0)
            {
                CarDelay = (int)numericUpDown1.Value;
                Crossing c = crossings[r.Next(2), r.Next(2)];
                if (c!=null)
                    c.AddCar();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //todo restart functionality
            //timer2.Enabled = false;

            Crossing[,] newCrossings = new Crossing[2, 2];
            foreach (Crossing c in crossings)
            {

                if(c != null)
                {

                    newCrossings[c.x, c.y] = new Crossing(c.gr, c.box, c.x, c.y, ref newCrossings);
                    newCrossings[c.x, c.y].CreatePoints(c.box.Width, c.box.Height);
                }
            }
            crossings = newCrossings;
            tableLayoutPanel1.Refresh();
            timer2.Stop();
        }

        // the saved method 
        public void Save(string filename)
        {
            SerializeData serialised = new SerializeData();
            serialised.SerialiseObjects(filename, entity);
            //Entity newentty = (Entity)serialiser.DeSerialiseObjects();
        }
       
        public void Saveas()
        {
            SaveFileDialog saveas = new SaveFileDialog();
            saveas.FileName = "simulation data";
          //  saveas.Filter = "Simulation file|*.sim";
            if (saveas.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(" Data saved sucessfully!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        public void loadFile(string filename)
        {
            SerializeData serilise = new SerializeData();
            this.entity = (Entity)serilise.DeSerialiseObjects(filename);

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "My simulaiton";
            openFile.Filter = "Simulation file|*.sim";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("open");
               // panel1.Controls.Clear();
                loadFile(openFile.FileName);
            }
        }


        // loading file from an a chosen directory 
        private void button4_Click(object sender, EventArgs e)
        {
            this.loadFile("ferdi);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
    
}