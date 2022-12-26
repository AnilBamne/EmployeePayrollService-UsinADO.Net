using System;

namespace EmployeePayrollUsingADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employrr Payroll Service Using ADO.Net");
            while (true)
            {
                Console.WriteLine("Choose option \n1 Check connection\n2 Retrive data from DB\n3 Add data to DB\n4 Retrive data after insertion\n5 GetSalaryDataFromPerticularEmployee\n6 GetPerticularEmployeeBetweenDates" +
                    "\n7 GetSumOfSalary group by gender \n8 GetMaxSalary group by gender\n9 Get Min Salary group by gender\n10 Get Avg Salary group by gender\n12 Exit");
                EmployeeRepository employeeRepository = new EmployeeRepository();
                int option = int.Parse(Console.ReadLine());
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
                    case 5:
                        //uc5 Get Salary Data From  Perticular Employee
                        employeeRepository.GetSalaryDataFromPerticularEmployee();
                        break;
                    case 6:
                        //uc6 GetPerticularEmployeeBetweenDates
                        employeeRepository.GetPerticularEmployeeBetweenDates();
                        break;
                    case 7:
                        //uc7 Aggrigate function SUM
                        employeeRepository.GetSumOfSalary();
                        break;
                    case 8:
                        //Get MAX Salary Group By Gender
                        employeeRepository.GetMaxSalaryGroupByGender();
                        break;
                    case 9:
                        //Get MIN Salary Group By Gender
                        employeeRepository.GetMinSalaryGroupByGender();
                        break;
                    case 10:
                        //Get AVG Salary Group By Gender
                        employeeRepository.GetAvgSalaryGroupByGender();
                        break;
                    case 11:
                        break;
                    case 12:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
