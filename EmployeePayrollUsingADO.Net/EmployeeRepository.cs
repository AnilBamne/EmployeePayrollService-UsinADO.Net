using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollUsingADO.Net
{
    public class EmployeeRepository
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollService;Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionString);
        
        /// <summary>
        /// Check connection with data base
        /// </summary>
        public void CheckConnection()
        {
            connection.Open();
            Console.WriteLine("Connection Established");
            this.connection.Close();
        }
    }
}
