using System;

class Service:Travel{
  public bool ValidateTravelId(string travelId){
    if(travelId.Length == 7 && 
        travelId.Substring(0,3) == this.DeparturePlace.Substring(0,3).ToUpper() && 
        travelId[3] == '/' && 
        travelId.Substring(4,3) == this.DestinationPlace.Substring(0,3).ToUpper()
      ){
      return true;
    }
    return false;
  }

  public double CalculateDiscountedPrice(){
    double disCost = 0.0;

    if(this.NoOfDays <= 5){
      disCost = this.CostPerDay*this.NoOfDays;
    }else if(this.NoOfDays > 5 && this.NoOfDays <= 8){
      disCost = (this.CostPerDay*this.NoOfDays)-((this.CostPerDay*this.NoOfDays)*0.03);
    }else if(this.NoOfDays > 8 && this.NoOfDays <= 10){
      disCost = (this.CostPerDay*this.NoOfDays)-((this.CostPerDay*this.NoOfDays)*0.05);
    }else if(this.NoOfDays > 10){
      disCost = (this.CostPerDay*this.NoOfDays)-((this.CostPerDay*this.NoOfDays)*0.07);
    }
    return Convert.ToInt32(disCost);
  }
}