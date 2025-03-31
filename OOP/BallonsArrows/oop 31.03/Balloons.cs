using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace oop_31._03
{
    public class Balloons
    {
        public int BalloonSize { get; set; }

        public Balloons()
        {
            Random random = new Random();
            BalloonSize = random.Next(0, 101);
        }
    }
}
