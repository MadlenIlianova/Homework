using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons
{
    public class Arrow
    {
        public int Accuracy { get; set; }
        public int Points { get; set; } = 0;

        public Arrow()
        {
           
        Random random = new Random();
         Accuracy = random.Next(0,101);
      
    }
        public Arrow(int points)
        {

            Random random = new Random();
            Accuracy = random.Next(0, 101);
            Points = points;

        }
    }
}
