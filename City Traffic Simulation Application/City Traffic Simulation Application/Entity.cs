using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Traffic_Simulation_Application
{
    class Entity
    {
        private Waypoint nextWayPoint { get; set; }

        public int id { get; set; }
        public double maxSpeed { get; set; }
        public double Speed { get; set; }
        public double Acceleration { get; set; }
        public Road road { get; set; } // these may be moved to the car specific class. 
        public double roadProgress { get; set; } //

        private double distanceTillWaypoint;


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
            double frameSpeedH = Math.Sqrt((Clock.dt * Speed) * (Clock.dt * Speed));
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
    }
}
