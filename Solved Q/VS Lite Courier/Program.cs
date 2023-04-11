using System;

class Program{
  static public void Main(string[] args){
    CourierDetails cd = new CourierDetails();

    Console.WriteLine("Enter the pickup date");
    cd.PickUpDate=DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);
    
    Console.WriteLine("Enter the delivery date");
    cd.DeliveryDate=DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

    cd.FindServiceType();
    if(cd.ServiceType == "Invalid"){
      Console.WriteLine("Invalid delivery date");
      return;
    }

    Console.WriteLine("Enter the cost");
    cd.Cost = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine($"The delivery charge is {cd.calculateDeliveryCharge()}");
  }
}