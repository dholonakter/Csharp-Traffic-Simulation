using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace City_Traffic_Simulation_Application
{
    [Serializable]
   public class Car : Entity
    {
        //will be inheriting from Entity
        private Point location; //location on the crossing, upper left corner of the drawing
        private int width; //width (in pixels) of the visual representation of a car, X
        private int height; //height (in pixels) of the visual representation of a car, Y

        public Car(Point p, Waypoint w,int width, int height) : base(p,w)
        {
            this.maxSpeed = 0.1;
            this.Speed = 0;
            this.Accel = 0.0001;
            xoffset = width/2;
            yoffset = height/2;
            CalculateDirection(x, y, nextWayPoint);
        }

        public Car(Point loc, int width, int height)
        {
            this.location = loc;
            this.width = 15;
            this.height = 15;

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

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        public void Drawtrafic(ref Graphics gr)
        {
            gr.FillRectangle(Brushes.Green, this.location.X, this.location.Y, this.width, this.height);
        }
        public void Draw(ref Graphics gr)
        {
            gr.FillRectangle(Brushes.Violet, this.location.X, this.location.Y, this.width, this.height);
        }
    }
}
