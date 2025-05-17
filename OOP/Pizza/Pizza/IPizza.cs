using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant
{
    internal interface IPizza
    {
        void Prepare();
        string GetProductName();
        int GetPricePerProduct();
        int GetTotalPrice();
    }
}
