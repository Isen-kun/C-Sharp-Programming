using System;

class Customer {
  public string CustomerName {get; set;}
  public long MobileNumber {get; set;}
  public string City {get; set;}
  public string Service {get; set;}

  public bool AddCustomer(string name, long mobileNo, string city, string service){
    Customer cus = new Customer();
    cus.CustomerName=name;
    cus.MobileNumber=mobileNo;
    cus.City=city;
    cus.Service=service;
    Program.CustomerQueue.Enqueue(cus);
    return true;
  }

  public string GetCustomerNameWithService(){
    Customer cus = Program.CustomerQueue.Peek();
    // Customer cus = new Customer();
    // cus = Program.CustomerQueue.Peek();
    return $"{cus.CustomerName.ToUpper()}{cus.Service}";
  }

  public Queue<Customer> RemoveCustomerDetails(long MobileNo){
    Queue<Customer> newQueue = new Queue<Customer>();
    foreach(var val in Program.CustomerQueue){
      if(val.MobileNumber!=MobileNo){
        newQueue.Enqueue(val);
      }
    }
    return newQueue;
  }
}