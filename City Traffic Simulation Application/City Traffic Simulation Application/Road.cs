using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Traffic_Simulation_Application
{
    class Road
    {
        Crossing pointA;
        Crossing pointB;

        public Crossing PointA  {
            get { return pointA ; }
            set
            {
                if (value == pointB) { throw new Exception("Road endpoint is equal to starting point."); } 
                else { pointA = value; }
            }
        }

        public Crossing PointB
        {
            get { return pointB; }
            set
            {
                if (value == pointA) { throw new Exception("Road endpoint is equal to starting point."); }
                else { pointB = value; }
            }
        }

        public float length { get; set; }
        public float speedlimit { get; set; }

    }
}
