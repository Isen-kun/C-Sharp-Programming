using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeutscheBank
{
    internal class CustomerUtility:Customer
    {
        public string GenerateTokenNumber() {
            string res = "";

            res += char.ToUpper(this.CustomerName[0]);
            res += char.ToUpper(this.CustomerName[1]);
            res += char.ToUpper(this.City[2]);
            string temp = Convert.ToString(this.SSN);
            res += temp.Substring(temp.Length-2);

            return res;
        }


        public CustomerUtility(string c, long ss, string ci, double la, int ny) {
            this.CustomerName = c;
            this.SSN = ss;
            this.City = ci;
            this.LoanAmount = la;
            this.NoOfYears = ny;
            
        }

        public double CalculateAnnualInterest(string lt) {
            double AnnualInterest=0.0;
            if (lt == "Home")
            {
                AnnualInterest = this.LoanAmount * this.NoOfYears * 0.03;
            } else if(lt == "Business")
            {
                AnnualInterest = this.LoanAmount * this.NoOfYears * 0.05;
            }else if(lt == "Gold")
            {
                AnnualInterest = this.LoanAmount * this.NoOfYears * 0.02;
            }
            return AnnualInterest;
        }
    }
}
