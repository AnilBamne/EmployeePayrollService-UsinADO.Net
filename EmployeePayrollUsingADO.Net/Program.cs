using System;

namespace EmployeePayrollUsingADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employrr Payroll Service Using ADO.Net");

            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.CheckConnection();
        }
    }
}
