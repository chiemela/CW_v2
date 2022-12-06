using ClosedXML.Excel;
using CsvHelper;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Windows.Forms;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace CourseWorkManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // global variables
        int Final_StudentGroupTable_GroupID_Value;
        int StudentGroupTable_GroupID = 1;
        bool TrimedListHeader = false;
        public List<string> listNewlyAddedStudents = new List<string>();   // create a new list with variable name "listNewlyAddedStudents"
        public List<string> ListStudentsGrouping = new List<string>();   // create a new list with variable name "ListStudentsGrouping"
        public System.Data.DataTable StudentGroupTable = new System.Data.DataTable();
        // create a new list to hold the student details with their new groups
        public List<string> StudentGroupTable_ListCollection = new List<string>();

        // update "comboBoxChangeGroupID"
        public void UpdateComboBoxChangeGroupID()
        {
            comboBoxChangeGroupID.Items.Clear();
            // Adding elements in the combobox
            for (int i = 1; i <= StudentGroupTable_GroupID; i++)
            {
                comboBoxChangeGroupID.Items.Add(i);
            }
        }

        // check if the "listNewlyAddedStudents" header is trimmed or not
        public void CheckTrimedListHeader(bool t)
        {
            // remove the first row of the list
            if (t == false)
            {
                listNewlyAddedStudents.RemoveAt(0);
                listNewlyAddedStudents.RemoveAt(0);
                listNewlyAddedStudents.RemoveAt(0);
                listNewlyAddedStudents.RemoveAt(0);
                TrimedListHeader = true;
            }
        }

        // this method  the "dataGridViewListItems"
        public void ImportStudentGroupingTable()
        {
            // variable diclarations
            string ListDetails = "";

            // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
            CheckTrimedListHeader(TrimedListHeader);

            // add the "StudentGroupTable" data to list
            foreach (DataRow dr in StudentGroupTable.Rows)
            {
                foreach (DataColumn col in StudentGroupTable.Columns)
                {
                    ListDetails += dr[col] + " ";
                    string? v = dr[col].ToString();
                    string TempString = v;
                    StudentGroupTable_ListCollection.Add(TempString);
                }
                ListStudentsGrouping.Add(ListDetails);
                ListDetails = "";
            }
            // display the list item in "listBoxViewStudentGrouping"
            listBoxViewStudentGrouping.DataSource = ListStudentsGrouping;
        }

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

            // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
            CheckTrimedListHeader(TrimedListHeader);

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

        // this method creates the DataTable columns automatically assigns student to a group
        public void AutoAssignStudentToGrouping()
        {
            // prepare "DataTable StudentGroupTable" which will be used as DataSource for "dgvStudentGroupingTable"
            
            StudentGroupTable.Columns.Add("S/N", typeof(string));
            StudentGroupTable.Columns.Add("Student ID", typeof(string));
            StudentGroupTable.Columns.Add("FirstName", typeof(string));
            StudentGroupTable.Columns.Add("LastName", typeof(string));
            StudentGroupTable.Columns.Add("Email Address", typeof(string));
            StudentGroupTable.Columns.Add("Group ID", typeof(string));

            // variable diclarations
            var lap = 1;
            var Index1 = 0;
            var Index2 = 1;
            var Index3 = 2;
            var Index4 = 3;
            int StudentGroupTable_SerialNumber = 0;
            int StudentGroupTable_RowCount = 1;
            StudentGroupTable_GroupID = 1;

            // loop through each "listNewlyAddedStudents" and add them to DataTable row
            for (var i = 0; i <= listNewlyAddedStudents.Count; i++)
            {

                // this ensures that four items are added to a row at once. it adds items by batch
                if (lap > 4)
                {
                    lap = 1;
                    StudentGroupTable_SerialNumber++;
                    // this handles the assigning Students with Group IDs
                    if (StudentGroupTable_RowCount > 4)
                    {
                        StudentGroupTable_RowCount = 1;
                        StudentGroupTable_GroupID++;
                    }
                    // assign each list index to a cell in the row
                    /*
                    StudentGroupTable_ListCollection.Add(StudentGroupTable_SerialNumber.ToString());
                    StudentGroupTable_ListCollection.Add(listNewlyAddedStudents[Index1]);
                    StudentGroupTable_ListCollection.Add(listNewlyAddedStudents[Index2]);
                    StudentGroupTable_ListCollection.Add(listNewlyAddedStudents[Index3]);
                    StudentGroupTable_ListCollection.Add(listNewlyAddedStudents[Index4]);
                    StudentGroupTable_ListCollection.Add(StudentGroupTable_GroupID.ToString());
                    */
                    StudentGroupTable.Rows.Add(
                        StudentGroupTable_SerialNumber.ToString(), 
                        listNewlyAddedStudents[Index1], 
                        listNewlyAddedStudents[Index2], 
                        listNewlyAddedStudents[Index3], 
                        listNewlyAddedStudents[Index4], 
                        StudentGroupTable_GroupID.ToString()
                        );
                    // go to the next items on the list that needs to be added to Datatable row
                    Index1 += 4;
                    Index2 += 4;
                    Index3 += 4;
                    Index4 += 4;

                    StudentGroupTable_RowCount++;
                }
                lap++;
            }
            // this is the base "StudentGroupTable_GroupID" value
            Final_StudentGroupTable_GroupID_Value = StudentGroupTable_GroupID;
            // Adding elements in the combobox
            UpdateComboBoxChangeGroupID();
            // display the list item in "dataGridViewListItems"
            dgvStudentGroupingTable.DataSource = StudentGroupTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnImportNewCSV_Click(object sender, EventArgs e)
        {

            // switch the to the relevant DataGridView
            dataGridViewListItems.Visible = false;
            dgvCsvImport.Visible = true;

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
                    // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                    CheckTrimedListHeader(TrimedListHeader);
                }
                else
                {
                    MessageBox.Show("File doesn't exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // display the number of students
            lblNumberOfStudent.Text = ((listNewlyAddedStudents.Count / 4) - 1).ToString();

            // group students automatically
            AutoAssignStudentToGrouping();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
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

            // group students automatically
            AutoAssignStudentToGrouping();

            // display the number of students
            lblNumberOfStudent.Text = (listNewlyAddedStudents.Count / 4).ToString();
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

            // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
            CheckTrimedListHeader(TrimedListHeader);

            // update list to the global list variable
            // StoreStudentList();

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
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(dt, "Students");
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("File successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tabPageManageGroups_Click(object sender, EventArgs e)
        {
        }

        private void btnSaveGroupingTable_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = false;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dgvStudentGroupingTable.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgvStudentGroupingTable.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgvStudentGroupingTable.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvStudentGroupingTable.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgvStudentGroupingTable.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save as csv file
            if (dgvStudentGroupingTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dgvStudentGroupingTable.Columns.Count;
                            string columnNames = "";
                            string columnNames2 = "";
                            string[] outputCsv = new string[dgvStudentGroupingTable.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgvStudentGroupingTable.Columns[i].HeaderText.ToString() + ",";
                                columnNames2 = dgvStudentGroupingTable.Columns[i].HeaderText.ToString() + ",";
                                StudentGroupTable_ListCollection.Add(columnNames2);
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; i < dgvStudentGroupingTable.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    worksheet.Cells[i, j] = dgvStudentGroupingTable.Rows[i - 1].Cells[j].Value.ToString();
                                    //outputCsv[i] += dgvStudentGroupingTable.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                    // columnNames2 = worksheet.Cells[i].ToString();
                                    columnNames2 = worksheet.Cells[i].Cells[j].Value.ToString();
                                    StudentGroupTable_ListCollection.Add(columnNames2 + ",");
                                }
                            }

                            File.WriteAllLines(sfd.FileName, StudentGroupTable_ListCollection, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void btnImportStudentGroupingTable_Click(object sender, EventArgs e)
        {
            // listNewlyAddedStudents, ListStudentsGrouping
            ImportStudentGroupingTable();
        }

        private void btnChooseStudent_Click(object sender, EventArgs e)
        {
            // lblCurrentGroupID
            lblSelectedStudent.Text = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedItem);
            int GroupID_Column = 5;
            string? d = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedIndex);
            var number = int.Parse(d);
            // increment "number" to jump to the appropriate column in the row
            number++;
            // get the appropriate column index in the "StudentGroupTable_ListCollection"
            int s = GroupID_Column * number;
            /* 
             * get the appropriate column index for each column in the "StudentGroupTable_ListCollection"
             * and without this, when you select from the second column in the list it always gets the previous
             * value
            */
            s += --number;
            lblCurrentGroupID.Text = StudentGroupTable_ListCollection[s];
        }

        private void comboBoxChangeGroupID_SelectedValueChanged(object sender, EventArgs e)
        {
            // start from here...
            // make the selected group to change for the sutdent for both the Listbox and the Datatable
            object b = comboBoxChangeGroupID.SelectedItem;
            object be = comboBoxChangeGroupID.GetItemText(b);
            labelChangeGroupIDFeedback.Text = "You've selected " + be;
        }

        private void btnApplyChangeGroupID_Click(object sender, EventArgs e)
        {

        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            StudentGroupTable_GroupID++;
            UpdateComboBoxChangeGroupID();
            labelAddOrMinusGroupFeedback.Text = "You have " + StudentGroupTable_GroupID + " Group(s)";
        }

        private void btnMinusGroup_Click(object sender, EventArgs e)
        {
            if (StudentGroupTable_GroupID > Final_StudentGroupTable_GroupID_Value)
            {
                --StudentGroupTable_GroupID;
                labelAddOrMinusGroupFeedback.Text = "You have " + StudentGroupTable_GroupID + " Group(s)";
            }
            else
            {
                MessageBox.Show("Sorry you cannot go below " + Final_StudentGroupTable_GroupID_Value + " Group(s)", "Info");
                labelAddOrMinusGroupFeedback.Text = "You have " + StudentGroupTable_GroupID + " Group(s)";
            }
            UpdateComboBoxChangeGroupID();
        }
    }
}