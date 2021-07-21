using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Textbook : Book
    {
        public int grade;

        public Textbook(String x, int y, int z) : base(x, y)
        {
            grade = z;
        }

        public int getGrade()
        {
            return grade;
        }
        public void setGrade(int x)
        {
            grade = x;
        }
    }
}
