using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons
{
    public class Player
    {
        public string TeamName { get; set; } = null!;
        public int Score { get; set; }
        public List<Balloon> Balloons = new List<Balloon>();
        public List<Arrow>Arrows = new List<Arrow>();

    }
}
