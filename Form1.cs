using ClosedXML.Excel;
using CsvHelper;

namespace CourseWorkManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // global variables
        int count = 0;
        bool TrimedListHeader = false;
        public List<string> listNewlyAddedStudents = new List<string>();   // create a new list with variable name "listNewlyAddedStudents"

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
            System.Data.DataTable StudentGroupTable = new System.Data.DataTable();
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
            int StudentGroupTable_GroupID = 1;
            int StudentGroupTable_RowCount = 0;

            // create a new list to hold the student details with their new groups
            List<string[]> StudentGroupTable_ListCollection = new List<string[]>();

            // loop through each "listNewlyAddedStudents" and add them to DataTable row
            for (var i = 0; i <= listNewlyAddedStudents.Count; i++)
            {

                // this ensures that four items are added to a row at once. it adds items by batch
                if (lap > 4)
                {
                    lap = 1;
                    StudentGroupTable_SerialNumber++;
                    // assign each list index to a cell in the row
                    StudentGroupTable_ListCollection.Add(new string[] { StudentGroupTable_SerialNumber.ToString(), listNewlyAddedStudents[Index1], listNewlyAddedStudents[Index2], listNewlyAddedStudents[Index3], listNewlyAddedStudents[Index4], StudentGroupTable_GroupID.ToString() });
                    StudentGroupTable.Rows.Add(StudentGroupTable_SerialNumber.ToString(), listNewlyAddedStudents[Index1], listNewlyAddedStudents[Index2], listNewlyAddedStudents[Index3], listNewlyAddedStudents[Index4], StudentGroupTable_GroupID.ToString());
                    // go to the next items on the list that needs to be added to Datatable row
                    Index1 += 4;
                    Index2 += 4;
                    Index3 += 4;
                    Index4 += 4;

                    // this handles the assigning Students with Group IDs
                    StudentGroupTable_RowCount++;
                    if (StudentGroupTable_RowCount == 4)
                    {
                        StudentGroupTable_RowCount = 0;
                        StudentGroupTable_GroupID++;
                    }
                }
                lap++;
            }
            // display the list item in "dataGridViewListItems"
            dgvStudentGroupingTable.DataSource = StudentGroupTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnManageGroups_Click(object sender, EventArgs e)
        {
        }

        private void btnViewGroups_Click(object sender, EventArgs e)
        {
        }

        private void btnManageGroupsMark_Click(object sender, EventArgs e)
        {
        }

        private void btnSavedData_Click(object sender, EventArgs e)
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
    }
}