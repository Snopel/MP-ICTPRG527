using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDates
{
    class Date
    {
        //Declaring variables (DD/MM/YYYY)
        private int day; //day of the month
        private int month; //1 = Jan, 2 = Feb, Etc.
        private int year; //The year in a YYYY format

        //Default constructor set to 1/1/2017
        public Date()
        {
            day = 1; 
            month = 1;
            year = 2017;
        }

        //Constructor that takes input from the user and creates a date
        public Date(int x, int y, int z)
        {
            day = x;
            month = y;
            year = z;
        }

        //Builds a string to output a date in a D/M/Y format
        public String getDate()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(day);
            sb.Append("/");
            sb.Append(month);
            sb.Append("/");
            sb.Append(year);
            return sb.ToString();
        }
        
        public int getYear()
        {
            return year;
        }
    }
}
