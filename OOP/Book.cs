using System;

namespace OOP
{
  class Book
  {
    public string title; //class attributes
    public string author;
    public int pages;

    public Book() // Default Constructor
    {
      title = "";
      author = "";
      pages = 0;
    }

    public Book(string t, string a, int p) //parameterised constructor
    {
      title = t;
      author = a;
      pages = p;
    }

    public bool hasManyPages()
    {
      if (pages > 500)
      {
        return true;
      }
      return false;
    }
  }
}