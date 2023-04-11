using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luxe_Salon
{
    internal class CustomerDetails:Customer
    {
        public bool ValidateMemberType()
        {
            if(this.MemberType == "Gold" || this.MemberType == "Diamond" || this.MemberType == "Platinum")
            {
                return true;
            } 
            return false;
        }

        public double ServiceChargeAfterDiscount()
        {
            if (this.MemberType == "Gold")
            {
                return (this.ServiceCharge - (this.ServiceCharge * 0.05));
            } else  if(this.MemberType == "Diamond")
            {
                return (this.ServiceCharge - (this.ServiceCharge * 0.10));
            } else if(this.MemberType == "Platinum")
            {
                return (this.ServiceCharge - (this.ServiceCharge * 0.15));
            }
            return 0.0;
        }
    }
}
