using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechtronic_Customer_Card
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Service serv = new Service();

            Console.WriteLine("Enter the customr name");
            serv.CustomerName = Console.ReadLine();
            Console.WriteLine("Enter the card type");
            serv.CardType = Console.ReadLine();
            Console.WriteLine("Enter the purchased amount");
            serv.PurchaseAmount = Convert.ToDouble(Console.ReadLine());

            if (serv.ValidateCardType())
            {
                Console.WriteLine($"Total amount is {serv.CalculateTotalAmount()}");
            } else
            {
                Console.WriteLine("Invalid card type");
            }
            Console.ReadKey();
        }
    }
}
