using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Traffic_Simulation_Application
{
    class Car : Entity
    {
        public int id { get; set; }
        public float maxSpeed { get; set; }
        public float Speed { get; set; }
        public float Acceleration { get; set; }
        public Road road { get; set; } // these may be moved to the car specific class. 
        public float roadProgress { get; set; } //

    }
}
