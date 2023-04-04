using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeutscheBank
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the customer name:");
            string cName = Console.ReadLine();
            Console.WriteLine("Enter the SSN:");
            long s = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the City:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Total Loan Amount:");
            double la = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the number of Years:");
            int yrs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the loan type:");
            string lType = Console.ReadLine();

            CustomerUtility cu = new CustomerUtility(cName, s, city, la, yrs);

            Console.WriteLine($"Token Number is {cu.GenerateTokenNumber()}");
            Console.WriteLine($"Annual interest is {cu.CalculateAnnualInterest(lType)}");

            Console.ReadKey();
        }
    }
}
