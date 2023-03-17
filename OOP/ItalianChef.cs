namespace OOP
{
  class ItalianChef : Chef
  {
    public void MakePasta()
    {
      Console.WriteLine("The Italian chef makes the pasta");
    }

    public override void MakeSpecialDish() //use override for overriding
    {
      Console.WriteLine("The Italian chef makes Pizza");
    }
  }
}