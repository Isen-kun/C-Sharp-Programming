using System;

class Program {
  static public void Main(string[] args){
    Console.WriteLine("Enter the travel id");
    string id = Console.ReadLine();
    Console.WriteLine("Enter the departure place");
    string dep = Console.ReadLine();
    Console.WriteLine("Enter the destination place");
    string dest = Console.ReadLine();
    Console.WriteLine("Enter the number of days");
    int days = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter the cost per day");
    double cost = double.Parse(Console.ReadLine());
    Service serv = new Service();
    serv.TravelId = id;
    serv.DeparturePlace = dep;
    serv.DestinationPlace = dest;
    serv.NoOfDays = days;
    serv.CostPerDay = cost;
    
    if(serv.ValidateTravelId(id))
    {
        Console.WriteLine($"Discounted Cost: {serv.CalculateDiscountedPrice()}");
    }
    else
        Console.WriteLine("Invalid travel id");
  }
}