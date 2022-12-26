using System;
using System.Collections.Generic;
using System.Data;
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
            catch (Exception ex)
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
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", employeeModel.ID, employeeModel.Name, employeeModel.BasicPay, 
                                employeeModel.StartDate, employeeModel.gender, employeeModel.Phone,employeeModel.Department,employeeModel.Address,employeeModel.Deductions
                                ,employeeModel.TaxablePay,employeeModel.IncomeTax,employeeModel.NetPay);
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

        /// <summary>
        /// Adding data to DB and usig StoredProcedure AddEmployee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <exception cref="Exception"></exception>
        public void AddEmployee(EmployeeModel employeeModel)
        {
            SqlConnection connection = null;
            try
            {
                using (connection=new SqlConnection(connectionString))
                {
                    // not initializing ID becayse id is in auto increament and Address is default
                    SqlCommand cmd = new SqlCommand("AddEmployee", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                    cmd.Parameters.AddWithValue("@Phone", employeeModel.Phone);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@gender", employeeModel.gender);
                    cmd.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                    cmd.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    cmd.Parameters.AddWithValue("@TaxablePay", employeeModel.TaxablePay);
                    cmd.Parameters.AddWithValue("@IncomeTax", employeeModel.IncomeTax);
                    cmd.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Added succesfully");
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Get Salary Data From  Perticular Employee
        /// </summary>
        public void GetSalaryDataFromPerticularEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select Name,BasicPay from EmployeePayroll where ID = 3;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.Name = sqlDataReader.GetString(0);
                            employeeModel.BasicPay = sqlDataReader.GetDouble(1);
                            Console.WriteLine($"For ID=3 the employee name is:{employeeModel.Name} and Salary is :{employeeModel.BasicPay}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    this.connection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// GetPerticularEmployeeBetweenDates
        /// </summary>
        public void GetPerticularEmployeeBetweenDates()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select * from EmployeePayroll where StartDate between CAST('2020-01-01' as date) AND CAST('2022-12-01' as date);";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
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
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", employeeModel.ID, employeeModel.Name, employeeModel.BasicPay,
                                employeeModel.StartDate, employeeModel.gender, employeeModel.Phone, employeeModel.Department, employeeModel.Address, employeeModel.Deductions
                                , employeeModel.TaxablePay, employeeModel.IncomeTax, employeeModel.NetPay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
