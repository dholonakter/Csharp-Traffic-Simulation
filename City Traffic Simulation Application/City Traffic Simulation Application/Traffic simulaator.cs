﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace City_Traffic_Simulation_Application
{
    public partial class Traffic_simulaator : Form
    {


        Entity entity;
        int TrafficSwitch = 10000;
        int CarDelay = 1000;
        Random r = new Random();

        Crossing[,] crossings =  new Crossing [2,2];

        Statistics_Form statistic_Form;
        public Traffic_simulaator()
        {
            InitializeComponent();
            pb3.AllowDrop = true;
            pb2.AllowDrop = true;
            p1.AllowDrop = true;
            pb4.AllowDrop = true;

            panel1.Hide();

            timer2.Interval = 10;
            //TODO maybe make this adjustable? you can make it editable by adding an extra control to the options panel but
            //make sure that if you do that you can no longer edit the value after you press start by deactivating it when you press start;
            //todo synch with framerate?
            entity = new Entity();

           
        }
                          
        private void pbcrossing1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //dragTypeOne = true;
                pbcrossing1.DoDragDrop(pbcrossing1.Image, DragDropEffects.Copy);

                Console.Write("");
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
            TrafficSwitch -= timer2.Interval;  //TODO
            CarDelay -= timer2.Interval;
            // Debug.WriteLine(this.crossings[0, 0].cars.Count, "Cars in the crossing 1");
            if (statistic_Form != null)
            {
                //first crossing
                Crossing first = this.crossings[0, 0];
                Crossing second = this.crossings[0, 1];
                Crossing third = this.crossings[1, 0];
                Crossing fourth = this.crossings[1, 1];
                if (first != null)
                {
                    statistic_Form.SetTotalCars(1, first.cars.Count);

                    int waitingCarsInWest = first.redlights[0].waitingcars + first.redlights[1].waitingcars;
                    int waitingCarsInEast = first.redlights[3].waitingcars + first.redlights[4].waitingcars;
                    int waitingCarsInSouth = first.redlights[2].waitingcars;
                    int waitingCarsInNorth= first.redlights[5].waitingcars; ;
                    int totalWaitingCars = waitingCarsInWest + waitingCarsInEast + waitingCarsInSouth + waitingCarsInNorth;
                    statistic_Form.SetTotalWaitingCars(1, totalWaitingCars);

                    statistic_Form.SetTotalWaitingCarsInEast(1, waitingCarsInEast);
                    statistic_Form.SetTotalWaitingCarsInWest(1, waitingCarsInWest);
                    statistic_Form.SetTotalWaitingCarsInNorth(1, waitingCarsInNorth);
                    statistic_Form.SetTotalWaitingCarsInSouth(1, waitingCarsInSouth);
                }
                if (second != null)
                {
                    statistic_Form.SetTotalCars(2, second.cars.Count);

                    int waitingCarsInWest = second.redlights[0].waitingcars + second.redlights[1].waitingcars;
                    int waitingCarsInEast = second.redlights[3].waitingcars + second.redlights[4].waitingcars;
                    int waitingCarsInSouth = second.redlights[2].waitingcars;
                    int waitingCarsInNorth = second.redlights[5].waitingcars; ;
                    int totalWaitingCars = waitingCarsInWest + waitingCarsInEast + waitingCarsInSouth + waitingCarsInNorth;
                    statistic_Form.SetTotalWaitingCars(2, totalWaitingCars);

                    statistic_Form.SetTotalWaitingCarsInEast(2, waitingCarsInEast);
                    statistic_Form.SetTotalWaitingCarsInWest(2, waitingCarsInWest);
                    statistic_Form.SetTotalWaitingCarsInNorth(2, waitingCarsInNorth);
                    statistic_Form.SetTotalWaitingCarsInSouth(2, waitingCarsInSouth);
                }
                if (third != null)
                {
                    statistic_Form.SetTotalCars(3, third.cars.Count);

                    int waitingCarsInWest = third.redlights[0].waitingcars + third.redlights[1].waitingcars;
                    int waitingCarsInEast = third.redlights[3].waitingcars + third.redlights[4].waitingcars;
                    int waitingCarsInSouth = third.redlights[2].waitingcars;
                    int waitingCarsInNorth = third.redlights[5].waitingcars; ;
                    int totalWaitingCars = waitingCarsInWest + waitingCarsInEast + waitingCarsInSouth + waitingCarsInNorth;
                    statistic_Form.SetTotalWaitingCars(3, totalWaitingCars);

                    statistic_Form.SetTotalWaitingCarsInEast(3, waitingCarsInEast);
                    statistic_Form.SetTotalWaitingCarsInWest(3, waitingCarsInWest);
                    statistic_Form.SetTotalWaitingCarsInNorth(3, waitingCarsInNorth);
                    statistic_Form.SetTotalWaitingCarsInSouth(3, waitingCarsInSouth);
                }
                if (fourth != null)
                {
                    statistic_Form.SetTotalCars(4, fourth.cars.Count);

                    int waitingCarsInWest = fourth.redlights[0].waitingcars + fourth.redlights[1].waitingcars;
                    int waitingCarsInEast = fourth.redlights[3].waitingcars + fourth.redlights[4].waitingcars;
                    int waitingCarsInSouth = fourth.redlights[2].waitingcars;
                    int waitingCarsInNorth = fourth.redlights[5].waitingcars; ;
                    int totalWaitingCars = waitingCarsInWest + waitingCarsInEast + waitingCarsInSouth + waitingCarsInNorth;
                    statistic_Form.SetTotalWaitingCars(4, totalWaitingCars);

                    statistic_Form.SetTotalWaitingCarsInEast(4, waitingCarsInEast);
                    statistic_Form.SetTotalWaitingCarsInWest(4, waitingCarsInWest);
                    statistic_Form.SetTotalWaitingCarsInNorth(4, waitingCarsInNorth);
                    statistic_Form.SetTotalWaitingCarsInSouth(4, waitingCarsInSouth);
                }
            }
            //Debug.WriteLine(this.crossings[0, 0].EastProp.waitingcars, "Waiting Cars in east in the crossing 1");
            foreach (Crossing c in crossings)
            {

                if (c != null)
                {
                    c.MoveCars();
                    c.Draw(false);//flip this bool to draw all waypoints instead of just traffic lights
                    if (TrafficSwitch < 0)
                    {//TODO instead of having the logic for TrafficSwitch here, put it in Crossing.TrafficTick() . 
                     //that way you can just call c.move, c.draw, c.traffictick
                        c.nextPattern();

                    }
                    
                }
            }

            if (TrafficSwitch < 0) //TODO same as above
                TrafficSwitch = 8000;

            if (CarDelay < 0)
            {
                CarDelay = (int)(numericUpDown1.Value*1000);
                Crossing c = crossings[r.Next(2), r.Next(2)];
                if (c!=null)
                    c.AddCar(timer2.Interval);
            }



            //TODO every few seconds you should calculate the average waiting time and update the label where it should be displayed on the panel.
            //this way people can see we're actively calculating the numbers. The simulation will still run if it's not visible.
            //in fact if all the drawn stuff is visible when the options panel is open you can just Hide() the pictureboxes and it should all still work fine.
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
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
            timer2.Start();//As the button says restart, it should start again after stopping all activities.
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
            //TODO click to hide/unhide panel 1
            panel1.Show();
            //i don't know whether hiding or unhiding the panel resets the values of the components, so you may need to store them 
            //by making new properties here. This way if the panel is opened again you can make sure they're still the same.
            //this.loadFile("ferdi");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //also make the average waiting time the latest calculated one.
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panel1.Hide();
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           statistic_Form  = new Statistics_Form();
            
            statistic_Form.Show();
        }

        private void Traffic_simulaator_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    
}