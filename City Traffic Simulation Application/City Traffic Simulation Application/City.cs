using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace City_Traffic_Simulation_Application
{
    public class City
    {
        //a collection of crossings connected by roads
        public string Cityname;
        public Crossing[] allCrossings; //doesn't need direct access to cars, all cars are either on crossings or roads
        public Road[] allRoads;


        public Point[] Frame(Point[] p) //this function will update everything
        {
            //virtual positions of entities
            foreach (Crossing c in allCrossings)
            {
                c.MoveCars();
            }

            foreach(Road r in allRoads)
            {
                r.MoveCars();
            }
            //virtual states of traffic lights

            // 
            return p;
        }
    }
}
