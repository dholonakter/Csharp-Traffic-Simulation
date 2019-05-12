﻿using System;
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

        public Traffic_simulaator()
        {
            InitializeComponent();
            runningSimulation = false;
            panel1.AllowDrop = true;
            grid = new Grid();
        }


        private void determineCell(DragEventArgs e)
        {
            Point cursor = PointToClient(Cursor.Position);
            int column = ((cursor.X - panel1.Left) / 300) + 1;
            int row = (cursor.Y - panel1.Top) / 300;
            selectedCell = row * 4 + column;
            
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Panel destination = (Panel)sender;
            destination.Size = new Size(300, 300);
            destination.BackgroundImage = (Bitmap)e.Data.GetData(typeof(Bitmap));

            
            
            //Point cursor = PointToClient(Cursor.Position);
            //Point drawPoint = new Point();

            //Finding out which cell the crossing is dropped on
            //determineCell(e);
            //drawPoint = grid.Cells[selectedCell - 1].Location;
            
            
        }

        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            Point cursor = PointToClient(Cursor.Position);
            int column = ((cursor.X - panel1.Left) / 300) + 1;
            int row = (cursor.Y - panel1.Top) / 300;
            selectedCell = row * 4 + column;
            mouseDown = grid.Cells[selectedCell - 1].Location;
            firstSelection = selectedCell;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //panel1.AllowDrop = true;
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

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;// to set some default effect  when it is drag and drop
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
          
           pbcrossing1.DoDragDrop(pbcrossing1.Image, DragDropEffects.Copy);
        }

        private void pbcrossing1_DoubleClick(object sender, EventArgs e)
        {
           // pbcrossing1.DoDragDrop(pbcrossing1.Image, DragDropEffects.Copy);
        }

        private void pbcrossing1_MouseClick(object sender, MouseEventArgs e)
        {
            pbcrossing1.DoDragDrop(pbcrossing1.Image, DragDropEffects.Copy);
        }

        private void Traffic_simulaator_Load(object sender, EventArgs e)
        {

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) &&
            (e.AllowedEffect & DragDropEffects.Copy) != 0)
            {
                // Allow this.
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Don't allow any other drop.
                e.Effect = DragDropEffects.None;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Panel source = (Panel)sender;
            DoDragDrop(source.BackgroundImage,
                       DragDropEffects.Copy);
        }
    }
}