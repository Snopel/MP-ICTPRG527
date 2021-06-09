using System;

namespace Carpet
{
    class Program
    {
        static void Main(string[] args)
        {
            int length;
            int width;
            int area;
            double cost;
            double carpetCost;


            Console.Write("Length (m): ");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Width (m): ");
            width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Carpet Price ($): ");
            cost = Convert.ToDouble(Console.ReadLine());

            area = length * width;
            carpetCost = Math.Round((area * cost), 2);

            Console.WriteLine("\nCarpet cost: $" + carpetCost);
            Console.ReadLine();
        }
    }
}
