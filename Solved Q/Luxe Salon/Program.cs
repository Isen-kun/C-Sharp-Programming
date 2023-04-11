using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxe_Salon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerDetails cd = new CustomerDetails();
            Console.WriteLine("Enter the customer name");
            cd.CustomerName = Console.ReadLine();
            Console.WriteLine("Enter the membership type");
            cd.MemberType = Console.ReadLine();
            Console.WriteLine("Enter the service charge");
            cd.ServiceCharge = Convert.ToDouble(Console.ReadLine());

            if (cd.ValidateMemberType())
            {
                Console.WriteLine($"Service charge after discount is {cd.ServiceChargeAfterDiscount()}");
            } else
            {
                Console.WriteLine("Invalid membership");
            }
            Console.ReadKey();
        }
    }
}
