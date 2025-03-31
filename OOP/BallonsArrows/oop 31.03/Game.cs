using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_31._03
{
    public class Game
    {
        public List<Arrow> Arrows { get; set; } = new List<Arrow>() {
        new Arrow(),
        new Arrow(),
        new Arrow(),
        new Arrow(),
        new Arrow(),
        new Arrow(),
        new Arrow(),
        new Arrow(),
        new Arrow(),
        new Arrow()
        };

        public List<Balloons> Balloons { get; set; } = new List<Balloons>()
        {
        new Balloons(),
        new Balloons(),
        new Balloons(),
        new Balloons(),
        new Balloons(),
        new Balloons(),
        new Balloons(),
        new Balloons(),
        new Balloons(),
        new Balloons()
        };
    }
}
