using ClosedXML.Excel;
using CsvHelper;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWorkManagementSystem
{
    public partial class ManageStudents : UserControl
    {
        public ManageStudents()
        {
            InitializeComponent();
        }

        // global variables
        int count = 0;
        List<string> listNewlyAddedStudents = new List<string>();   // create a new list with variable name "listNewlyAddedStudents"

        // this method updates the "dataGridViewListItems"
        public void DataGridUpdate()
        {
            // prepare "DataTable dt" which will be used as DataSource for "dataGridViewListItems"
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("studentIDnumber", typeof(string));
            dt.Columns.Add("firstName", typeof(string));
            dt.Columns.Add("lastName", typeof(string));
            dt.Columns.Add("emailAddress", typeof(string));

            // variable diclarations
            var lap = 1;
            var Index1 = 0;
            var Index2 = 1;
            var Index3 = 2;
            var Index4 = 3;

            // remove the first row of the list
            if (count == 0)
            {
                listNewlyAddedStudents.RemoveAt(0);
                listNewlyAddedStudents.RemoveAt(0);
                listNewlyAddedStudents.RemoveAt(0);
                listNewlyAddedStudents.RemoveAt(0);
                count = 1;
            }

            // loop through each "listNewlyAddedStudents" and add them to DataTable row
            for (var i = 0; i <= listNewlyAddedStudents.Count; i++)
            {
                // this ensures that four items are added to a row at once. it adds items by batch
                if (lap > 4)
                {
                    lap = 1;
                    // assign each list index to a cell in the row
                    dt.Rows.Add(listNewlyAddedStudents[Index1], listNewlyAddedStudents[Index2], listNewlyAddedStudents[Index3], listNewlyAddedStudents[Index4]);
                    // go to the next items on the list that needs to be added to Datatable row
                    Index1 += 4;
                    Index2 += 4;
                    Index3 += 4;
                    Index4 += 4;
                }
                lap++;
            }
            // display the list item in "dataGridViewListItems"
            dataGridViewListItems.DataSource = dt;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "CSV|*csv", ValidateNames = true })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using(var sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        var writer = new CsvWriter(sw);
                        writer.WriteHeader(typeof(Student));
                        // var item in values
                        foreach (Student s in studentBindingSource.DataSource as List<Student>)
                        //foreach (DataColumn dc in dt.Columns)
                        {
                            writer.WriteRecord(s);
                        }
                        MessageBox.Show("Your data has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void dgvCsvImport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // reset all form data by making them empty
            txtStudentIDnumber.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // switch the to the relevant DataGridView
            dataGridViewListItems.Visible = true;
            dgvCsvImport.Visible = false;
            // get all form data and put them into a variable
            var StudentIDnumber = txtStudentIDnumber.Text;
            var FirstName = txtFirstName.Text;
            var LastName = txtLastName.Text;
            var EmailAddress = txtEmailAddress.Text;

            // add item to list
            listNewlyAddedStudents.Add(StudentIDnumber);
            listNewlyAddedStudents.Add(FirstName);
            listNewlyAddedStudents.Add(LastName);
            listNewlyAddedStudents.Add(EmailAddress);

            // update the DataGridView
            DataGridUpdate();

            // display the number of students
            lblNumberOfStudent.Text = (listNewlyAddedStudents.Count / 4).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            // reset all form data by making them empty
            txtStudentIDnumber.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;

            // display the number of students
            lblNumberOfStudent.Text = "...";
        }

        private void studentBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnImportNewCSV_Click(object sender, EventArgs e)
        {
            // switch the to the relevant DataGridView
            dataGridViewListItems.Visible = false;
            dgvCsvImport.Visible = true;
            if ( dgvCsvImport != null || dgvCsvImport.Rows.Count == 0 )
            {
                MessageBox.Show("Table is not empty. Do you want to overight table?", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else
            {

            }
            // open the file dialog and choose the .csv file
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "CSV|*csv", ValidateNames = true })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = Path.GetFullPath(openFileDialog.FileName);
                    using (var sr = new StreamReader(new FileStream(openFileDialog.FileName, FileMode.Open)))
                    {
                        var csv = new CsvReader(sr);
                        // use the choosen .csv file as DataSource for "studentBindingSource" and display it
                        studentBindingSource.DataSource = csv.GetRecords<Student>();
                    }
                    // display the filepath above datagGidView
                    lblFilePath.Text = filePath;
                    StreamReader reader = null;
                    // check if file exists before proceeding
                    if (File.Exists(filePath))
                    {
                        reader = new StreamReader(File.OpenRead(filePath));
                        // split all values and add them to "listNewlyAddedStudents" List
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            // loop through each item in the List
                            foreach (var item in values)
                            {
                                // add new item to the list
                                listNewlyAddedStudents.Add(item);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File doesn't exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // display the number of students
            lblNumberOfStudent.Text = ((listNewlyAddedStudents.Count / 4) - 1).ToString();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            listNewlyAddedStudents.RemoveAt(listNewlyAddedStudents.Count - 1);
            listNewlyAddedStudents.RemoveAt(listNewlyAddedStudents.Count - 1);
            listNewlyAddedStudents.RemoveAt(listNewlyAddedStudents.Count - 1);
            listNewlyAddedStudents.RemoveAt(listNewlyAddedStudents.Count - 1);

            // update the DataGridView
            DataGridUpdate();
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            // prepare "DataTable dt" which will be used as DataSource for "dataGridViewListItems"
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("studentIDnumber", typeof(string));
            dt.Columns.Add("firstName", typeof(string));
            dt.Columns.Add("lastName", typeof(string));
            dt.Columns.Add("emailAddress", typeof(string));

            // variable diclarations
            var lap = 1;
            var Index1 = 0;
            var Index2 = 1;
            var Index3 = 2;
            var Index4 = 3;

            // remove the first row of the list
            if (count == 0)
            {
                listNewlyAddedStudents.RemoveAt(0);
                listNewlyAddedStudents.RemoveAt(0);
                listNewlyAddedStudents.RemoveAt(0);
                listNewlyAddedStudents.RemoveAt(0);
                count = 1;
            }

            // loop through each "listNewlyAddedStudents" and add them to DataTable row
            for (var i = 0; i <= listNewlyAddedStudents.Count; i++)
            {
                // this ensures that four items are added to a row at once. it adds items by batch
                if (lap > 4)
                {
                    lap = 1;
                    // assign each list index to a cell in the row
                    dt.Rows.Add(listNewlyAddedStudents[Index1], listNewlyAddedStudents[Index2], listNewlyAddedStudents[Index3], listNewlyAddedStudents[Index4]);
                    // go to the next items on the list that needs to be added to Datatable row
                    Index1 += 4;
                    Index2 += 4;
                    Index3 += 4;
                    Index4 += 4;
                }
                lap++;
            }
            using (SaveFileDialog sfd=new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" }) 
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using(XLWorkbook workbook= new XLWorkbook())
                        {
                            workbook.Worksheets.Add(dt, "Students");
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("File successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    public class Countries
    {
        public string? studentIDnumber { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? emailAddress { get; set; }
    }

}
