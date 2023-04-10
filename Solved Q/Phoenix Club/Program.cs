using System;
using System.Collections.Generic;

class Program{
  public static List<Player> PlayerList= new List<Player>();

  public void AddPlayerDetails(string[] playerDetails){
    foreach(var val in playerDetails){
      string[] details = val.Split(':');
      Player pl = new Player();
      pl.Number = details[0];
      pl.Name = details[1];
      pl.Age = Convert.ToInt32(details[2]);
      pl.InterestedIn = details[3];
      PlayerList.Add(pl);
    } 
  }

  public int FindCountOfPlayersByAge(int age){
    int count=0;
    foreach(var val in PlayerList){
      if(val.Age < age){
        count++;
      }
    }
    return count;
  }

  public List<Player> ViewDetailsByInterestedIn(string interestedIn){
    List<Player> results= new List<Player>();
    foreach(var val in PlayerList){
      if(val.InterestedIn == interestedIn){
        results.Add(val);
      }
    }
    return results;
  }

  static public void Main(string[] args){
    Program main = new Program();

    while(true){
      Console.WriteLine("1. Add player details");    
      Console.WriteLine("2. Find Count by age");    
      Console.WriteLine("3. View Details by interested in");    
      Console.WriteLine("4. Exit");    
      Console.WriteLine("Enter the choice");    
      int choice = Convert.ToInt32(Console.ReadLine());

      switch(choice){
        case 1:
          Console.WriteLine("Enter the number of entries:");
          int n = Convert.ToInt32(Console.ReadLine());
          string[] entries = new string[n];
          for(int i=0; i<n; i++){
            entries[i]=Console.ReadLine();
          }
          main.AddPlayerDetails(entries);
          break;

        case 2:
          Console.WriteLine("Enter the age:");
          int ag = Convert.ToInt32(Console.ReadLine());
          if(main.FindCountOfPlayersByAge(ag)==0){
            Console.WriteLine("Not found");
          } else {
            Console.WriteLine($"The player below {ag} is {main.FindCountOfPlayersByAge(ag)}");
          }
          break;
        
        case 3:
          Console.WriteLine("Enter the interested in:");
          string ii = Console.ReadLine();
          if(main.ViewDetailsByInterestedIn(ii).Count == 0){
            Console.WriteLine("Player not found");
          } else{
            foreach(var val in main.ViewDetailsByInterestedIn(ii)){
              Console.WriteLine($"{val.Number} {val.Name} {val.Age} {val.InterestedIn}");
            }
          }
          break;

        case 4:
          return;
      }
    }
  }
}