using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Traffic_Simulation_Application
{
    
  public   class Crossing
    {
        // a meeting point of roads. has a map. has traffic lights. has entities. 
        private Road North;
        private Road South;
        private Road East;
        private Road West;
        private Car[] cars;


        public void MoveCars()
        {
            foreach (Car c in cars)
            {
                c.Move();
            }
        }
    }
}
