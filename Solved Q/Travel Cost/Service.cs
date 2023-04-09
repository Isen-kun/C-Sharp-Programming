using System;

class Service:Travel{
  public bool ValidateTravelId(string travelId){
    if(travelId.Length == 7){
      if(travelId.Substring(0,3) == this.DeparturePlace.Substring(0.3).ToUpper()){
        if(travelId[3] == "/"){
          if(travelId.Substring(4) == this.DeparturePlace.Substring(0.3).ToUpper()){
            return true;
          }
        }
      }
    }
    return false;
  }

  public double CalculateDiscountedPrice(){
    int disCost = 0;

    if(NoOfDays <= 5){
      disCost = CostPerDay*NoOfDays;
    }else if(NoOfDays > 5 && NoOfDays <= 8){
      disCost = (CostPerDay*NoOfDays)-((CostPerDay*NoOfDays)*0.03);
    }else if(NoOfDays > 8 && NoOfDays <= 10){
      disCost = (CostPerDay*NoOfDays)-((CostPerDay*NoOfDays)*0.05);
    }else if(NoOfDays > 10){
      disCost = (CostPerDay*NoOfDays)-((CostPerDay*NoOfDays)*0.07);
    }
    return disCost;
  }
}