using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace City_Traffic_Simulation_Application
{
    
  public   class Crossing
    {
        // a meeting point of roads. has a map. has traffic lights. has entities. 
        private Waypoint North;
        private Waypoint South;
        private Waypoint East;     //may be changed to an array of connected roads instead
        private Waypoint West;
        public List<Car> cars;
        private Point location;
        [NonSerialized]
        Graphics gr;
        public int crossingID;
        static int lastCrossing = 0;
        Timer t;



        public Crossing()
        {
            crossingID = ++lastCrossing;
            cars = new List<Car>();
        }

        public Crossing(Point l)
        {
            this.location = l;
            //gr = 
        }

        public List<object> MoveCars()
        {
            List<object> carCoordinates= new List<object> { };
            foreach (Car c in cars)
            {
              carCoordinates.Add(c.Move());
                if (c.leaving != null)
                {
                    cars.Remove(c);
                    //todo get the proper crossing and add C to their list of cars
                }
            }
            return carCoordinates;
        }

        public void nextPattern()
        {
            //should get a pattern and change whether cars are driving or not according to it.
            //todo actually implement this method, this is just a hardcoded test method currently.

            foreach (Car car in cars)
            {
                car.driving = !car.driving;
            }

        }

        public void StartTime()
        {
            t.Start();
        }

        public void CreatePoints(int width, int height)
        {
            List<Waypoint> L= new List<Waypoint> { }; 
            Waypoint w4 =new Waypoint(width * 300 / 300, height * 166 / 300);//E Calling constructors for points according to the size of the panel
            w4.End = "East";
            Waypoint w3 = new Waypoint(width * 180 / 300, height * 166 / 300, w4);
            Waypoint w2 = new Waypoint(width * 126 / 300, height * 166 / 300, w3);
            Waypoint w1 = new Waypoint(width * 0 / 300, height * 166 / 300, w2);
            Waypoint w9 = new Waypoint(width * 164 / 300, height * 0 / 300);//N
            w9.End = "North";
            Waypoint w8 = new Waypoint(width * 164 / 300, height * 100 / 300, w9);
            Waypoint w7 = new Waypoint(width * 160 / 300, height * 139 / 300, w8);
            Waypoint w6 = new Waypoint(width * 126 / 300, height * 152 / 300, w7);
            Waypoint w5 = new Waypoint(width * 44 / 300, height * 152 / 300, w6);
            w1.waypointLeft = w5; //making pathing adjustments
            Waypoint w11 = new Waypoint(width * 140 / 300, height * 300 / 300);//S
            w11.End = "South";
            Waypoint w10 = new Waypoint(width * 140 / 300, height * 176 / 300, w11);
            w2.waypointRight = w10;
            Waypoint w13 = new Waypoint(width * 164 / 300, height * 172 / 300, w8);
            Waypoint w12 = new Waypoint(width * 164 / 300, height * 300 / 300, w13);
            Waypoint w16 = new Waypoint(width * 0 / 300, height * 136 / 300);//W
            w16.End = "West";
            Waypoint w15 = new Waypoint(width * 126 / 300, height * 136 / 300, w16);
            Waypoint w14 = new Waypoint(width * 150 / 300, height * 150 / 300, w15);
            w13.waypointLeft = w14;
            w13.waypointRight = w3;

            Waypoint w4c = new Waypoint(width *(1- 300 / 300), height * (1 - 166 / 300)); //creating the complement of the first set
            w4c.End = "West";
            Waypoint w3c = new Waypoint(width * (1 - 180 / 300), height * (1 - 166 / 300), w4c);
            Waypoint w2c = new Waypoint(width * (1 - 126 / 300), height * (1 - 166 / 300), w3c);
            Waypoint w1c = new Waypoint(width * (1 - 0 / 300), height * (1 - 166 / 300), w2c);
            Waypoint w9c = new Waypoint(width * (1 - 164 / 300), height * (1 - 0 / 300));
            w9c.End = "South";
            Waypoint w8c = new Waypoint(width * (1 - 164 / 300), height * (1 - 100 / 300), w9c);
            Waypoint w7c = new Waypoint(width * (1 - 160 / 300), height * (1 - 139 / 300), w8c);
            Waypoint w6c = new Waypoint(width * (1 - 126 / 300), height * (1 - 152 / 300), w7c);
            Waypoint w5c = new Waypoint(width * (1 - 44 / 300), height * (1 - 152 / 300), w6c);
            w1c.waypointLeft = w5c;
            Waypoint w11c = new Waypoint(width * (1 - 140 / 300), height * (1 - 300 / 300));
            w11c = North;
            Waypoint w10c = new Waypoint(width * (1 - 140 / 300), height * (1 - 176 / 300), w11c);
            w2c.waypointRight = w10c;
            Waypoint w13c = new Waypoint(width * (1 - 164 / 300), height * (1 - 172 / 300), w8c);
            Waypoint w12c = new Waypoint(width * (1 - 164 / 300), height * (1 - 300 / 300), w13c);
            Waypoint w16c = new Waypoint(width * (1 - 0 / 300), height * (1 - 136 / 300));
            w16c.End = "East";
            Waypoint w15c = new Waypoint(width * (1 - 126 / 300), height * (1 - 136 / 300), w16c);
            Waypoint w14c = new Waypoint(width * (1 - 150 / 300), height * (1 - 150 / 300), w15c);
            w13c.waypointLeft = w14c;
            w13c.waypointRight = w3c;

            West = w1;
            East = w1c;
            South = w12;
            North = w12c;
            
            //todo unsure if at the end of the function all these waypoints are deleted. If they are, use a list like L to pass back the points.
        }
    }
}
