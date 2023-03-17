namespace OOP
{
  class Program
  {
    static void Main(string[] args)
    {
      Book book1 = new Book(); //object creation
      book1.title = "Harry Potter";
      book1.author = "JK Rowling";
      book1.pages = 400;

      Console.WriteLine(book1.pages);

      Book book2 = new Book("lord of the Rings", "Tolkein", 700); // object creation with constructor

      if (book1.hasManyPages())
      {
        Console.WriteLine("The book has many pages");
      }
      else
      {
        Console.WriteLine("The book has few pages");
      }


      //Get & Set example
      Movie avengers = new Movie("The Avengers", "Joss Whedon", "PG-13");
      Movie shrek = new Movie("Shrek", "Adam Adamson", "Dog");
      shrek.Rating = "Cat";
      Console.WriteLine(avengers.Rating);
      Console.WriteLine(shrek.Rating);


      //Static member Example
      Song holiday = new Song("Holiday", "Green Day", 200);
      Song kashmir = new Song("Kashmir", "Led Zepplin", 150);

      Console.WriteLine(Song.songCount); //accessing the static variable which is common for all objects
      Console.WriteLine(holiday.getSongCount());
      Console.WriteLine(kashmir.getSongCount());


      //Static class example
      UsefulTools.sayHI("Rajorshi"); //direct access to static methods
      //UsefulTools use = new UsefulTools(); // cant create objects of static class


      //Inheritance example
      Chef chef = new Chef();
      chef.MakeChicken();
      chef.MakeSpecialDish();

      ItalianChef italianChef = new ItalianChef();
      italianChef.MakeChicken(); //Super Class method
      italianChef.MakePasta(); //Sub Class method
      italianChef.MakeSpecialDish();//overridden value
    }
  }
}