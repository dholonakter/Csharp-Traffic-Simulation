﻿using System;
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
        public int path { get; set; }

        public float xoffset { get; set; }
        public float yoffset { get; set; }

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
        

        public Entity (Point p, Waypoint w)
        {
            this.id = ++lastEntityId;
            this.nextWayPoint = w;
            this.x = p.X;
            this.y = p.Y;
            CalculateDirection(x, y, w);
        }


        public void Move() //method for onscreen entities
        {
            if (nextWayPoint == null)
            {
                return;// new int[3] { (int)x, (int)y, id };  // do nothing if there is nowhere to go
            }
            else if (!driving)
            {
                return;// new int[3] { (int)x, (int)y, id }; 
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
            
            double frameSpeedH = 10 * Speed; //Hypotenuse of similar triangle
            x += ratioX * frameSpeedH;
            y += ratioY * frameSpeedH;

            if (driving)
            {
                distanceTillWaypoint -= frameSpeedH;
                


                //code to find a new waypoint when the car passes the old one
                if (distanceTillWaypoint <= 0)
                {
                    if (waiting)
                    {
                        driving = false;
                        return;// new int[3] { (int)x, (int)y, id };// if we're waiting and past our waiting point, do nothing.
                    }

                    if (this.nextWayPoint.nextWaypoint == null)
                    {
                        leaving = this.nextWayPoint.End;
                        driving = false;
                        return;
                    }

                    Waypoint w = this.nextWayPoint.nextWaypoint;

                    if (path == (int)TrafficLight.Directions.L)
                    {
                        w = nextWayPoint.waypointLeft;
                    }
                    else if (path == (int)TrafficLight.Directions.R)
                    {
                        w = nextWayPoint.waypointRight;
                    }


                    



                    this.nextWayPoint = w;

                    if (w.RedLight == true) //IF THE NEXT WAYPOINT IS A TRAFFICLIGHT AND IT IS RED
                    {
                        w.waitingcars++;
                        CalculateDirection(x, y, w);
                        

                        waiting = true;
                        GreenHandler = new Waypoint.GreenLightHandler(stopwaiting);
                        w.turngreen += GreenHandler;
                        //todo subscribe to an event from w where redlight turns false;
                        w = new Waypoint(w.x - ratioX * w.waitingcars * (3 + xoffset * 2), w.y - ratioY * w.waitingcars * (3 + yoffset * 2), w);
                        this.nextWayPoint = w;
                    }
                    CalculateDirection(x, y, w);

                }

            }
        }

        public virtual void CalculateDirection(double x, double y, Waypoint w) //method that calculates the direction to go in
        {
            

            double deltaX = w.x - x ;
            double deltaY = w.y - y ;

            double deltaH = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            distanceTillWaypoint = deltaH;
            if (deltaH == 0)
            {
                ratioX = 0;
                ratioY = 0;
                return;
            } 
            ratioX = deltaX / deltaH;
            ratioY = deltaY / deltaH;

            //double[] result = new double[2] {ratioX, ratioY };
            //return result; 
        }


        private void ChangeSpeed()
        {
            if (Speed <= maxSpeed)
            {
                Speed += Accel * 10;
            }
            else if (Speed - maxSpeed > Speed * 0.1f)
            {
                Speed -= Decel * 10;
            }

            if (!driving)
                Speed = 0;
        }

        public void RandomDirection()
        {
            Array values = Enum.GetValues(typeof(TrafficLight.Directions));
            Random random = new Random();
            TrafficLight.Directions randomDirection = (TrafficLight.Directions)values.GetValue(random.Next(values.Length));
            this.path = (int)randomDirection;
        }
        private void stopwaiting(Waypoint w, EventArgs e)
        {
            driving = true;
            waiting = false;
            w.turngreen -= GreenHandler;
        }
    }
}
