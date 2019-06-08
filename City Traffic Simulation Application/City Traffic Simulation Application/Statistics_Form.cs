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
    public partial class Statistics_Form : Form
    {
        public Statistics_Form()
        {
            InitializeComponent();
        }

        public void SetTotalCars(int crossingNumber, int numberOfCars)
        {   
            switch (crossingNumber)
            {
                case 1:
                    lblTotalCarsInCrossing1.Text = numberOfCars.ToString();
                    break;
                case 2:
                    lblTotalCarsInCrossing2.Text = numberOfCars.ToString();
                    break;
                case 3:
                    lblTotalCarsInCrossing3.Text = numberOfCars.ToString();
                    break;
                case 4:
                    lblTotalCarsInCrossing4.Text = numberOfCars.ToString();
                    break;
            }
        }

        public void SetTotalWaitingCars(int crossingNumber, int waitingCarsNumber)
        {
            switch (crossingNumber)
            {
                case 1:
                    lblTotalCarsInCrossing1.Text = waitingCarsNumber.ToString();
                    break;
                case 2:
                    lblTotalCarsInCrossing2.Text = waitingCarsNumber.ToString();
                    break;
                case 3:
                    lblTotalCarsInCrossing3.Text = waitingCarsNumber.ToString();
                    break;
                case 4:
                    lblTotalCarsInCrossing4.Text = waitingCarsNumber.ToString();
                    break;
            }
        }
    }
}
