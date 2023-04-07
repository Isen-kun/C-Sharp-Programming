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

  }
}