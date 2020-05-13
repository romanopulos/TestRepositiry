using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class ByTimeEmployee : Employee
    {
        const decimal Koeff = 20.80M;
        const int WorkingHour = 8;

        public decimal HourSalaryPrice { get; private set; }

        public ByTimeEmployee(decimal hourSalaryPrice, string firstName, string lastName, string employeeId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmployeeId = employeeId;
            this.HourSalaryPrice = hourSalaryPrice;
            CalculateSallary();
        }

        public ByTimeEmployee()
        {

            CalculateSallary();
        }

        protected override void CalculateSallary()
        {
            AverageSalary = CalculateSalary(HourSalaryPrice, WorkingHour);
        }

        private decimal CalculateSalary(decimal hourSalaryPrice, int workingHour) => hourSalaryPrice * Koeff * workingHour;

    }
}
