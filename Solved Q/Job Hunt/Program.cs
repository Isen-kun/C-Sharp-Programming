using System;
using System.Collections.Generic;
using System.Linq;

class Program {
  public static Dictionary<string, string> VacancyDetails = new Dictionary<string, string>();

  public void AddVacancyDetails(string[] vacancy){
    foreach(var val in vacancy){
      string[] kv = val.Split(":");
      VacancyDetails.Add(kv[0], kv[1]);
    }
  }

  public int FindTheNumberOfVacancies(string role){
    int count=0;
    foreach(var val in VacancyDetails.Values){
      if(val==role){
        count++;
      }
    }
    if(count>0){
      return count;
    }
    return -1;
  }

  public List<string> FindCompanyNames(string role){
    List<string> results = new List<string>();
    foreach(KeyValuePair<string, string> val in VacancyDetails){
      if(val.Value == role){
        results.Add(val.Key);
      }
    }
    return results;
  }

  public static void Main(string[] args){
    Program main = new Program();

    while(true){
      Console.WriteLine("1. Add Vacancy Details");
      Console.WriteLine("2. View Number of Vacancies By Role");
      Console.WriteLine("3. View Company Name By Role");
      Console.WriteLine("4. Exit");
      Console.WriteLine("Enter your choice:");
      int choice = Convert.ToInt32(Console.ReadLine());
      
      switch(choice){
        case 1:
          Console.WriteLine("Enter the number of Entries");
          int n = Convert.ToInt32(Console.ReadLine());
          string[] entries = new string[n];
          for(int i=0; i<n; i++){
            entries[i]=Console.ReadLine();
          }
          main.AddVacancyDetails(entries);
          break;
        
        case 2:
          Console.WriteLine("Enter the role:");
          string role = Console.ReadLine();
          if(main.FindTheNumberOfVacancies(role) == -1){
            Console.WriteLine("No vacancies are available for this role.");
          } else {
            Console.WriteLine("Available vacancies are: " + main.FindTheNumberOfVacancies(role));
          }
          break;

        case 3:
          Console.WriteLine("Enter the role:");
          string role1 = Console.ReadLine();
          if(main.FindCompanyNames(role1).Count == 0){
            Console.WriteLine("No companies are available for this role");
          } else {
            foreach(var val in main.FindCompanyNames(role1)){
              Console.WriteLine(val);
            }
          }
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