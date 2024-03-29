﻿using System;
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
        private Waypoint North;
        private Waypoint South;
        private Waypoint East;     //may be changed to an array of connected roads instead
        private Waypoint West;
        private Waypoint[] points;
        private Waypoint[] redlights;
        public List<Car> cars;
        public PictureBox box;
        [NonSerialized]
        public Graphics gr;
        int i=0;
        public int x;
        public int y;
        Crossing[,] crossings;
        Random r = new Random();

        public Crossing()
        {
            cars = new List<Car>();
        }

        public Crossing(Graphics gr, PictureBox box, int x, int y, ref Crossing[,] crossings)
        {
            cars = new List<Car>();
            this.gr = gr;
            this.box = box;
            this.x = x;
            this.y = y;
            this.crossings = crossings;
            i = r.Next(0, 3);
        }

        public void MoveCars()
        {
            //List<object> carCoordinates= new List<object> { };
            foreach (Car c in cars.ToList())
            {
                c.Move();
              //carCoordinates.Add(c.Move());
                if (c.leaving != null)
                {
                    c.RandomDirection();
                    //todo get the proper crossing and add C to their list of cars
                    try
                    {
                        if (c.leaving == "North")
                        {

                            if (y > 0)
                            {
                                c.leaving = null;
                                c.nextWayPoint = crossings[x, y - 1].South;
                                c.x = c.nextWayPoint.x;
                                c.y = c.nextWayPoint.y;
                                crossings[x, y - 1].cars.Add(c);
                            }
                        }
                        if (c.leaving == "South")
                        {
                            if (y < 1)
                            {
                                c.leaving = null;
                                c.nextWayPoint = crossings[x, y + 1].North;
                                c.x = c.nextWayPoint.x;
                                c.y = c.nextWayPoint.y;
                                crossings[x, y + 1].cars.Add(c);
                            }
                        }
                        if (c.leaving == "East")
                        {
                            if (x < 1)
                            {
                                c.leaving = null;
                                c.nextWayPoint = crossings[x + 1, y].West;
                                c.x = c.nextWayPoint.x;
                                c.y = c.nextWayPoint.y;
                                crossings[x + 1, y].cars.Add(c);
                            }
                        }
                        if (c.leaving == "West")
                        {
                            if (x > 0)
                            {
                                c.leaving = null;
                                c.nextWayPoint = crossings[x - 1, y].East;
                                c.x = c.nextWayPoint.x;
                                c.y = c.nextWayPoint.y;
                                crossings[x - 1, y].cars.Add(c);
                            }
                        }
                    }
                    catch
                    { }
                    cars.Remove(c);

                }
            }
            //return carCoordinates;
        }

        public void nextPattern()
        {
            //should get a pattern and change whether cars are driving or not according to it.
            //todo actually implement this method, this is just a hardcoded test method currently.
            foreach (Waypoint w in redlights)
                w.RedLight = true;
            int[] s = new int[4] { redlights[0].waitingcars + redlights[3].waitingcars, redlights[1].waitingcars+redlights[4].waitingcars, redlights[2].waitingcars, redlights[5].waitingcars };
            int maxValue = s.Max();
            int maxIndex = s.ToList().IndexOf(maxValue);
            if(maxIndex==0)
            {
                redlights[0].RedLight = false;
                redlights[3].RedLight = false;
            }
            else if (maxIndex==1)
            {
                redlights[1].RedLight = false;
                redlights[4].RedLight = false;
            }
            else if (maxIndex==2)
            {
                redlights[2].RedLight = false;
            }
            else if (maxIndex==3)
            {
                redlights[5].RedLight = false;
            }

        }


        public void AddCar()
        {
            Waypoint E1;
            if (x == 0)
                E1 = West;
            else
                E1 = East;
            Waypoint E2;
            if (y == 0)
                E2 = North;
            else
                E2 = South;
            if (r.Next(2) == 0)
                cars.Add(new Car(E1));
            else
                cars.Add(new Car(E2));

        }

        public void TestCar()
        {
            if (i == 0)
                cars.Add(new Car(West));
            else if (i == 1)
                cars.Add(new Car(East));
            else if (i == 2)
                cars.Add(new Car(North));
            else if (i == 3)
                cars.Add(new Car(South));
            i++;
            if (i == 4)
                i = 0;
        }

        public void Draw(bool showwaypoints)
        {
            box.Refresh();
            foreach (Car c2 in this.cars)
            {
                c2.Draw(ref gr);
            }
            if(showwaypoints)
            {
                foreach (Waypoint w in this.points)
                {
                    w.Draw(ref gr);
                }
            }
            else
            {
                foreach (Waypoint w in this.redlights)
                {
                    w.Draw(ref gr);
                }
            }
        }

        public Waypoint[] CreatePoints(float width, float height)
        {
            Waypoint[] L= new Waypoint[32]; 
            Waypoint w4 =new Waypoint(width * 300f / 300f, height * 166f / 300f);//E Calling constructors for points according to the size of the panel
            w4.End = "East";
            Waypoint w3 = new Waypoint(width * 180f / 300f, height * 166f / 300f, w4);
            Waypoint w2 = new Waypoint(width * 126f / 300f, height * 166f / 300f, w3);
            Waypoint w1 = new Waypoint(width * 0f / 300f, height * 166f / 300f, w2);
            Waypoint w9 = new Waypoint(width * 164f / 300f, height * 0f / 300f);//N
            w9.End = "North";
            Waypoint w8 = new Waypoint(width * 164f / 300f, height * 100f / 300f, w9);
            Waypoint w7 = new Waypoint(width * 160f / 300f, height * 130f / 300f, w8);
            Waypoint w6 = new Waypoint(width * 126f / 300f, height * 152f / 300f, w7);
            Waypoint w5 = new Waypoint(width * 44f / 300f, height * 152f / 300f, w6);
            w1.waypointLeft = w5; //making pathing adjustments
            Waypoint w11 = new Waypoint(width * 140f / 300f, height * 300f / 300f);//S
            w11.End = "South";
            Waypoint w10 = new Waypoint(width * 140f / 300f, height * 176f / 300f, w11);
            w2.waypointRight = w10;
            Waypoint w13 = new Waypoint(width * 164f / 300f, height * 172f / 300f, w8);
            Waypoint w12 = new Waypoint(width * 164f / 300f, height * 300f / 300f, w13);
            Waypoint w16 = new Waypoint(width * 0f / 300f, height * 136f / 300f);//W
            w16.End = "West";
            Waypoint w15 = new Waypoint(width * 126f / 300f, height * 136f / 300f, w16);
            Waypoint w14 = new Waypoint(width * 150f / 300f, height * 150f / 300f, w15);
            w13.waypointLeft = w14;
            w13.waypointRight = w3;

            Waypoint w4c = new Waypoint(width *(1f- 300f / 300f), height * (1f - 166f / 300f)); //creating the complement of the first set
            w4c.End = "West";
            Waypoint w3c = new Waypoint(width * (1f - 180f / 300f), height * (1f - 166f / 300f), w4c);
            Waypoint w2c = new Waypoint(width * (1f - 126f / 300f), height * (1f - 166f / 300f), w3c);
            Waypoint w1c = new Waypoint(width * (1f - 0f / 300f), height * (1f - 166f / 300f), w2c);
            Waypoint w9c = new Waypoint(width * (1f - 164f / 300f), height * (1f - 0f / 300f));
            w9c.End = "South";
            Waypoint w8c = new Waypoint(width * (1f - 164f / 300f), height * (1f - 100f / 300f), w9c);
            Waypoint w7c = new Waypoint(width * (1f - 160f / 300f), height * (1f - 130f / 300f), w8c);
            Waypoint w6c = new Waypoint(width * (1f - 126f / 300f), height * (1f - 152f / 300f), w7c);
            Waypoint w5c = new Waypoint(width * (1f - 44f / 300f), height * (1f - 152f / 300f), w6c);
            w1c.waypointLeft = w5c;
            Waypoint w11c = new Waypoint(width * (1f - 140f / 300f), height * (1f - 300f / 300f));
            w11c.End = "North";
            Waypoint w10c = new Waypoint(width * (1f - 140f / 300f), height * (1f - 176f / 300f), w11c);
            w2c.waypointRight = w10c;
            Waypoint w13c = new Waypoint(width * (1f - 164f / 300f), height * (1f - 172f / 300f), w8c);
            Waypoint w12c = new Waypoint(width * (1f - 164f / 300f), height * (1f - 300f / 300f), w13c);
            Waypoint w16c = new Waypoint(width * (1f - 0f / 300f), height * (1f - 136f / 300f));
            w16c.End = "East";
            Waypoint w15c = new Waypoint(width * (1f - 126f / 300f), height * (1f - 136f / 300f), w16c);
            Waypoint w14c = new Waypoint(width * (1f - 150f / 300f), height * (1f - 150f / 300f), w15c);
            w13c.waypointLeft = w14c;
            w13c.waypointRight = w3c;

            West = w1;
            East = w1c;
            South = w12;
            North = w12c;


            //todo unsure if at the end of the function all these waypoints are deleted. If they are, use a list like L to pass back the points.
            L[0] = w1;
            L[1] = w2;
            L[2] = w3;
            L[3] = w4;
            L[4] = w5;
            L[5] = w6;
            L[6] = w7;
            L[7] = w8;
            L[8] = w9;
            L[9] = w10;
            L[10] = w11;
            L[11] = w12;
            L[12] = w13;
            L[13] = w14;
            L[14] = w15;
            L[15] = w16;
            L[16] = w1c;
            L[17] = w2c;
            L[18] = w3c;
            L[19] = w4c;
            L[20] = w5c;
            L[21] = w6c;
            L[22] = w7c;
            L[23] = w8c;
            L[24] = w9c;
            L[25] = w10c;
            L[26] = w11c;
            L[27] = w12c;
            L[28] = w13c;
            L[29] = w14c;
            L[30] = w15c;
            L[31] = w16c;

            redlights = new Waypoint[6] { w2, w6, w13, w2c, w6c, w13c };
            foreach (Waypoint w in redlights)
                w.RedLight = true;

            points = L;
            return L;
        }
    }
}
