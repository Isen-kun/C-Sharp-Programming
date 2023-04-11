using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechtronic_Customer_Card
{
    internal class Service:Bill
    {
        public bool ValidateCardType()
        {
            if(this.CardType == "Classic" || this.CardType == "Gold" || this.CardType == "Platinum" || this.CardType == "Signature")
            {
                return true;
            }
            return false;
        }

        public double CalculateTotalAmount()
        {
            if(this.CardType == "Classic")
            {
                return (this.PurchaseAmount - (this.PurchaseAmount * 0.05));
            } else if(this.CardType == "Gold")
            {
                return (this.PurchaseAmount - (this.PurchaseAmount * 0.10));
            } else if (this.CardType == "Platinum")
            {
                return (this.PurchaseAmount - (this.PurchaseAmount * 0.15));
            } else if(this.CardType == "Signature")
            {
                return (this.PurchaseAmount - (this.PurchaseAmount * 0.20));
            }
            return 0.0;
        }
    }
}
