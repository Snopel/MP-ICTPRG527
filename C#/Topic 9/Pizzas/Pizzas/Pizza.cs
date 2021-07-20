using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzas
{
    class Pizza
    {
        private String toppings;
        private int diameter;
        private double price;

        //Constructors
        public Pizza()
        {
            toppings = "None";
            diameter = 0;
            price = 0.0;
        }
        public Pizza(String a, int b, double c)
        {
            toppings = a;
            diameter = b;
            price = c;
        }

        //Getters
        public String getToppings()
        {
            return toppings;
        }
        public int getDiameter()
        {
            return diameter;
        }
        public double getPrice()
        {
            return price;
        }

        //Setters
        public void setToppings(String x)
        {
            toppings = x;
        }
        public void setDiameter(int x)
        {
            diameter = x;
        }
        public void setPrice(double x)
        {
            price = x;
        }

        //Display Method
        public String displayPizza()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Thank you for ordering your Pizza!\n Your Pizza:\nToppings: ");
            sb.Append(toppings);
            sb.Append("\nSize: ");
            sb.Append(diameter);
            sb.Append("cm\nPrice: $");
            sb.Append(Math.Round(price, 2));

            return sb.ToString();
        }
    }
}
