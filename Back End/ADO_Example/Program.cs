using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=CognizantINTIOT23DFSE001");
            string strSelectAllQuery = "select * from Employee";
            SelectEmployee(con, strSelectAllQuery);
            Console.ReadLine();
        }

        public static void SelectEmployee(SqlConnection con, string strSelectQuery)
        {
            SqlCommand com = new SqlCommand(strSelectQuery, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables["Employee"].Rows.Count > 0)
            {
                Console.WriteLine("====================Employee information=====================");
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    var EmpId = row["EmpId"];
                    var EmpName = row["EmpName"];
                    var EmpAddress = row["EmpAddress"];
                    var EmpCountry = row["EmpCountry"];
                    var EmpEmail = row["EmpEmail"];
                    Console.WriteLine("==========" + EmpName + "==========");
                    Console.WriteLine($"EmpId:{EmpId}  EmpName:{EmpName}  EmpAddress:{EmpAddress}  EmpCountry:{EmpCountry} EmpEmail:{EmpEmail}");
                }
            }
        }
    }
}
