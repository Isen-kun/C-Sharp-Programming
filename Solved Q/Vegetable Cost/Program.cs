class Program{
  static public void Main(string[] args){
    Service serv = new Service();

    Console.WriteLine("Enter bill id");
    serv.BillID = Console.ReadLine();
    Console.WriteLine("Enter vegetable name");
    serv.Name = Console.ReadLine();
    Console.WriteLine("Enter pack capacity in grams");
    serv.GramsInPack = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter cost per pack");
    serv.CostPerPack = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Enter Quantity to purchase in kgs");
    float qty = Convert.ToSingle(Console.ReadLine());

    if(serv.ValidateBillId()){
      Console.WriteLine($"Vegetable cost Rs. {serv.CalculateTotalCost(qty)}");
    } else {
      Console.WriteLine("Invalid ID");
    }
  }
}