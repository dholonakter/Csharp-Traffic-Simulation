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
        private Road North;
        private Road South;
        private Road East;     //may be changed to an array of connected roads instead
        private Road West;
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

        public void PlaceCarsOnCrossingPb()
        {
            //lane.PlaceCars(gr);
        }
    }
}
