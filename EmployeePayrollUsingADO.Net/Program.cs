using System;

namespace EmployeePayrollUsingADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employrr Payroll Service Using ADO.Net");
            Console.WriteLine("Choose option \n1 Check connection\n2 Retrive data from DB\n3 Add data to DB\n4 Retrive data after insertion");
            EmployeeRepository employeeRepository = new EmployeeRepository();
            int option=int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    //uc1 check connection
                    employeeRepository.CheckConnection();
                    break;
                case 2:
                    //uc2 retrive all data from DB
                    employeeRepository.GetAllEmployee();
                    break;
                case 3:
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
                    break;
                case 4:
                    //uc4 retrive data after insertion DB
                    employeeRepository.GetAllEmployee();
                    break;

            }
            

            

            


        }
    }
}
