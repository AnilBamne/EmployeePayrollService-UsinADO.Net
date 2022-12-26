using System;

namespace EmployeePayrollUsingADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employrr Payroll Service Using ADO.Net");
            //uc1 check connection
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.CheckConnection();

            //uc2 retrive all data from DB
            employeeRepository.GetAllEmployee();

            //uc3 add data to DB
            EmployeeModel employeeModel = new EmployeeModel();
            // not initializing ID becayse id is in auto increament and Address is default
            employeeModel.Name = "Nandini";
            employeeModel.BasicPay = 20700;
            employeeModel.gender = "F";
            employeeModel.Phone = 3453160;
            employeeModel.Department = "HR";
            employeeModel.Deductions = 1080;
            employeeModel.TaxablePay = 19070;
            employeeModel.IncomeTax = 734;
            employeeModel.NetPay = 18435;
            employeeRepository.AddEmployee(employeeModel);
        }
    }
}
