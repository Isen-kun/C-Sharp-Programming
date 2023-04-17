using System;

class Program{
  static public void Main(string[] args){
    Service serv = new Service();

    Console.WriteLine("Enter the Program details");
    serv.ExtractDetails(Console.ReadLine());

    if(serv.ValidateVehicleType()){
      Console.WriteLine($"The amount to be paid: {serv.CalculateTotalAmount()}");
      return;
    } 
    Console.WriteLine("Invalid vehicle Type");
  }
}