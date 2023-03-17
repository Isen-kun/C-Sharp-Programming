namespace OOP
{
  class Chef
  {
    public void MakeChicken()
    {
      Console.WriteLine("The chef makes chicken");
    }

    public void MakeSalad()
    {
      Console.WriteLine("The chef makes salad");
    }

    public virtual void MakeSpecialDish() //use virtial for overriding
    {
      Console.WriteLine("The chef makes bbq ribs");
    }
  }
}