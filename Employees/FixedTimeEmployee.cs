using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class FixedTimeEmployee : Employee
    {
        public decimal FixedTimeEmployeeSalary{ get;private set; }
        public FixedTimeEmployee(decimal fixedSum)
        {
            this.FixedTimeEmployeeSalary = fixedSum;
            CalculateSallary();
        }

        public FixedTimeEmployee()
        {
                
        }

        protected override void CalculateSallary() => this.AverageSalary = FixedTimeEmployeeSalary;
        
    }
}
