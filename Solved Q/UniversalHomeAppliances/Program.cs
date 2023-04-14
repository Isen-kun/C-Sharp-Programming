using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalHomeAppliances
{
    public class Program
    {
        public static Dictionary<int, Appliance> applianceDetails = new Dictionary<int, Appliance>();

        public Dictionary<string, string> GetApplianceDetails(string applianceId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach(var val in applianceDetails)
            {
                if(val.Value.Id == applianceId)
                {
                    result.Add(val.Value.Id, $"{val.Value.Name}_{val.Value.Brand}");
                }
            }
            return result;
        }

        public Dictionary<string, string> FindApplianceWithPriceRange(double minRange, double maxRange)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach(var val in applianceDetails.Values)
            {
                if (val.Price >= minRange && val.Price <= maxRange)
                {
                    results.Add(val.Name, val.Brand);
                }
            }
            return results;
        }

        public Dictionary<int, Appliance> FindHighCostAppliance()
        {
            Dictionary<int, Appliance> result = new Dictionary<int, Appliance>();
            double highest = Double.MinValue;
            int id=0;
            foreach (KeyValuePair<int, Appliance> val in applianceDetails)
            {
                if (val.Value.Price > highest)
                {
                    highest = val.Value.Price;
                    id = val.Key;
                }
            }
            result.Add(id, applianceDetails[id]);
            return result;
        }

        static void Main(string[] args)
        {
            applianceDetails.Add(1, new Appliance { Id = "AP01", Name = "Refrigerator", Brand = "LG", Price = 10000 });
            applianceDetails.Add(2, new Appliance { Id = "AP02", Name = "Dishwasher", Brand = "Samsung", Price = 25000 });
            applianceDetails.Add(3, new Appliance { Id = "AP03", Name = "Oven", Brand = "Bosch", Price = 5000 });
            applianceDetails.Add(4, new Appliance { Id = "AP04", Name = "Microwave", Brand = "Whirlpool", Price = 7500 });
            applianceDetails.Add(5, new Appliance { Id = "AP05", Name = "Toaster", Brand = "LG", Price = 1500 });

            Program main = new Program();

            while (true)
            {
                Console.WriteLine("1. Get appliance details");
                Console.WriteLine("2. Find appliance with price range");
                Console.WriteLine("3. Find high cost appiance");
                Console.WriteLine("4. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Appliance Id");
                        string input = Console.ReadLine();
                        if (main.GetApplianceDetails(input).Count == 0)
                        {
                            Console.WriteLine("Appliance id not found");
                            break;
                        }
                        foreach(var val in main.GetApplianceDetails(input))
                        {
                            Console.WriteLine($"{val.Key} {val.Value}");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the minimun price range");
                        double a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the maximum price range");
                        double b = Convert.ToDouble(Console.ReadLine());
                        if(main.FindApplianceWithPriceRange(a, b).Count == 0)
                        {
                            Console.WriteLine("Appliance not found");
                            break;
                        }
                        foreach(var val in main.FindApplianceWithPriceRange(a, b))
                        {
                            Console.WriteLine($"{val.Key} {val.Value}");
                        }
                        break;

                    case 3:
                        foreach(var val in main.FindHighCostAppliance())
                        {
                            Console.WriteLine($"ID:{val.Value.Id}, Name: {val.Value.Name}, Brand: {val.Value.Brand}, Price: {val.Value.Price}");
                        }
                        break;

                    case 4:
                        return;
                }

            }
        }
    }
}