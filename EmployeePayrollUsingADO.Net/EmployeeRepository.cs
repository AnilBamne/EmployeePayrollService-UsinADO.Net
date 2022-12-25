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
            try
            {
                this.connection.Open();
                Console.WriteLine("Connection Established");
                this.connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Connection not established");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Get all employee details from table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * From EmployeePayroll;";
                    SqlCommand command = new SqlCommand(query, connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.ID = sqlDataReader.GetInt32(0);
                            employeeModel.Name = sqlDataReader.GetString(1);
                            employeeModel.BasicPay = sqlDataReader.GetDouble(2);
                            employeeModel.StartDate = sqlDataReader.GetDateTime(3);
                            employeeModel.gender = sqlDataReader.GetString(4);
                            employeeModel.Phone = sqlDataReader.GetInt64(5);
                            employeeModel.Department = sqlDataReader.GetString(6);
                            employeeModel.Address = sqlDataReader.GetString(7);
                            employeeModel.Deductions = sqlDataReader.GetDouble(8);
                            employeeModel.TaxablePay = sqlDataReader.GetDouble(9);
                            employeeModel.IncomeTax = sqlDataReader.GetDouble(10);
                            employeeModel.NetPay = sqlDataReader.GetDouble(11);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5}", employeeModel.ID, employeeModel.Name, employeeModel.BasicPay, employeeModel.StartDate, employeeModel.gender, employeeModel.Phone);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
