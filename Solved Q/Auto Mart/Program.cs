using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Mart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarUtility ct = new CarUtility();
            Console.WriteLine("Enter the model");
            ct.Model = Console.ReadLine();

            if (ct.ValidateCarModel())
            {
                Console.WriteLine("Enter the body style");
                ct.BodyStyle = Console.ReadLine();
                Console.WriteLine("Enter the price");
                ct.Price = Console.ReadLine();
            }

            Car cr = ct.PriceCalculator();
            Console.WriteLine($"Model: {cr.Model}");
            Console.WriteLine($"Body Style {cr.BodyStyle}");
            Console.WriteLine($"Price After Discount: {cr.Price}");

            Console.ReadKey();
        }
    }
}
