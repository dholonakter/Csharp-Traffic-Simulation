using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Traffic_Simulation_Application
{
  public  class Entity
    {
        private Waypoint nextWayPoint { get; set; }

        public static int lastEntityId { get; set; } = 0;

        public int id { get; set; }
        public double maxSpeed { get; set; }
        public double Speed { get; set; }
        public double Accel { get; set; }
        public double Decel { get; set; }
        public Road road { get; set; } //Road object the car is on. these may be moved to the car specific class if we don't let pedestrians have roads
        public double roadProgress { get; set; } //determines how far a car is along a road

        private double distanceTillWaypoint;


        public Entity ()
        {
            lastEntityId++;
            this.id = lastEntityId;
        }
        public Entity(Waypoint w)
        {
            lastEntityId++;
            this.id = lastEntityId;
            this.nextWayPoint = w;
        }
        public Entity(Road r)
        {
            lastEntityId++;
            this.id = lastEntityId;
            this.road = r;
        }

        public double[] CalculateNewWaypoint(double x, double y, Waypoint w)
        {
            

            double deltaX = w.x - x;
            double deltaY = w.y - y;

            double deltaH = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            distanceTillWaypoint = Math.Sqrt(deltaH);

            double ratioX = deltaX / deltaH;
            double ratioY = deltaY / deltaH;

            double[] result = new double[2] {ratioX, ratioY };
            return result; 
        }

        public double[] Move(double x, double y, double ratioX, double ratioY)
        {
            if (Speed <= maxSpeed)
            {
                Speed += Accel * Clock.dt;
            }
            else if ( Speed - maxSpeed > Speed *0.1f )
            {
                Speed -= Decel * Clock.dt;
            }
            double frameSpeedH = Clock.dt * Speed; //Hypotenuse of similar triangle
            x += ratioX * frameSpeedH;
            y += ratioY * frameSpeedH;
            distanceTillWaypoint -= frameSpeedH;
            if (distanceTillWaypoint <= 0)
            {
                CalculateNewWaypoint(x, y, nextWayPoint.nextWaypoint);
            }
            double[] result = new double[2] { x, y };
            return result;
        }

        public void MoveRoad()
        {

        }
    }
}
