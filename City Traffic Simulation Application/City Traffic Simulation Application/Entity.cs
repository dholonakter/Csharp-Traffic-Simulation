using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace City_Traffic_Simulation_Application
{
    [Serializable]// M
    public class Entity
    {
        public Waypoint nextWayPoint { get; set; }

        public static int lastEntityId { get; set; } = 0;

        public int id { get; set; }
        public double maxSpeed { get; set; }
        public double Speed { get; set; }
        public double Accel { get; set; }
        public double Decel { get; set; }
        public Road road { get; set; } //Road object the car is on. these may be moved to the car specific class if we don't let pedestrians have roads
        public double roadProgress { get; set; } //determines how far a car is along a road
        public int path { get; set; }

        public int xoffset { get; set; }
        public int yoffset { get; set; }

        public bool driving { get; set; } = true;
        private bool waiting { get; set; } = false;

        public string leaving { get; set; } = null;

        Waypoint.GreenLightHandler GreenHandler;

        private double distanceTillWaypoint;

        public double x;
        public double y;
        double ratioX;
        double ratioY;

        public Entity()
        {
            this.id = ++lastEntityId;
        }
        public Entity( double x, double y, Waypoint w)
        {
            this.id = ++lastEntityId;
            this.nextWayPoint = w;
            this.x = x;
            this.y = y;
            CalculateDirection(x, y, w);
        }
        public Entity(Road r)
        {
            this.id = ++lastEntityId;
            this.road = r;
        }


        public Entity (Point p, Waypoint w)
        {
            this.id = ++lastEntityId;
            this.nextWayPoint = w;
            this.x = p.X;
            this.y = p.Y;
            CalculateDirection(x, y, w);
        }


        public int[] Move() //method for onscreen entities
        {
            if (nextWayPoint == null)
            {
                return new int[3] { (int)x, (int)y, id };  // do nothing if there is nowhere to go
            }
            else if (!driving)
            {
                return new int[3] { (int)x, (int)y, id }; 
            }

            if (distanceTillWaypoint <= 0)
            {
                if (waiting)
                {
                    driving = false;
                    return new int[3] { (int)x, (int)y, id };// if we're waiting and past our waiting point, do nothing.
                }
            }

                ChangeSpeed();

            /* . A
             * |\
             * | \  <-frameSpeedH
             * |__\
             * | x \ 
             * |    \
             * |     \  <-straight line through waypoint B
             * |______\. B
             *    x' 
             *   x/framespeedH == x'/AB == ratioX -> similar triangles
             */
            if(driving)
            {
                double frameSpeedH = Clock.dt * Speed; //Hypotenuse of similar triangle
                x += ratioX * frameSpeedH;
                y += ratioY * frameSpeedH;

                distanceTillWaypoint -= frameSpeedH;
            }
            


            //code to find a new waypoint when the car passes the old one
            if (distanceTillWaypoint <= 0)
            {
               

                if (this.nextWayPoint.nextWaypoint==null)
                {
                    leaving = this.nextWayPoint.End;
                }

                Waypoint w = this.nextWayPoint.nextWaypoint;
                if (w.RedLight==true) //IF THE NEXT WAYPOINT IS A TRAFFICLIGHT AND IT IS RED
                {
                    
                    w = new Waypoint(w.x-ratioX*w.waitingcars*(3+xoffset*2), w.y-ratioY*w.waitingcars*(3 + yoffset * 2), w);
                    w.waitingcars++;
                    waiting = true;
                    GreenHandler = new Waypoint.GreenLightHandler(stopwaiting);
                    w.turngreen += GreenHandler;
                    //todo subscribe to an event from w where redlight turns false;
                }
                
                
                if (path == (int)TrafficLight.Directions.L)
                {
                    w = nextWayPoint.waypointLeft;
                }
                else if (path == (int)TrafficLight.Directions.R)
                {
                    w = nextWayPoint.waypointRight;
                }
                CalculateDirection(x, y, w);
                this.nextWayPoint=w;
            }


            int xRound = Convert.ToInt32(x);
            int yRound = Convert.ToInt32(y);
            int[] result = new int[3]{xRound, yRound, id};
            return result ; //returns the updated Point value for the entity
        }

        public virtual void CalculateDirection(double x, double y, Waypoint w) //method that calculates the direction to go in
        {
            

            double deltaX = w.x - x -xoffset;
            double deltaY = w.y - y -yoffset;

            double deltaH = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            distanceTillWaypoint = deltaH;

            ratioX = deltaX / deltaH;
            ratioY = deltaY / deltaH;

            //double[] result = new double[2] {ratioX, ratioY };
            //return result; 
        }

        
        public void MoveRoad()
        {
            //todo implement. Increases roadProgress according to road.maxspeed and road.lenght . 
            //When over 100%, put a reference to the car in the Crossing object it enters, give it a location and route to follow
            //remove reference to the car from the road

        }

        private void ChangeSpeed()
        {
            if (Speed <= maxSpeed)
            {
                Speed += Accel * Clock.dt;
            }
            else if (Speed - maxSpeed > Speed * 0.1f)
            {
                Speed -= Decel * Clock.dt;
            }
        }


        private void stopwaiting(Waypoint w, EventArgs e)
        {
            driving = true;
            waiting = false;
            w.turngreen -= GreenHandler;
        }
    }
}
