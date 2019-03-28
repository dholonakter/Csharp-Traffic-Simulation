using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Traffic_Simulation_Application
{
    class Waypoint
    {
        //waypoints are a coordinate on the map. when the final waypoint is reached the entity will be sent to a Road.
        public Waypoint nextWaypoint;

        public double x;
        public double y;

    }
}
