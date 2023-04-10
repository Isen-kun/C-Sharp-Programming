class Service:Vegetable{
  public bool ValidateBillId(){
    if(this.BillID.Length == 7 && 
      Convert.ToInt32(this.BillID.Substring(0,3))>=0 &&
      Convert.ToInt32(this.BillID.Substring(0,3))<=999 &&
      this.BillID[3] == '-' &&
      // this.BillID.Substring(4,3).ToUpper()>="AAA" &&
      // this.BillID.Substring(4,3).ToUpper()<="ZZZ"
      this.BillID.Substring(4,3).ToUpper() == this.BillID.Substring(4,3) &&
      char.IsLetter(this.BillID[4]) &&
      char.IsLetter(this.BillID[5]) &&
      char.IsLetter(this.BillID[6])
    ){
      return true;
    }
    return false;
  }

  public double CalculateTotalCost(float quantity){
    return(this.CostPerPack*(quantity*1000)/this.GramsInPack);
  }
}