using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantJewels
{
    public class Service:Bill
    {
        public void ExtractDetails(string billDetails)
        {
            string[] details = billDetails.Split(':');
            this.MetalName = details[0];
            this.Weight = Convert.ToDouble(details[1]);
            this.PurityOfMetal = Convert.ToDouble(details[2]);
            this.WantDecoration = Convert.ToBoolean(details[3]);
        }

        public bool ValidateMetalName()
        {
            if(this.MetalName == "Gold" || this.MetalName == "Silver")
            {
                return true;
            }
            return false;
        }

        public double CalculateTotalPrice()
        {
            double TotalPrice = 0.0;
            if(this.MetalName == "Gold")
            {
                TotalPrice = (5000 * (this.PurityOfMetal / 100)) * this.Weight;
            } else if(this.MetalName == "Silver")
            {
                TotalPrice = (100 * (this.PurityOfMetal / 100)) * this.Weight;
            }
            if (WantDecoration)
            {
                TotalPrice += TotalPrice * 0.1;
            }
            return TotalPrice;
        }
    }
}
