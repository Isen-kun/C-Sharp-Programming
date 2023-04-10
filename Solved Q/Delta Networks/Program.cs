class Program{
  static public void Main(string[] args){
    PlanDetails pd = new PlanDetails();

    Console.WriteLine("Enter the plan type");
    pd.PlanType = Console.ReadLine();

    if(pd.ValidatePlanType()){
      Console.WriteLine($"Plan amount is {pd.CalculatePlanAmount().PlanAmount}");
    } else {
      Console.WriteLine("Invalid plan");
    }
  }
}