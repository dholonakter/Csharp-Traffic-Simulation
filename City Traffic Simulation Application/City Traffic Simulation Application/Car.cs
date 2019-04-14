using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace City_Traffic_Simulation_Application
{
   public class Car : Entity
    {
        //will be inheriting from Entity
        public Car(Point p, Waypoint w,int width, int height) : base(p,w)
        {
            this.maxSpeed = 0.1;
            this.Speed = 0;
            this.Accel = 0.0001;
            xoffset = width/2;
            yoffset = height/2;
            CalculateDirection(x, y, nextWayPoint);
        }

        public Car(Point p, Waypoint w, int width, int height, int direction) : base(p, w)
        {
            this.maxSpeed = 0.1;
            this.Speed = 0;
            this.Accel = 0.0001;
            xoffset = width / 2;
            yoffset = height / 2;
            CalculateDirection(x, y, nextWayPoint);
            path = direction;
        }


    }
}
