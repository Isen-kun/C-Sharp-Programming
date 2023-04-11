class CourierDetails:Courier{
  public void FindServiceType(){
    if(DateTime.Compare(this.PickUpDate, this.DeliveryDate) == 0){
      this.ServiceType = "SameDay";
    } else if(this.DeliveryDate.Day - this.PickUpDate.Day == 3){
      this.ServiceType = "Express";
    } else if(this.DeliveryDate.Day - this.PickUpDate.Day >= 3){
      this.ServiceType = "Standard";
    } else if(DateTime.Compare(this.PickUpDate, this.DeliveryDate) == 1){
      this.ServiceType = "Invalid";
    }
  }

  public double calculateDeliveryCharge(){
    if(this.ServiceType == "SameDay"){
      return (this.Cost - (this.Cost*0.5));
    } else if(this.ServiceType == "Express"){
      return (this.Cost - (this.Cost*0.3));
    } else if(this.ServiceType == "Standard"){
      return this.Cost;
    }
    return 0.0;
  }
}