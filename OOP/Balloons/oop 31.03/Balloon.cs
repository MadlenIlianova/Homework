using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Balloons
{
    public class Balloon
    {
        public int BalloonSize { get; set; }
        public int BallonPoints { get; set; }
        public string BalloonType { get; set; } = "NormalBalloon";

        public Balloon()
        {
            Random random = new Random();
            BalloonSize = random.Next(0, 101);
            BallonPoints = random.Next(0, 51);
        }
        public Balloon(string type)
        {
            Random random = new Random();
            BalloonSize = random.Next(0, 101);
            BallonPoints = random.Next(0, 51);
            BalloonType = type; 
        }
    }
}

