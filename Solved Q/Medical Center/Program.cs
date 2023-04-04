using System;
using System.Collections.Generic;

class Program{
  public static List<Appointment> AppointmentList = new List<Appointment>();  

  public void AddAppointmentDetails(string[] details){
    for(int i=0; i<details.Length; i++){
      Appointment app = new Appointment();
      string [] values = details[i].Split(',');
      app.PatientName=values[0];
      app.Date=values[1];
      app.Time=values[2];
      app.Reason=values[3];
      AppointmentList.Add(app);
    }
  }

  public List<Appointment> ViewBookingDetailsByReason(string reason){
    List<Appointment> result = new List<Appointment>();
    foreach(var val in AppointmentList){
      if(val.Reason ==reason){
        result.Add(val);
      }
    }
    return result;
  }

  public List<Appointment> ViewBookingDetailsByDate(string date){
    List<Appointment> result = new List<Appointment>();
    foreach(var val in AppointmentList){
      if(val.Date ==date){
        result.Add(val);
      }
    }
    return result;
  }


  public static void Main(string[] args){
    Program pr = new Program();
      while(true){
        Console.WriteLine("1. Add Appointment Details");
        Console.WriteLine("2. View Details By Appointment Reason");
        Console.WriteLine("3. View Details By Appointment Date");
        Console.WriteLine("4. Exit");
        Console.WriteLine("Enter the choice");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch(choice){
          case 1:
            Console.WriteLine("Enter the number of entries:");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] entries = new string[n];
            for(int i=0; i<n; i++){
              Console.WriteLine("{name,date,time,reason} - format");
              entries[i]=Console.ReadLine();
            }
            pr.AddAppointmentDetails(entries);
            break;

          case 2:
            Console.WriteLine("Enter The Appointment reason");
            string reason = Console.ReadLine();
            List<Appointment> output = pr.ViewBookingDetailsByReason(reason);
            foreach(var val in output){
              Console.WriteLine($"{val.PatientName}  {val.Date}  {val.Time}  {val.Reason}");
            }
            break;

          case 3:
            Console.WriteLine("Enter the appointmnet date");
            string date = Console.ReadLine();
            List<Appointment> output1 = pr.ViewBookingDetailsByDate(date);
            foreach(var val in output1){
              Console.WriteLine($"{val.PatientName}  {val.Date}  {val.Time}  {val.Reason}");
            }
            break;

          case 4:
            return;
          
          default:
            Console.WriteLine("Enter valid values");
            break;
        }
      }
  }
}