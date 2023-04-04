using System;
using System.Collections.Generic;

public class Student{
    public string StudentName {get; set;}
    public string DOB {get; set;}
    public long PhoneNo {get; set;}
    public string City {get; set;}

    public List<Student> AddStudentDetails(string name, string dob, long phone, string city){
      Student newStud = new Student();
      newStud.StudentName=name;
      newStud.DOB=dob;
      newStud.PhoneNo=phone;
      newStud.City=city;

      Program.StudentList.Add(newStud);
      return Program.StudentList;
    }

    public string GetStudentName(long phone){
      foreach(var val in Program.StudentList){
        if(val.PhoneNo == phone){
          return val.StudentName;
        }
      }
      return "";
    }

    public List<Student> RemoveStudentDetails(long phone){
      for(int i = Program.StudentList.Count-1; i>=0; i--){
        if(Program.StudentList[i].PhoneNo == phone){
          Program.StudentList.RemoveAt(i);
        }
      }
      return Program.StudentList;
    }
  }