using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant
{
    abstract class Pizza : IPizza
    {
        protected string size;
        protected int amount;

        protected Pizza(string size,int amount)
        {
            this.size = size;
            this.amount = amount;
        }
        public abstract void Prepare();
        
        public abstract string GetProductName();

        public abstract int GetPricePerProduct();

        public int GetTotalPrice()
        {
            return GetPricePerProduct() * amount;

        }

        public int GetAmount()
        {
            return amount;
        }



    }

}



