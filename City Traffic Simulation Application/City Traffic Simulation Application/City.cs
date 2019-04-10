using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace City_Traffic_Simulation_Application
{
    class City
    {
        //a collection of crossings connected by roads

        public Crossing[] allCrossings;
        public Car[] allCars;
        public Road[] allRoads;


        public Point[] Frame(Point[] p) //this function will update everything
        {
            //virtual positions of entities
            foreach (Car car in allCars)
            {
                car.Move();
            }
            //virtual states of traffic lights

            // 
            return p;
        }
    }
}
