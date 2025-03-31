using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_31._03
{
    public class Arrow
    {
        public int Accuracy { get; set; }

        public Arrow()
        {
            Random random = new Random();
            Accuracy = random.Next(0,101);
        }
    }
}
