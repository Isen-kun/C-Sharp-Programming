using System;
using System.Collections.Generic;

class Program{
  public static List<Student> StudentList = new List<Student>();

  public static void Main(string[] args)
  {
    Student stud = new Student();

    while(true){
      Console.WriteLine("Choose the option");
      Console.WriteLine("1. Add the student details");
      Console.WriteLine("2. Get student name by phone");
      Console.WriteLine("3. Remove student details");
      Console.WriteLine("4. Exit");
      int ch = Convert.ToInt32(Console.ReadLine());
    
      switch(ch){
        case 1:
          Console.WriteLine("Enter the student name:");
          string name = Console.ReadLine();
          Console.WriteLine("Enter date of birth:");
          string dob = Console.ReadLine();
          Console.WriteLine("Enter phone number:");
          long phno = Convert.ToInt64(Console.ReadLine());
          Console.WriteLine("Enter the City:");
          string city = Console.ReadLine();
          stud.AddStudentDetails(name, dob, phno, city);
          break;

        case 2:
          Console.WriteLine("Enter phone number:");
          long phno1 = Convert.ToInt64(Console.ReadLine());
          Console.WriteLine(stud.GetStudentName(phno1));
          break;

        case 3:
          Console.WriteLine("Enter phone number:");
          long phno2 = Convert.ToInt64(Console.ReadLine());
          stud.RemoveStudentDetails(phno2);
          break;

        case 4:
          return;
          break;
        
        default:
          Console.WriteLine("Enter a valid value");
          break;
      }
    }
  }
}

