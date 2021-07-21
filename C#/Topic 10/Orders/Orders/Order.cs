using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    //SUPER CLASS
    class Order
    {
        //Declaring variables
        private String custName;
        private int custID;
        private int qty;
        private double unitPrice;
        private double totalPrice = 0; //To be used upon activating the ComputePrice method

        //Default constructor
        public Order()
        {
            custName = "null";
            custID = 0;
            qty = 0;
            unitPrice = 0;
            totalPrice = 0;
        }

        //Full constructor
        public Order(String a, int b, int c, double d)
        {
            custName = a;
            custID = b;
            qty = c;
            unitPrice = d;
            totalPrice = 0;
        }

        //Compute Price method
        public void computePrice()
        {
            totalPrice = qty * unitPrice;
        }

        //Getters
        public String getCustName()
        {
            return custName;
        }
        public int getCustID()
        {
            return custID;
        }
        public int getQty()
        {
            return qty;
        }
        public double getUnitPrice()
        {
            return unitPrice;
        }
        public double getTotalPrice()
        {
            return totalPrice;
        }

        //Setters
        public void setCustName(String x)
        {
            custName = x;
        }
        public void setCustID(int x)
        {
            custID = x;
        }
        public void setQty(int x)
        {
            qty = x;
        }
        public void setUnitPrice(double x)
        {
            unitPrice = x;
        }
        public void setTotalPrice(double x)
        {
            totalPrice = x;
        }
    }
}
