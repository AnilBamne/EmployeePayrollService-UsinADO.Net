using System;

namespace EmployeePayrollUsingADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employrr Payroll Service Using ADO.Net");
            //uc1
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.CheckConnection();

            //uc2
            employeeRepository.GetAllEmployee();
        }
    }
}
