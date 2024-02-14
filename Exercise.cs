using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1_The_Exercise_App_G.Canos{
    public class Exercise {
        //2023-1-1,Walking,30,2.5
        public DateTime dt;
        public string exType;
        public decimal time;
        public decimal speed;
        public Exercise(DateTime dt, string exType, decimal time, decimal speed) {
            this.dt = dt;
            this.exType = exType;
            this.time = time;
            this.speed = speed;
        }
    }

}
