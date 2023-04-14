using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ElegantJewels
{
    public class Program
    {
        static void Main(string[] args)
        {
            Service serv = new Service();
            Console.WriteLine("Enter the bill details");
            string input = Console.ReadLine();
            serv.ExtractDetails(input);
            if (!serv.ValidateMetalName())
            {
                Console.WriteLine("Invalid Metal name");
            } else
            {
                Console.WriteLine($"The bill amount is: {serv.CalculateTotalPrice()}");
            }
            Console.ReadKey();
        }
    }
}
