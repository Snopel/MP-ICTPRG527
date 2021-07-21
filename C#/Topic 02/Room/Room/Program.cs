using System;

namespace Room
{
    class Program
    {
        static void Main(string[] args)
        {
            int length;
            int width;
            int area;

            Console.Write("Length: ");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Width: ");
            width = Convert.ToInt32(Console.ReadLine());

            area = length * width;

            Console.WriteLine("\nArea: " + area);
        }
    }
}
