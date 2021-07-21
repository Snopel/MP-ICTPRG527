using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Book
    {
        //Declare variables
        private String title;
        private int pages;

        //Default constructor
        public Book()
        {
            title = "";
            pages = 0;
        }

        //Secondary constructor
        public Book(String x, int y)
        {
            title = x;
            pages = y;
        }

        //Getters
        public String getTitle()
        {
            return title;
        }
        public int getPages()
        {
            return pages;
        }

        //Setters
        public void setTitle(String x)
        {
            title = x;
        }
        public void setPages(int x)
        {
            pages = x;
        }
    }
}
