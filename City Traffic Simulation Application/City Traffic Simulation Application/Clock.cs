using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Traffic_Simulation_Application
{
    class Clock
    {
        //the clock moves entities every frame and switches traffic light patterns from time to time.
        public DateTime StartTime { get; set; }
        public DateTime CurrentTime { get; set; } 
        public static double dt { get; set; } //the time elapsed since last frame

        public void Start ()
        {
            
        }

        public void Stop ()
        {

        }

        public void Reset ()
        {

        }
    }
}
