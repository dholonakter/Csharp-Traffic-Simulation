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
        //creating the draw area 

        Graphics drawarea;

        
        public Traffic_simulaator()
        {
            InitializeComponent();
            runningSimulation = false;
            panel1.AllowDrop = true;
            panel2.AllowDrop = true;
            grid = new Grid();
            // instanciating the draw area 
            drawarea = panel2.CreateGraphics(); // to create the cars on the picture box with the crossing
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
            //List<Panel> listP = new List<Panel>();
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

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            Panel destination = (Panel)sender;
            destination.Size = new Size(250, 250);
            destination.BackgroundImage = (Bitmap)e.Data.GetData(typeof(Bitmap));
        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        List<Graphics> cars;
        private void button1_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Yellow);
           
            
                drawarea.DrawRectangle(p, 300, 50, 15, 15);
                SolidBrush b1 = new SolidBrush(Color.RoyalBlue);
                drawarea.FillRectangle(b1, 300, 50, 15, 15);

            //second car
                drawarea.DrawRectangle(p, 250, 50, 15, 15);
                SolidBrush b = new SolidBrush(Color.Yellow);
                drawarea.FillRectangle(b, 250, 50, 15, 15);
            // the third car 
            drawarea.DrawRectangle(p, 100, 270, 15, 15);
            SolidBrush b2 = new SolidBrush(Color.Red);
            drawarea.FillRectangle(b2, 100, 270, 15, 15);

            // the fourth car
            // the third car 
            drawarea.DrawRectangle(p, 100, 333, 15, 15);
            SolidBrush b3 = new SolidBrush(Color.Purple);
            drawarea.FillRectangle(b3, 100, 333, 15, 15);


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int numOfCells = 6;
            int cellSize = 200;
            Pen p = new Pen(Color.Black);

            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
                
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
            
        }
    }
}
