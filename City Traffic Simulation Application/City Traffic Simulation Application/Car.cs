using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Traffic_Simulation_Application
{
   public class Car : Entity
    {
        //will be inheriting from Entity
        public Car(Waypoint w, double x, double y) : base(w, x, y)
        {
            this.maxSpeed = 20;
            this.Speed = 0.1;
        }
    }
}
