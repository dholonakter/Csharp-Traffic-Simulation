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
        public Traffic_simulaator()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.AllowDrop = true;
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
    }
}
