using System;

class Service:Parking{
  public void ExtractDetails(string parkingDetails){
    string[] details = parkingDetails.Split(':');
    this.VehicleNumber=details[0];
    this.VehicleType=details[1];
    this.NumberOfDays=Convert.ToInt32(details[2]);
  }

  public bool ValidateVehicleType(){
    if(this.VehicleType=="2 Wheeler" || this.VehicleType=="3 Wheeler" || this.VehicleType=="4 Wheeler"){
      return true;
    }
    return false;
  }

  public double CalculateTotalAmount(){
    if(this.VehicleType=="2 Wheeler"){
      return this.NumberOfDays*50;
    } else if(this.VehicleType=="3 Wheeler"){
      return this.NumberOfDays*70;
    } else if(this.VehicleType=="4 Wheeler"){
      return this.NumberOfDays*100;
    } else {
      return 0.0;
    }
  }
}