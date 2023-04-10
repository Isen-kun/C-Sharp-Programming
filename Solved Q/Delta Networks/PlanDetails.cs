class PlanDetails:Plan{
  public bool ValidatePlanType(){
    if(this.PlanType == "Monthly" || this.PlanType == "Quarterly" || this.PlanType == "Annual"){
      return true;
    }
    return false;
  }

  public Plan CalculatePlanAmount(){
    if(this.PlanType == "Monthly"){
      this.PlanAmount = 450-(450*0.1);
    } else if(this.PlanType == "Quarterly"){
      this.PlanAmount = 1400-(1400*0.2);
    } else if(this.PlanType == "Annual"){
      this.PlanAmount = 2400-(2400*0.5);
    }
    return this;
  }
}