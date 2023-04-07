using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vitality_Health_Care;

namespace Vitality_Health_Care
{
    internal class Program
    {
        public static List<Vaccine> VaccineList = new List<Vaccine>();
        public void AddVaccineDetails(string[] vaccineDetails)
        {
            foreach (var val in vaccineDetails) {
                Vaccine vac = new Vaccine();
                string[] details = val.Split(',');
                vac.BookingId = details[0].Trim();
                vac.Name = details[1].Trim();
                vac.VaccineType = details[2].Trim();
                vac.DoseNumber = details[3].Trim();
                vac.BookingDate = details[4].Trim();
                VaccineList.Add(vac);
            }
        }

        public List<Vaccine> ViewBookingDetailsByDoseNumber(string doseNumber)
        {
            List<Vaccine> res = new List<Vaccine>();
            foreach(var val in VaccineList)
            {
                if (val.DoseNumber == doseNumber)
                {
                    res.Add(val);
                }
            }
            return res;

        }

        public List<Vaccine> ViewBookingDetailsByVaccineType(string vaccineType)
        {
            List<Vaccine> res = new List<Vaccine>();
            foreach (var val in VaccineList)
            {
                if (val.VaccineType==vaccineType)
                {
                    res.Add(val);
                }
            }
            return res;
        }

        static void Main(string[] args) 
        {
            Program main = new Program();

            while (true) {
                Console.WriteLine("1. Add Vaccine Details");
                Console.WriteLine("2. View Details by Dose Number");
                Console.WriteLine("3. View Details By Vaccine Type");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) 
                {
                    case 1:
                        Console.WriteLine("Enter the number of entries");
                        int n = Convert.ToInt32(Console.ReadLine());
                        string[] entries = new string[n];
                        for (int i = 0; i < n; i++) {
                            entries[i] = Console.ReadLine();
                        }
                        main.AddVaccineDetails(entries);
                        break;

                    case 2:
                        Console.WriteLine("Enter the dose number:");
                        string dose = Console.ReadLine();
                        List<Vaccine> results= main.ViewBookingDetailsByDoseNumber(dose);
                        foreach(var val in results)
                        {
                            Console.WriteLine($"{val.BookingId} {val.Name} {val.VaccineType} {val.DoseNumber} {val.BookingDate}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the vaccine type:");
                        string type = Console.ReadLine();
                        List<Vaccine> results1 = main.ViewBookingDetailsByVaccineType(type);
                        foreach (var val in results1)
                        {
                            Console.WriteLine($"{val.BookingId} {val.Name} {val.VaccineType} {val.DoseNumber} {val.BookingDate}");
                        }
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Enter Valid choice");
                        break;
                }
            }
        }

        

    }
}