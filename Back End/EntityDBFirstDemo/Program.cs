using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDBFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new DemoDBEntities();
            var emp = new Employee()
            {
                EmpId = 4,
                EmpName = "John Cena",
                EmpAddress = "Ohio",
                EmpCountry = "US",
                EmpEmail = "John.cena@gmail.com"
            };
            context.Employees.Add(emp);
            context.SaveChanges();
        }
    }
}
