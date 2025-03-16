using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class NormalCustomer : Customer
    {
        public NormalCustomer(string name, double balance) : base(name, balance)
        {
        }
        public override string ToString()
        {
         return $"Име:{Name} Баланс:{Balance}";
        }
    }
}
