using System;

class Program{
  public static Queue<Customer> CustomerQueue = new Queue<Customer>();
  

  public static void Main(string[] args){
    Customer cus = new Customer();

    while(true){
      Console.WriteLine("Enter the choice");
      Console.WriteLine("1. Add the customers details");
      Console.WriteLine("2. Get customer number with service");
      Console.WriteLine("3. Remove customer details");
      Console.WriteLine("4. Exit");
      int choice = Convert.ToInt32(Console.ReadLine());

      switch(choice){
        case 1:
          Console.WriteLine("Enter the Customer name");
          string name = Console.ReadLine();
          Console.WriteLine("Enter the mobile number");
          long number = Convert.ToInt64(Console.ReadLine());
          Console.WriteLine("Enter the city");
          string city = Console.ReadLine();
          Console.WriteLine("Enter the service");
          string service = Console.ReadLine();
          if(cus.AddCustomer(name, number, city, service)){
            Console.WriteLine("Customer detail added successfully");
          }
          break;

        case 2:
          Console.WriteLine(cus.GetCustomerNameWithService());
          break;

        case 3:
          Console.WriteLine("Enter the mobile number");
          long number2 = Convert.ToInt64(Console.ReadLine());
          CustomerQueue = cus.RemoveCustomerDetails(number2);
          break;

        case 4:
          return;
          break;

        default:
          Console.WriteLine("Enter valid choice");
          break;
      }
    }
  }
}