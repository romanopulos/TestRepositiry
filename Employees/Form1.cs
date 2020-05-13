using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace Employees
{
    public partial class Form1 : Form
    {
        //public List<Employee> employees;
        public static List<Employee> Employees = new List<Employee>();
        private BindingSource bindSource;

        private Action<object, EventArgs> formGrid;
        private Form1AddEdit form1AddEdit;

        struct ExcellSctructure
        {
            public Microsoft.Office.Interop.Excel.Application XlExcel;
            public Microsoft.Office.Interop.Excel.Workbook XlWorkBook;
            public Microsoft.Office.Interop.Excel.Worksheet XlWorkSheet;
            public object MisValue;

            public void SetElements()
            {
                MisValue = System.Reflection.Missing.Value;
                XlExcel = new Microsoft.Office.Interop.Excel.Application();
                XlExcel.Visible = true;
                XlWorkBook = XlExcel.Workbooks.Add(MisValue);
                XlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)XlWorkBook.Worksheets.get_Item(1);
            }


        }

        public Form1()
        {

            InitializeComponent();
            bindSource = new BindingSource();
            bindSource.DataSource = typeof(Employee);
            FillDataSource();
            dataGridView1.DataSource = bindSource;
            dataGridView1.AutoGenerateColumns = true;
            idText.DataBindings.Add("Text", bindSource, "EmployeeId");
            formGrid = async (formsen, eventforargs) =>
            {

                await Task.Factory.StartNew(() =>
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        FillDataSource();
                        dataGridView1.Update();
                        dataGridView1.Refresh();
                    }));

                });
            };

        }

        public static bool CheckIds (string personId)
        {
            if (Employees.Find(zx => zx.EmployeeId == personId) != null)
                return false;
            else
                return true;
        }

        private void FillDataSource() 
        {

            if (bindSource.Count != 0)
                bindSource.Clear();

            //Sort by AverageSalary, then by LastName
            List<Employee> filteredEmployeeList = new List<Employee>(Employees);
            filteredEmployeeList.OrderBy(zx => zx.AverageSalary).ThenBy(xz => xz.LastName);

            if (checkBoxFirst5.Checked)
                filteredEmployeeList = filteredEmployeeList.Take(5).ToList();

            if (checkBoxLast3.Checked)
                filteredEmployeeList = filteredEmployeeList.OrderByDescending(zx => zx.EmployeeId).Take(3).ToList();

            foreach (var bindItem in filteredEmployeeList)
            {
                bindSource.Add(bindItem);
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form1AddEdit.Mode = FormMode.Add;
            form1AddEdit = new Form1AddEdit();
            form1AddEdit.FormClosed += new FormClosedEventHandler(formGrid);
            form1AddEdit.Show();
        }



        private void buttonDelete_Click(object sender, EventArgs e)
        {

            Employees.Remove(Employees.Find(zx => zx.EmployeeId == idText.Text));
            formGrid(sender, e);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            var currentEmployee = Employees.Find(zx => zx.EmployeeId == this.idText.Text);
            Form1AddEdit.CurrentEmployee = currentEmployee;
            if (currentEmployee is FixedTimeEmployee)
                Form1AddEdit.Mode = FormMode.EditFixPrice;
            else
                if (currentEmployee is ByTimeEmployee)
            {
                Form1AddEdit.Mode = FormMode.EditCalcPrice;
            }

            if (currentEmployee != null)
            {
                form1AddEdit = new Form1AddEdit();
                form1AddEdit.FormClosed += new FormClosedEventHandler(formGrid);
                form1AddEdit.Show();
            }
 
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void buttonToFile_Click(object sender, EventArgs e)
        {
            ExportToExcell();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show($"Exception Occured while releasing object {ex.ToString()}" );
            }
            finally
            {
                GC.Collect();
            }
        }



        private void ExportToExcell()
        {
            ExcellSctructure excelStructure = new ExcellSctructure();
            if (dataGridView1.Rows.Count > 0)
            {
                excelStructure.SetElements();
                copyAlltoClipboard();

                for (int x = 1; x < dataGridView1.Columns.Count + 1; x++)
                {
                    excelStructure.XlWorkSheet.Cells[1, x] = dataGridView1.Columns[x - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        excelStructure.XlWorkSheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                var saveFileDialoge = new SaveFileDialog();
                saveFileDialoge.FileName = String.Concat("Result", "Excell import for");
                saveFileDialoge.DefaultExt = ".xlsx";
                if (saveFileDialoge.ShowDialog() == DialogResult.OK)
                {
                    excelStructure.XlWorkSheet.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                excelStructure.XlWorkBook.Close(true, excelStructure.MisValue, excelStructure.MisValue);
                excelStructure.XlExcel.Quit();

                releaseObject(excelStructure.XlWorkSheet);
                releaseObject(excelStructure.XlWorkBook);
                releaseObject(excelStructure.XlExcel);
            }
        }

        private void ImportFromExcell()
        {
            Microsoft.Office.Interop.Excel.Range excellRange;
            ExcellSctructure excelStructure = new ExcellSctructure();
            OpenFileDialog excellImport = new OpenFileDialog();
            DataTable dTable = new DataTable("dataTableExcell");
            DataSet dsSource = new DataSet("dataSetExcell");
            dTable.Reset();
            try
            {
                Employees.Clear();
                excelStructure.SetElements();

                excellImport.Title = "Select file excell";
                excellImport.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
                excellImport.FilterIndex = 1;
                excellImport.RestoreDirectory = true;

                if (excellImport.ShowDialog() == DialogResult.OK)
                {


                    excelStructure.XlWorkBook = excelStructure.XlExcel.Workbooks.Open(excellImport.FileName, excelStructure.MisValue, excelStructure.MisValue,
                        excelStructure.MisValue, excelStructure.MisValue, excelStructure.MisValue, excelStructure.MisValue, excelStructure.MisValue, excelStructure.MisValue,
                        excelStructure.MisValue, excelStructure.MisValue, excelStructure.MisValue, excelStructure.MisValue, excelStructure.MisValue, excelStructure.MisValue);
                    excelStructure.XlWorkSheet = excelStructure.XlWorkBook.Sheets.get_Item(1);
                    excellRange = excelStructure.XlWorkSheet.UsedRange;
                    var employeeProperties = typeof(Employee).GetProperties();
                    var fiedCountEmployee = employeeProperties.Length;
                    var columnCountExcell = excellRange.Columns.Count;

                    List<string> columnList = new List<string>();
                    for (int columnNum = 1; columnNum <= excellRange.Columns.Count; columnNum++)
                    {
                        dTable.Columns.Add(new DataColumn((excellRange.Cells[1, columnNum] as Microsoft.Office.Interop.Excel.Range).Value2.ToString()));
                    }
                    dTable.AcceptChanges();

                    for (int i = 0; i < dTable.Columns.Count; i++)
                    {
                        columnList.Add(dTable.Columns[i].ColumnName) ;
                    }

                    //Check format
                    try
                    {
                        bool wrongFormat = false;

                        wrongFormat = fiedCountEmployee != columnCountExcell;
                        foreach (var item in columnList)
                        {
                            if (employeeProperties.FirstOrDefault(zx => zx.Name == item) == null)
                            {
                                wrongFormat = false;
                                break;
                            }
                        }

                        if (wrongFormat)
                            throw new Exception("We have the wrong format of a file"); ;
                    }
                    catch
                    {
                        throw;
                    }

                    for (int rowNumber = 2; rowNumber <= excellRange.Rows.Count; rowNumber++)
                    {
                        DataRow dRow = dTable.NewRow();
                        for (int columnNumber = 1; columnNumber <= excellRange.Columns.Count; columnNumber++)
                        {
                            if ((excellRange.Cells[rowNumber, columnNumber] as Microsoft.Office.Interop.Excel.Range).Value2 != null)
                            {
                                dRow[columnNumber - 1] = (excellRange.Cells[rowNumber, columnNumber] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                            }
                        }
                        dTable.Rows.Add(dRow);
                        dTable.AcceptChanges();
                    }
                    excelStructure.XlWorkBook.Close(true, excelStructure.MisValue, excelStructure.MisValue);
                    excelStructure.XlExcel.Quit();
                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        var tableRow = dTable.Rows[i];
                        FixedTimeEmployee fixT = new FixedTimeEmployee();
                        for (int j = 0; j < tableRow.ItemArray.Length; j++)
                        {
                            var currentValue = tableRow.ItemArray[j];
                            var columnNAme = columnList[j];
 
                            if (employeeProperties.FirstOrDefault(zx => zx.Name == columnNAme).GetValue(fixT) is decimal)
                                employeeProperties.FirstOrDefault(zx => zx.Name == columnNAme).SetValue(fixT, Decimal.Parse(currentValue.ToString()));
                            else
                                employeeProperties.FirstOrDefault(zx => zx.Name == columnNAme).SetValue(fixT, currentValue);

                        }
                        Employees.Add(fixT);
                    }

                }
                else
                {
                    releaseObject(excellImport);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                releaseObject(excelStructure.XlWorkSheet);
                releaseObject(excelStructure.XlWorkBook);
                releaseObject(excelStructure.XlExcel);
                releaseObject(excellImport);
            }

        }

        private void DataGridFilterChanged(object sender, EventArgs e)
        {

            if (sender is System.Windows.Forms.CheckBox)
                formGrid(sender, e);
        }

        private void buttonFromFile_Click(object sender, EventArgs e)
        {
            ImportFromExcell();
            formGrid(sender, e);
        }
    }
}
