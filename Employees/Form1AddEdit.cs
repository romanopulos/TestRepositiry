using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees
{
    public enum FormMode
    {
        Add = 1,
        EditFixPrice = 2,
        EditCalcPrice = 3
    }
    public partial class Form1AddEdit : Form
    {
        private RadioButton selectedRb;
        public static FormMode Mode { get; set; }
        public static Employee CurrentEmployee { get; set; }
        private readonly string initialId;
        public Form1AddEdit()
        {

            InitializeComponent();

 
            if (Mode == FormMode.Add || Mode == FormMode.EditFixPrice)
            {
                fixedPriceButton.Checked = true;
                bytimeButton.Checked = false;
            }

            else
            {
                fixedPriceButton.Checked = false;
                bytimeButton.Checked = true;
            }

            if (Mode == FormMode.EditCalcPrice || Mode == FormMode.EditFixPrice)
                FillTextBoxes(CurrentEmployee);
            initialId = this.Id.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

            Close();
        }

        public void FillTextBoxes(Employee employeEdited)
        {
            this.FirstName.Text = employeEdited.FirstName;
            this.LastName.Text = employeEdited.LastName;
            this.Id.Text = employeEdited.EmployeeId;
            if (employeEdited is ByTimeEmployee)
            {
                var byHourEmployee = employeEdited as ByTimeEmployee;
                this.labelId.Text = "Hourly salary";
                this.Salary.Text = byHourEmployee.HourSalaryPrice.ToString();
            }
            else
                if (employeEdited is FixedTimeEmployee)
            {
                var byFixedTimeEmployee = employeEdited as FixedTimeEmployee;
                this.labelId.Text = "Hourly salary";
                this.Salary.Text = byFixedTimeEmployee.FixedTimeEmployeeSalary.ToString();
            }

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var checkResult = Form1.CheckIds(this.Id.Text);
            if (!checkResult)
                MessageBox.Show("Id already exists in the collection");
            if (Mode == FormMode.Add && checkResult)
            {
                if (fixedPriceButton.Checked)
                    Form1.Employees.Add(new FixedTimeEmployee(ConvertToDecimal(this.Salary.Text)) { FirstName = this.FirstName.Text, LastName = this.LastName.Text, EmployeeId = this.Id.Text });
                else                
                    Form1.Employees.Add(new ByTimeEmployee(ConvertToDecimal(this.Salary.Text), this.FirstName.Text, this.LastName.Text, this.Id.Text));                
            }
            else
                if (checkResult && (Mode == FormMode.EditFixPrice || Mode == FormMode.EditCalcPrice))
            {
                var employeeToFind = Form1.Employees.Find(zx => zx.EmployeeId == initialId);
                employeeToFind.EmployeeId = this.Id.Text;
                employeeToFind.FirstName = this.FirstName.Text;
                employeeToFind.LastName = this.LastName.Text;

                /*
                 Check all states
                 */
                EditPerson(Mode, employeeToFind, Form1.Employees);
            }
            Close();
        }

        private void EditPerson(FormMode formMode, Employee person, List<Employee> personList)
        {
            Employee newPerson;
            var indexToFind = personList.IndexOf(person);
            if (formMode == FormMode.EditFixPrice)
            {
                newPerson = new FixedTimeEmployee(ConvertToDecimal(this.Salary.Text))
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    EmployeeId = person.EmployeeId
                };
                personList[indexToFind] = newPerson;
            }
            else
                if (formMode == FormMode.EditCalcPrice)
            {
                newPerson = new ByTimeEmployee(ConvertToDecimal(this.Salary.Text), person.FirstName, person.LastName,
                    person.EmployeeId);
                personList[indexToFind] = newPerson;
            }
        }

        private decimal ConvertToDecimal(string salaryText)
        {

            var salary = 0.00M;
            try
            {
                salary = Convert.ToDecimal(salaryText, new CultureInfo("en-US"));
            }
            catch (FormatException)
            {

                throw;
            }
            return salary;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                selectedRb = rb;
                if (selectedRb == fixedPriceButton)
                {
                    bytimeButton.Checked = false;
                    if (Mode != FormMode.Add)
                        Mode = FormMode.EditFixPrice;
                }

                else
                    if (selectedRb == bytimeButton)
                {
                    fixedPriceButton.Checked = false;
                    if (Mode != FormMode.Add)
                        Mode = FormMode.EditCalcPrice;
                }

            }
        }
    }
}
