using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Pair
    {
        public double exchangeRate { get; set; }
        public string Name { get; set; }
        public double Fee = 00.2;

        public Pair(double exchangeRate, string name)
        {
            this.exchangeRate = exchangeRate;
            Name = name;
        }
    }
}
