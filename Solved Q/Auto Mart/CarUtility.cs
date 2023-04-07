using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Mart
{
    internal class CarUtility:Car
    {
        public bool ValidateCarModel() { 
            if(this.Model == "A3" || this.Model == "A8" || this.Model == "Q5")
            {
                return true;
            }
            return false;
        }

        public Car PriceCalculator() {
            double pr = Convert.ToDouble(this.Price);
            if(this.BodyStyle == "Sedan")
            {
                pr -= (pr * 0.05);
            } else if(this.BodyStyle == "SUV")
            {
                pr -= (pr * 0.10);
            }

            this.Price = Convert.ToString(Convert.ToInt32(pr));

            Car cr = new Car
            {
                Model = this.Model,
                BodyStyle = this.BodyStyle,
                Price = this.Price
            };
            return cr;
        }
    }
}
