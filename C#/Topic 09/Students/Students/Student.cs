using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Student
    {
        private String name;
        private String phone;
        private String studNo;

        public Student()
        {
            name = "";
            phone = "";
            studNo = "";
        }

        public Student(String a, String b, String c)
        {
            name = a;
            phone = b;
            studNo = c;
        }

        //Setters
        public void setName(String x)
        {
            name = x;
        }

        public void setPhone(String x)
        {
            phone = x;
        }

        public void setStudNo(String x)
        {
            studNo = x;
        }

        //Getters
        public String getName()
        {
            return name;
        }

        public String getPhone()
        {
            return phone;
        }

        public String getStudNo()
        {
            return studNo;
        }

        //Display Method
        public String displayStudent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ");
            sb.Append(name);
            sb.Append("\nPhobe: ");
            sb.Append(phone);
            sb.Append("\nStudNo: ");
            sb.Append(studNo);

            return sb.ToString();
        }
    }
}

