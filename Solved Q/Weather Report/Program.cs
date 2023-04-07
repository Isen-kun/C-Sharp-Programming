using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Report
{
    internal class Program
    {
        public static List<Weather> WeatherList = new List<Weather>();

        public void AddWeatherDetails(string[] weatherDetails) { 
            foreach (var val in weatherDetails)
            {
                Weather wt = new Weather();
                string[] details = val.Split(',');
                wt.Location = details[0].Trim();
                wt.Date = details[1].Trim();
                wt.Temperature = Convert.ToInt32(details[2].Trim());
                wt.Status = details[3].Trim();
                WeatherList.Add(wt);
            }
        }

        public List<Weather> ViewDetailsByLocation(string location) {
            List<Weather> results = new List<Weather>();
            foreach(var val in WeatherList)
            {
                if (val.Location == location)
                {
                    results.Add(val);
                }
            }
            return results;
        }

        public List<Weather> ViewDetailsByDate(string date) {
            List<Weather> results = new List<Weather>();
            foreach (var val in WeatherList)
            {
                if (val.Date == date)
                {
                    results.Add(val);
                }
            }
            return results;
        }
        static void Main(string[] args)
        {
            Program main = new Program();
            while (true)
            {
                Console.WriteLine("1. Add Weather Details");
                Console.WriteLine("2. View Details By Location");
                Console.WriteLine("3. View Details By Date");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter the choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the number of Entries:");
                        int n = Convert.ToInt32(Console.ReadLine());
                        string[] entries = new string[n];
                        for(int i=0; i<n; i++)
                        {
                            entries[i] = Console.ReadLine();
                        }
                        main.AddWeatherDetails(entries);
                        break;

                    case 2:
                        Console.WriteLine("Enter the location");
                        string loc = Console.ReadLine();
                        foreach(var val in main.ViewDetailsByLocation(loc))
                        {
                            Console.WriteLine($"{val.Location} {val.Date} {val.Temperature} {val.Status}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the Date");
                        string date = Console.ReadLine();
                        if(main.ViewDetailsByDate(date).Count == 0)
                        {
                            Console.WriteLine("date is not found");
                        } else
                        {
                            foreach (var val in main.ViewDetailsByDate(date))
                            {
                                Console.WriteLine($"{val.Location} {val.Date} {val.Temperature} {val.Status}");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        Console.WriteLine("Enter valid choice");
                        break;
                }
            }
        }
    }
}
