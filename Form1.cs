﻿using ClosedXML.Excel;
using CsvHelper;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ClosedXML.Excel.XLPredefinedFormat;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;



namespace CourseWorkManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // global variables
        bool IsImportGroupScore_Clicked = false;
        bool CheckedResult_TotalScoreGiven = false;
        int InitialGroupUpdateRecord = 0;
        string? SerialNumber_By_ID = "";
        string? StudentID_By_ID = "";
        string? FirstName_By_ID = "";
        string? LastName_By_ID = "";
        string? Email_By_ID = "";
        string? Group_By_ID = "";
        string? Grade_By_ID = "";
        int fetchedStudentID = 0;
        static int StudentGroupTable_Count = 1;
        int SerialNumber = 1;
        int Check_If_Clicked = 0;
        int Get_Num_Array_Count;
        int MGS_GetFirstName_Column;
        int MGS_GetLastName_Column;
        bool btnIsStudentChosen = false;
        int ApprColumnIndex;
        int Final_StudentGroupTable_GroupID_Value;
        int StudentGroupTable_GroupID = 1;
        bool TrimedListHeader = false;
        public List<string> listNewlyAddedStudents = new List<string>();   // create a new list with variable name "listNewlyAddedStudents"
        public List<string> ListStudentsGrouping = new List<string>();   // create a new list with variable name "ListStudentsGrouping"
        public System.Data.DataTable StudentGroupTable = new System.Data.DataTable();
        // create a new list to hold the student details with their new groups
        public List<string> StudentGroupTable_ListCollection = new List<string>();
        public List<string> ManageScoreStudentList = new List<string>();    // this allows to save students groups with grades
        public string[,] array_StudentGroupTable_Count; // this array will store students data at the "Manage scores" section
        public List<string> ManageGroupScore_SavingList = new List<string>();   // this list will hold the data abot to be saved to Excel

        // initial array
        public void InitiateStudentArray()
        {
            array_StudentGroupTable_Count = new string[StudentGroupTable_Count, 7];
        }


        // this regular expression checks the characters in the email field to know if it matches the email format
        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }


        // this initializes the regular expression method email_validation()
        static Regex validate_emailaddress = email_validation();


        // this is responsible for stopping user from exceeding the 90% score for each group
        public void CheckTotalScore()
        {

            try
            {

                CheckedResult_TotalScoreGiven = false;
                int count = 1;
                int CalculateTotalScoreGivenInEachGroup = 0;

                // this gets the total score for each group and displays it
                for (int f = 0; f < array_StudentGroupTable_Count.Length; f++)
                {

                    if (count <= 12)
                    {

                        if (array_StudentGroupTable_Count[f, 5] == Group_By_ID)
                        {

                            string TempGrade = array_StudentGroupTable_Count[f, 6];

                            try
                            {

                                int result = Int32.Parse(TempGrade);
                                CalculateTotalScoreGivenInEachGroup += result;

                            }
                            catch (FormatException)
                            {

                                MessageBox.Show($"Unable to parse '{TempGrade}'", "Info");

                            }

                        }

                        ++count;

                    }

                }

                if (CalculateTotalScoreGivenInEachGroup > 100)
                {

                    CheckedResult_TotalScoreGiven = true;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }


        // this gets the total score for each group and displays it for the user
        public void DisplayTotalGiveScore()
        {

            try
            {

                // this gets the total score for each group and displays it for the user
                int count = 1;
                int CalculateTotalScoreGivenInEachGroup = 0;
                int rows = array_StudentGroupTable_Count.GetUpperBound(0) - array_StudentGroupTable_Count.GetLowerBound(0) + 1;

                for (int f = 0; f < array_StudentGroupTable_Count.Length; f++)
                {

                    if (count <= rows)
                    {

                        if (array_StudentGroupTable_Count[f, 5] == Group_By_ID)
                        {

                            string TempGrade = array_StudentGroupTable_Count[f, 6];

                            try
                            {

                                int result = Int32.Parse(TempGrade);
                                CalculateTotalScoreGivenInEachGroup += result;

                            }
                            catch (FormatException)
                            {

                                MessageBox.Show($"Unable to parse '{TempGrade}'", "Info");

                            }

                        }

                        ++count;

                    }

                }

                labelMGS_TotalScoreGiven.Text = CalculateTotalScoreGivenInEachGroup.ToString() + "%";

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        

        // this checks how many times a groupID appears
        public static int CountOccurrences(int[] arr, int n, int x)
        {

            int res = 0;

            for (int i = 0; i < n; i++)
                if (x == arr[i])
                    res++;

            return res;

        }

        // update "comboBoxChangeGroupID"
        public void UpdateComboBoxChangeGroupID()
        {
            comboBoxChangeGroupID.Items.Clear();
            comboBoxChooseGroup.Items.Clear();
            comboBoxMGS_ChooseGroup.Items.Clear();

            // Adding elements in the combobox
            for (int i = 1; i <= StudentGroupTable_GroupID; i++)
            {

                comboBoxChangeGroupID.Items.Add(i);
                comboBoxChooseGroup.Items.Add(i);
                comboBoxMGS_ChooseGroup.Items.Add(i);

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

        /* 
         * this method imports the "dataGridViewListItems" to "listBoxViewStudentGrouping" and adds student details to list
         * "StudentGroupTable_ListCollection"
        */
        public void ImportStudentGroupingTable()
        {

            try
            {

                // variable diclarations
                string ListDetails = "";

                // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                CheckTrimedListHeader(TrimedListHeader);

                // add the "StudentGroupTable" data to list "StudentGroupTable_ListCollection"
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
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        // this method updates the "dataGridViewListItems"
        public void DataGridUpdate()
        {

            try
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
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        // this method creates the DataTable columns automatically assigns student to a group
        public void AutoAssignStudentToGrouping(int argument)
        {

            try
            {

                // this checks if there are items in the DataTable already
                if (argument > 1)
                {

                    StudentGroupTable.Columns.Remove("S/N");
                    StudentGroupTable.Columns.Remove("Student ID");
                    StudentGroupTable.Columns.Remove("FirstName");
                    StudentGroupTable.Columns.Remove("LastName");
                    StudentGroupTable.Columns.Remove("Email Address");
                    StudentGroupTable.Columns.Remove("Group ID");

                }

                StudentGroupTable.Clear();  // clear the current data to make room for new data
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
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // this imports new csv file into the program
        private void btnImportNewCSV_Click(object sender, EventArgs e)
        {

            try
            {

                // switch the to the relevant DataGridView
                dataGridViewListItems.Visible = false;
                dgvCsvImport.Visible = true;

                // open the file dialog and choose the .csv file
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "CSV|*csv", ValidateNames = true })
                {

                    // check if it exists and is selected
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        // this gets the file location in the computer
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
                lblNumberOfStudent.Text = (listNewlyAddedStudents.Count / 4).ToString();

                // group students automatically
                Check_If_Clicked++;
                AutoAssignStudentToGrouping(Check_If_Clicked);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

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

            // check if "txtStudentIDnumber.text" is = 8 characters
            if (txtStudentIDnumber.Text.Length == 8)
            {

                // check if user entered the first name
                if (txtFirstName.Text != "")
                {

                    //  check if user entered the last name
                    if (txtLastName.Text != "")
                    {

                        // this validates the email format
                        if (validate_emailaddress.IsMatch(txtEmailAddress.Text) != true)
                        {
                            MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtEmailAddress.Focus();
                            return;
                        }
                        else
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
                            Check_If_Clicked++;
                            AutoAssignStudentToGrouping(Check_If_Clicked);

                            // display the number of students
                            lblNumberOfStudent.Text = (listNewlyAddedStudents.Count / 4).ToString();

                        }

                    }
                    else
                    {

                        MessageBox.Show("Invalid Last Name!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtLastName.Focus();

                    }

                }
                else
                {

                    MessageBox.Show("Invalid First Name!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFirstName.Focus();

                }

            }
            else
            {

                MessageBox.Show("Invalid Student ID!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtStudentIDnumber.Focus();

            }

        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {

            listNewlyAddedStudents.RemoveAt(listNewlyAddedStudents.Count - 1);
            listNewlyAddedStudents.RemoveAt(listNewlyAddedStudents.Count - 1);
            listNewlyAddedStudents.RemoveAt(listNewlyAddedStudents.Count - 1);
            listNewlyAddedStudents.RemoveAt(listNewlyAddedStudents.Count - 1);

            // update the DataGridView
            DataGridUpdate();

            // group students automatically
            Check_If_Clicked++;
            AutoAssignStudentToGrouping(Check_If_Clicked);

            // display the number of students
            lblNumberOfStudent.Text = (listNewlyAddedStudents.Count / 4).ToString();

        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {

            try
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
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void tabPageManageGroups_Click(object sender, EventArgs e)
        {
        }

        private void btnImportStudentGroupingTable_Click(object sender, EventArgs e)
        {

            try
            {

                // this solves the problme of clicking "Clear Listbox" button before data can save properly
                if (IsImportGroupScore_Clicked)
                {

                    listBoxViewStudentGrouping.DataSource = null;
                    listBoxViewStudentGrouping.Items.Clear();
                    StudentGroupTable_ListCollection.Clear();
                    ListStudentsGrouping.Clear();

                }

                // listNewlyAddedStudents, ListStudentsGrouping
                ImportStudentGroupingTable();

                btnIsStudentChosen = true;

                lblSelectedStudent.Text = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedItem);
                int GroupID_Column = 5;
                string? SelectedStudentIndex = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedIndex);
                var StudentIndexNumber = int.Parse(SelectedStudentIndex);
                // increment "StudentIndexNumber" to jump to the appropriate column in the row
                StudentIndexNumber++;
                // get the appropriate column index in the "StudentGroupTable_ListCollection"
                ApprColumnIndex = GroupID_Column * StudentIndexNumber;
                /* 
                 * get the appropriate column index for each column in the "StudentGroupTable_ListCollection"
                 * and without this, when you select from the second column in the list it always gets the previous
                 * value
                */
                ApprColumnIndex += --StudentIndexNumber;
                lblCurrentGroupID.Text = StudentGroupTable_ListCollection[ApprColumnIndex];

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnChooseStudent_Click(object sender, EventArgs e)
        {

            try
            {

                btnIsStudentChosen = true;
                // lblCurrentGroupID
                lblSelectedStudent.Text = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedItem);
                int GroupID_Column = 5;
                string? SelectedStudentIndex = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedIndex);
                var StudentIndexNumber = int.Parse(SelectedStudentIndex);
                // increment "StudentIndexNumber" to jump to the appropriate column in the row
                StudentIndexNumber++;
                // get the appropriate column index in the "StudentGroupTable_ListCollection"
                ApprColumnIndex = GroupID_Column * StudentIndexNumber;
                /* 
                 * get the appropriate column index for each column in the "StudentGroupTable_ListCollection"
                 * and without this, when you select from the second column in the list it always gets the previous
                 * value
                */
                ApprColumnIndex += --StudentIndexNumber;
                lblCurrentGroupID.Text = StudentGroupTable_ListCollection[ApprColumnIndex];

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void comboBoxChangeGroupID_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {

                if (btnIsStudentChosen)
                {

                    btnIsStudentChosen = false;
                    // make the selected group to change for the sutdent for both the Listbox and the Datatable
                    object b = comboBoxChangeGroupID.SelectedItem;
                    object be = comboBoxChangeGroupID.GetItemText(b);
                    string? NewGroupIDIndex = be.ToString();
                    labelChangeGroupIDFeedback.Text = "You've selected " + be;
                    int GroupID_Column = 5;
                    string? SelectedStudentIndex = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedIndex);
                    var StudentIndexNumber = int.Parse(SelectedStudentIndex);
                    // increment "StudentIndexNumber" to jump to the appropriate column in the row
                    StudentIndexNumber++;
                    // get the appropriate column index in the "StudentGroupTable_ListCollection"
                    ApprColumnIndex = GroupID_Column * StudentIndexNumber;
                    /* 
                     * get the appropriate column index for each column in the "StudentGroupTable_ListCollection"
                     * and without this, when you select from the second column in the list it always gets the previous
                     * value
                    */
                    ApprColumnIndex += --StudentIndexNumber;
                    StudentGroupTable_ListCollection[ApprColumnIndex] = NewGroupIDIndex;
                    lblCurrentGroupID.Text = StudentGroupTable_ListCollection[ApprColumnIndex];

                    // prepare "DataTable StudentGroupTable" which will be used as DataSource for "dgvStudentGroupingTable"
                    StudentGroupTable.Clear();  // clear the current "dgvStudentGroupingTable" to make room for new data


                    // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                    CheckTrimedListHeader(TrimedListHeader);

                    // variable diclarations
                    var lap = 1;
                    var Index1 = 0;
                    var Index2 = 1;
                    var Index3 = 2;
                    var Index4 = 3;
                    var Index5 = 4;
                    var Index6 = 5;

                    // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                    CheckTrimedListHeader(TrimedListHeader);

                    // loop through each "StudentGroupTable_ListCollection" and add them to StudentGroupTable row
                    for (var i = 0; i <= StudentGroupTable_ListCollection.Count; i++)
                    {

                        // this ensures that four items are added to a row at once. it adds items by batch
                        if (lap > 6)
                        {

                            lap = 1;
                            // assign each list index to a cell in the row
                            StudentGroupTable.Rows.Add(
                                StudentGroupTable_ListCollection[Index1],
                                StudentGroupTable_ListCollection[Index2],
                                StudentGroupTable_ListCollection[Index3],
                                StudentGroupTable_ListCollection[Index4],
                                StudentGroupTable_ListCollection[Index5],
                                StudentGroupTable_ListCollection[Index6]
                                );
                            // go to the next items on the list that needs to be added to Datatable row
                            Index1 += 6;
                            Index2 += 6;
                            Index3 += 6;
                            Index4 += 6;
                            Index5 += 6;
                            Index6 += 6;

                        }

                        lap++;

                    }

                    // display the list item in "dataGridViewListItems"
                    dgvStudentGroupingTable.DataSource = StudentGroupTable;
                    listBoxViewStudentGrouping.DataSource = null;
                    listBoxViewStudentGrouping.Items.Clear();
                    ListStudentsGrouping.Clear();
                    // variable diclarations
                    string ListDetails = "";

                    // add the "StudentGroupTable" data to list
                    foreach (DataRow dr in StudentGroupTable.Rows)
                    {

                        foreach (DataColumn col in StudentGroupTable.Columns)
                        {

                            ListDetails += dr[col] + " ";

                        }

                        ListStudentsGrouping.Add(ListDetails);
                        ListDetails = "";

                    }

                    // display the list item in "listBoxViewStudentGrouping"
                    listBoxViewStudentGrouping.DataSource = ListStudentsGrouping;

                }
                else
                {

                    MessageBox.Show("Please make sure you follow the following steps:\n\n" +
                        "(1) Click the 'Import Student Grouping Table' button to initiate manual settings.\n" +
                        "(2) Click the 'Choose Student' button to select a student from the list above.\n\n" +
                        "Note: It is okay to do Step (1) only once.",
                        "Info"
                        );

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

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

        private void btnSaveGroups_Click(object sender, EventArgs e)
        {

            try
            {

                // variable diclarations
                var lap = 1;
                var Index6 = 5;
                int NumIndex = 0;
                string MatchingValueString;
                int MatchingValueInt;
                bool GroupNumberExceeded = false;
                Get_Num_Array_Count = (StudentGroupTable_ListCollection.Count / 6);
                int[] Num = new int[Get_Num_Array_Count];


                // loop through each "StudentGroupTable_ListCollection" and add them to DataTable row
                for (int a = 0; a <= StudentGroupTable_ListCollection.Count; a++)
                {

                    // this ensures that four items are added to a row at once. it adds items by batch
                    if (lap > 6)
                    {

                        try
                        {

                            lap = 1;
                            MatchingValueString = StudentGroupTable_ListCollection[Index6];
                            MatchingValueInt = int.Parse(MatchingValueString);
                            Num[NumIndex] = int.Parse(MatchingValueString);
                            // go to the next items on the list that needs to be added to Datatable row
                            Index6 += 6;
                            NumIndex++;

                        }
                        catch (Exception ex)
                        {

                            goto Lap;

                        }

                    }

                    Lap:
                    lap++;

                }

                // sort array
                Array.Sort(Num);
                // verify if the number of students in a group is less than 5 and more than 1
                int n = Num.Length;
                int x;

                for (int i = 1; i <= StudentGroupTable_GroupID; i++)
                {

                    x = CountOccurrences(Num, n, i);

                    // check if number of students is greater than 4
                    if (x > 4)
                    {

                        GroupNumberExceeded = true;
                        MessageBox.Show("Group " + i + " has exceeded more than 4 students.",
                        "Warning! Inappropriate Grouping", MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );

                    }

                    // check if number of students is less than 2
                    if (x == 1)
                    {

                        GroupNumberExceeded = true;
                        MessageBox.Show("Group " + i + " has only one student in a group.",
                        "Warning! Inappropriate Grouping", MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );

                    }

                    // check if number of students is less than 2
                    if (x < 1)
                    {

                        GroupNumberExceeded = true;
                        MessageBox.Show("Group " + i + " has no student assigned to it.",
                        "Warning! Inappropriate Grouping", MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );

                    }

                }

                // if both grouping conditions are met then display a success message
                if (!GroupNumberExceeded)
                {

                    MessageBox.Show("Groups saved without errors, \n\n" +
                        "Please remember to click the 'Save To Excel' button in case you would like to retrieve " +
                        "saved groups in future. 🙂",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information
                        );

                }

                // set the "labelVG_TotalGroups" to the correct number of groups
                labelVG_TotalGroups.Text = StudentGroupTable_GroupID.ToString();




                // variable diclarations
                lap = 1;
                var Index2 = 1;
                var Index3 = 2;
                var Index4 = 3;
                var Index5 = 4;
                Index6 = 5;
                int SerialNumber = 1;
                List<string> listNumber = new List<string>();

                // delcare the dictionary to save all groups
                var StudentGrouping = new Dictionary<int, StudentGroups>();

                // loop through each "StudentGroupTable_ListCollection" and add them to "StudentGrouping" Dictionary
                for (int a = 0; a <= StudentGroupTable_ListCollection.Count; a++)
                {

                    // variable diclarations
                    string test = "";
                    string studentID = "";
                    string FirstName = "";
                    string LastName = "";
                    string Email = "";
                    string GroupID = "";
                    string Grade = "0%";

                    // this ensures that four items are added to a row at once. it adds items by batch
                    if (lap > 6)
                    {

                        try
                        {

                            lap = 1;
                            studentID = StudentGroupTable_ListCollection[Index2];
                            FirstName = StudentGroupTable_ListCollection[Index3];
                            LastName = StudentGroupTable_ListCollection[Index4];
                            Email = StudentGroupTable_ListCollection[Index5];
                            GroupID = StudentGroupTable_ListCollection[Index6];
                            // Grade is not given by the lecturer yet
                            test = StudentGroupTable_ListCollection[Index6];
                            Index2 += 6;
                            Index3 += 6;
                            Index4 += 6;
                            Index5 += 6;
                            Index6 += 6;

                            StudentGrouping.Add(SerialNumber, new StudentGroups
                            {

                                studentID = studentID,
                                FirstName = FirstName,
                                LastName = LastName,
                                Email = Email,
                                GroupID = GroupID,
                                Grade = Grade

                            });

                            SerialNumber++;

                        }
                        catch (Exception ex)
                        {

                            goto Lap;

                        }

                    }

                    Lap:
                    lap++;

                }

                IsImportGroupScore_Clicked = false;
                button_MGS_UpdateGroup.Visible = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void listBoxViewStudentGrouping_MouseUp(object sender, MouseEventArgs e)
        {

            try
            {

                btnIsStudentChosen = true;

                lblSelectedStudent.Text = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedItem);
                int GroupID_Column = 5;
                string? SelectedStudentIndex = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedIndex);
                var StudentIndexNumber = int.Parse(SelectedStudentIndex);
                // increment "StudentIndexNumber" to jump to the appropriate column in the row
                StudentIndexNumber++;
                // get the appropriate column index in the "StudentGroupTable_ListCollection"
                ApprColumnIndex = GroupID_Column * StudentIndexNumber;
                /* 
                 * get the appropriate column index for each column in the "StudentGroupTable_ListCollection"
                 * and without this, when you select from the second column in the list it always gets the previous
                 * value
                */
                ApprColumnIndex += --StudentIndexNumber;
                lblCurrentGroupID.Text = StudentGroupTable_ListCollection[ApprColumnIndex];

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnChangeGroupID_Click(object sender, EventArgs e)
        {

            try
            {

                if (btnIsStudentChosen)
                {

                    btnIsStudentChosen = false;
                    // start from here...
                    // make the selected group to change for the sutdent for both the Listbox and the Datatable
                    object b = comboBoxChangeGroupID.SelectedItem;
                    object be = comboBoxChangeGroupID.GetItemText(b);
                    string? NewGroupIDIndex = be.ToString();
                    labelChangeGroupIDFeedback.Text = "You've selected " + be;
                    int GroupID_Column = 5;
                    string? SelectedStudentIndex = listBoxViewStudentGrouping.GetItemText(listBoxViewStudentGrouping.SelectedIndex);
                    var StudentIndexNumber = int.Parse(SelectedStudentIndex);
                    // increment "StudentIndexNumber" to jump to the appropriate column in the row
                    StudentIndexNumber++;
                    // get the appropriate column index in the "StudentGroupTable_ListCollection"
                    ApprColumnIndex = GroupID_Column * StudentIndexNumber;
                    /* 
                     * get the appropriate column index for each column in the "StudentGroupTable_ListCollection"
                     * and without this, when you select from the second column in the list it always gets the previous
                     * value
                    */
                    ApprColumnIndex += --StudentIndexNumber;
                    StudentGroupTable_ListCollection[ApprColumnIndex] = NewGroupIDIndex;
                    lblCurrentGroupID.Text = StudentGroupTable_ListCollection[ApprColumnIndex];

                    // prepare "DataTable StudentGroupTable" which will be used as DataSource for "dgvStudentGroupingTable"
                    StudentGroupTable.Clear();  // clear the current "dgvStudentGroupingTable" to make room for new data


                    // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                    CheckTrimedListHeader(TrimedListHeader);

                    // variable diclarations
                    var lap = 1;
                    var Index1 = 0;
                    var Index2 = 1;
                    var Index3 = 2;
                    var Index4 = 3;
                    var Index5 = 4;
                    var Index6 = 5;

                    // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                    CheckTrimedListHeader(TrimedListHeader);

                    // loop through each "listNewlyAddedStudents" and add them to DataTable row
                    for (var i = 0; i <= StudentGroupTable_ListCollection.Count; i++)
                    {

                        // this ensures that four items are added to a row at once. it adds items by batch
                        if (lap > 6)
                        {

                            lap = 1;
                            // assign each list index to a cell in the row
                            StudentGroupTable.Rows.Add(
                                StudentGroupTable_ListCollection[Index1],
                                StudentGroupTable_ListCollection[Index2],
                                StudentGroupTable_ListCollection[Index3],
                                StudentGroupTable_ListCollection[Index4],
                                StudentGroupTable_ListCollection[Index5],
                                StudentGroupTable_ListCollection[Index6]
                                );
                            // go to the next items on the list that needs to be added to Datatable row
                            Index1 += 6;
                            Index2 += 6;
                            Index3 += 6;
                            Index4 += 6;
                            Index5 += 6;
                            Index6 += 6;

                        }

                        lap++;

                    }

                    // display the list item in "dataGridViewListItems"
                    dgvStudentGroupingTable.DataSource = StudentGroupTable;
                    listBoxViewStudentGrouping.DataSource = null;
                    listBoxViewStudentGrouping.Items.Clear();
                    ListStudentsGrouping.Clear();
                    // variable diclarations
                    string ListDetails = "";

                    // add the "StudentGroupTable" data to list
                    foreach (DataRow dr in StudentGroupTable.Rows)
                    {

                        foreach (DataColumn col in StudentGroupTable.Columns)
                        {

                            ListDetails += dr[col] + " ";

                        }

                        ListStudentsGrouping.Add(ListDetails);
                        ListDetails = "";

                    }

                    // display the list item in "listBoxViewStudentGrouping"
                    listBoxViewStudentGrouping.DataSource = ListStudentsGrouping;

                }
                else
                {

                    MessageBox.Show("Please make sure you follow the following steps:\n\n" +
                        "(1) Click the 'Import Student Grouping Table' button to initiate manual settings.\n" +
                        "(2) Click the 'Choose Student' button to select a student from the list above.\n\n" +
                        "Note: It is okay to do Step (1) only once.",
                        "Info"
                        );

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void comboBoxChooseGroup_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {

                // variable diclarations
                var lap = 1;
                var Index2 = 1;
                var Index3 = 2;
                var Index4 = 3;
                var Index6 = 5;
                int SerialNumber = 1;
                List<string> MatchingValues = new List<string>();
                listBoxViewGroups.DataSource = null;
                listBoxViewGroups.Items.Clear();
                MatchingValues.Clear();
                /*
                 * get the GroupID selected from "comboBoxChooseGroup" and assign it to "c" to be used to
                 * find all related GroupID in the "StudentGroupTable_ListCollection"
                 */
                object b = comboBoxChooseGroup.SelectedItem;
                object be = comboBoxChooseGroup.GetItemText(b);
                string? c = be.ToString();

                labelVG_GroupSelected.Text = c;
                labelVG_Group.Visible = true;
                labelVG_GroupSelected.Visible = true;
                labelVG_Selected.Visible = true;

                // loop through each "StudentGroupTable_ListCollection"
                for (int a = 0; a <= StudentGroupTable_ListCollection.Count; a++)
                {

                    string test = "";
                    string MatchingValueString = "";

                    // this ensures that four items are added to a row at once. it adds items by batch
                    if (lap > 6)
                    {

                        lap = 1;
                        MatchingValueString = StudentGroupTable_ListCollection[Index2] + " - " +
                                            StudentGroupTable_ListCollection[Index3] + " " +
                                            StudentGroupTable_ListCollection[Index4];
                        test = StudentGroupTable_ListCollection[Index6];
                        Index2 += 6;
                        Index3 += 6;
                        Index4 += 6;
                        Index6 += 6;

                        if (test == c)
                        {

                            MatchingValues.Add("(" + (SerialNumber.ToString()) + ") " + MatchingValueString);
                            SerialNumber++;

                        }

                    }

                    lap++;

                }

                listBoxViewGroups.DataSource = MatchingValues;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void comboBoxMGS_ChooseGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (IsImportGroupScore_Clicked)
                {

                    // variable diclarations
                    var lap = 1;
                    var Index1 = 0;
                    var Index2 = 1;
                    var Index3 = 2;
                    var Index4 = 3;
                    var Index6 = 5;
                    int SerialNumber = 1;
                    List<string> MatchingValues = new List<string>();
                    listBoxManageGroupScore.DataSource = null;
                    listBoxManageGroupScore.Items.Clear();
                    MatchingValues.Clear();


                    /*
                     * get the GroupID selected from "comboBoxChooseGroup" and assign it to "c" to be used to
                     * find all related GroupID in the "StudentGroupTable_ListCollection"
                     */
                    object b = comboBoxMGS_ChooseGroup.SelectedItem;
                    object be = comboBoxMGS_ChooseGroup.GetItemText(b);
                    string? c = be.ToString();
                    labelMGS_GroupSelected.Text = c;
                    labelMGS_GroupSelected.Visible = true;
                    labelMGS_Group.Visible = true;


                    // loop through each "StudentGroupTable_ListCollection"
                    for (int a = 0; a <= StudentGroupTable_ListCollection.Count; a++)
                    {

                        string test = "";
                        string MatchingValueString = "";


                        // this ensures that four items are added to a row at once. it adds items by batch
                        if (lap > 7)
                        {

                            lap = 1;
                            MatchingValueString = "(" + StudentGroupTable_ListCollection[Index1] + ") " +
                                                StudentGroupTable_ListCollection[Index2] + " - " +
                                                StudentGroupTable_ListCollection[Index3] + " " +
                                                StudentGroupTable_ListCollection[Index4];
                            test = StudentGroupTable_ListCollection[Index6];
                            Index2 += 7;
                            Index3 += 7;
                            Index4 += 7;
                            Index6 += 7;

                            if (test == c)
                            {

                                MatchingValues.Add(MatchingValueString);
                                SerialNumber++;

                            }
                        }

                        lap++;

                    }

                    --SerialNumber;
                    lblMGS_NumberOfStudents.Text = SerialNumber.ToString();
                    labelMGS_NumberOfStudents.Visible = true;
                    lblMGS_NumberOfStudents.Visible = true;
                    listBoxManageGroupScore.DataSource = MatchingValues;
                    label_MGS_RefreshTotalScoreGiven.Visible = true;
                    label_MGS_RefreshTotalScoreGiven2.Visible = true;

                }
                else
                {

                    // variable diclarations
                    var lap = 1;
                    var Index2 = 1;
                    var Index3 = 2;
                    var Index4 = 3;
                    var Index6 = 5;
                    int SerialNumber = 1;
                    List<string> MatchingValues = new List<string>();
                    listBoxManageGroupScore.DataSource = null;
                    listBoxManageGroupScore.Items.Clear();
                    MatchingValues.Clear();


                    /*
                     * get the GroupID selected from "comboBoxChooseGroup" and assign it to "c" to be used to
                     * find all related GroupID in the "StudentGroupTable_ListCollection"
                     */
                    object b = comboBoxMGS_ChooseGroup.SelectedItem;
                    object be = comboBoxMGS_ChooseGroup.GetItemText(b);
                    string? c = be.ToString();
                    labelMGS_GroupSelected.Text = c;
                    labelMGS_GroupSelected.Visible = true;
                    labelMGS_Group.Visible = true;


                    // loop through each "StudentGroupTable_ListCollection"
                    for (int a = 0; a <= StudentGroupTable_ListCollection.Count; a++)
                    {

                        string test = "";
                        string MatchingValueString = "";


                        // this ensures that four items are added to a row at once. it adds items by batch
                        if (lap > 6)
                        {

                            lap = 1;
                            MatchingValueString = StudentGroupTable_ListCollection[Index2] + " - " +
                                                StudentGroupTable_ListCollection[Index3] + " " +
                                                StudentGroupTable_ListCollection[Index4];
                            test = StudentGroupTable_ListCollection[Index6];
                            Index2 += 6;
                            Index3 += 6;
                            Index4 += 6;
                            Index6 += 6;

                            if (test == c)
                            {

                                MatchingValues.Add("(" + (SerialNumber.ToString()) + ") " + MatchingValueString);
                                SerialNumber++;

                            }

                        }

                        lap++;

                    }

                    --SerialNumber;
                    lblMGS_NumberOfStudents.Text = SerialNumber.ToString();
                    labelMGS_NumberOfStudents.Visible = true;
                    lblMGS_NumberOfStudents.Visible = true;
                    listBoxManageGroupScore.DataSource = MatchingValues;
                    label_MGS_RefreshTotalScoreGiven.Visible = true;
                    label_MGS_RefreshTotalScoreGiven2.Visible = true;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void listBoxManageGroupScore_MouseUp(object sender, MouseEventArgs e)
        {

            try
            {

                // get the selected student details from "listBoxManageGroupScore" and substring the "StudentID"
                string text = listBoxManageGroupScore.GetItemText(listBoxManageGroupScore.SelectedItem);
                int startIndex = 4;
                int length = 8;
                // lblMGS_StudentID.Text = substring;
                bool pointer = false;
                String student_ID = text.Substring(startIndex, length);
                //DeclareDictionary(StudentGroupTable_ListCollection, pointer, student_ID);


                // variable diclarations
                int lap = 1;
                var Index2 = 1;
                var Index3 = 2;
                var Index4 = 3;
                var Index5 = 4;
                var Index6 = 5;
                var Index7 = 6;
                int SerialNumber = 1;
                List<string> listNumber = new List<string>();

                // delcare the dictionary to save all groups
                var StudentGrouping = new Dictionary<int, StudentGroups>();


                // loop through each "ManageScoreStudentList" and add them to "StudentGrouping" Dictionary
                for (int a = 0; a <= ManageScoreStudentList.Count; a++)
                {

                    // variable diclarations
                    string test = "";
                    string studentID = "";
                    string FirstName = "";
                    string LastName = "";
                    string Email = "";
                    string GroupID = "";
                    string Grade = "";

                    // this ensures that four items are added to a row at once. it adds items by batch
                    if (lap > 7)
                    {

                        try
                        {

                            lap = 1;
                            studentID = ManageScoreStudentList[Index2];
                            FirstName = ManageScoreStudentList[Index3];
                            LastName = ManageScoreStudentList[Index4];
                            Email = ManageScoreStudentList[Index5];
                            GroupID = ManageScoreStudentList[Index6];
                            Grade = ManageScoreStudentList[Index7];

                            // test = StudentGroupTable_ListCollection[Index6];
                            Index2 += 7;
                            Index3 += 7;
                            Index4 += 7;
                            Index5 += 7;
                            Index6 += 7;
                            Index7 += 7;

                            StudentGrouping.Add(SerialNumber, new StudentGroups
                            {

                                studentID = studentID,
                                FirstName = FirstName,
                                LastName = LastName,
                                Email = Email,
                                GroupID = GroupID,
                                Grade = Grade

                            });

                            SerialNumber++;

                        }
                        catch (Exception ex)
                        {

                            goto Lap;

                        }

                    }

                    Lap:
                    lap++;

                }

                --SerialNumber;
                string? _studentID = "";
                string? _FirstName = "";
                string? _LastName = "";
                string? _Email = "";
                string? _GroupID = "";
                string? _Grade = "";


                // this displays the sturent details below the ListBox in Manage Student Group Section
                foreach (var index in Enumerable.Range(1, SerialNumber))
                {

                    if (StudentGrouping[index].studentID == student_ID)
                    {

                        _studentID = StudentGrouping[index].studentID;
                        _FirstName = StudentGrouping[index].FirstName;
                        _LastName = StudentGrouping[index].LastName;
                        _Email = StudentGrouping[index].Email;
                        _GroupID = StudentGrouping[index].GroupID;
                        _Grade = StudentGrouping[index].Grade;

                    }

                }

                int i = 0;  // this is for the "For loop" below
                int j = 0;  // this is for the "For loop" below
                bool found = false;

                // use the studentID to fetch the student data
                if (array_StudentGroupTable_Count != null)
                {

                    for (i = 0; i < array_StudentGroupTable_Count.Length && !found; i++)
                    {

                        for (j = 0; j < 7; j++)
                        {

                            if (array_StudentGroupTable_Count[i, j] == _studentID)
                            {

                                SerialNumber_By_ID = array_StudentGroupTable_Count[i, 0];
                                StudentID_By_ID = array_StudentGroupTable_Count[i, 1];
                                FirstName_By_ID = array_StudentGroupTable_Count[i, 2];
                                LastName_By_ID = array_StudentGroupTable_Count[i, 3];
                                Email_By_ID = array_StudentGroupTable_Count[i, 4];
                                Group_By_ID = array_StudentGroupTable_Count[i, 5];
                                Grade_By_ID = array_StudentGroupTable_Count[i, 6];
                                fetchedStudentID = i;
                                found = true;
                                break;

                            }

                        }

                    }

                    DisplayTotalGiveScore();
                    lblMGS_StudentID.Text = StudentID_By_ID;
                    lblMGS_StudentFullName.Text = FirstName_By_ID + " " + LastName_By_ID;
                    lblMGS_StudentScore.Text = Grade_By_ID + "%";
                    label_MGS_RefreshTotalScoreGiven.Visible = false;
                    label_MGS_RefreshTotalScoreGiven2.Visible = false;

                }
                else
                {

                    MessageBox.Show(" Invalid operation. CODE:4;001.\n" +
                        "Please click on 'Update Group' button first before selecting a student.",
                        "Info"
                    );

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void tabPageManageGroupScore_Enter(object sender, EventArgs e)
        {
        }

        private void button_MGS_UpdateGroup_Click(object sender, EventArgs e)
        {

            try
            {

                // variable diclarations
                var lap = 1;
                var array_index = 0;
                var Index1 = 0;
                var Index2 = 1;
                var Index3 = 2;
                var Index4 = 3;
                var Index5 = 4;
                var Index6 = 5;
                var Index7 = "0";


                // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                CheckTrimedListHeader(TrimedListHeader);

                // get the number of rows to be given to the array
                StudentGroupTable_Count = StudentGroupTable_ListCollection.Count / 6;

                // initiate a 2-dimensional array with the set rows and colume
                InitiateStudentArray();


                // loop through each "StudentGroupTable_ListCollection" and add them to "ManageScoreStudentList"
                for (var i = 0; i <= StudentGroupTable_ListCollection.Count; i++)
                {

                    // this ensures that four items are added to a row at once. it adds items by batch
                    if (lap > 6)
                    {

                        lap = 1;

                        /*
                         * get all items in "StudentGroupTable_ListCollection" and add them to "ManageScoreStudentList"
                         * including temporary Grade of zero(0)
                        */
                        ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index1]);   // S/N
                        ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index2]);   // Student_ID
                        ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index3]);   // First name
                        ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index4]);   // Last name
                        ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index5]);   // Email
                        ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index6]);   // Group_ID
                        ManageScoreStudentList.Add(Index7);   // Grade


                        string? _SerialNumber = StudentGroupTable_ListCollection[Index1];
                        string? _studentID = StudentGroupTable_ListCollection[Index2];
                        string? _FirstName = StudentGroupTable_ListCollection[Index3];
                        string? _LastName = StudentGroupTable_ListCollection[Index4];
                        string? _Email = StudentGroupTable_ListCollection[Index5];
                        string? _GroupID = StudentGroupTable_ListCollection[Index6];
                        string? _Grade = Index7;


                        array_StudentGroupTable_Count[array_index, 0] = _SerialNumber;
                        array_StudentGroupTable_Count[array_index, 1] = _studentID;
                        array_StudentGroupTable_Count[array_index, 2] = _FirstName;
                        array_StudentGroupTable_Count[array_index, 3] = _LastName;
                        array_StudentGroupTable_Count[array_index, 4] = _Email;
                        array_StudentGroupTable_Count[array_index, 5] = _GroupID;
                        array_StudentGroupTable_Count[array_index, 6] = _Grade;


                        // go to the next items on the list that needs to be added to Datatable row
                        Index1 += 6;  // increment "Index1" by 6
                        Index2 += 6;  // increment "Index1" by 6
                        Index3 += 6;  // increment "Index1" by 6
                        Index4 += 6;  // increment "Index1" by 6
                        Index5 += 6;  // increment "Index1" by 6
                        Index6 += 6;  // increment "Index1" by 6
                        array_index++;  // increment "array_index"

                    }

                    lap++;

                }

                InitialGroupUpdateRecord++;
                comboBoxMGS_ChooseGroup.Visible = true;
                label_MGS_UpdateNotice.Text = "Update commited: " + InitialGroupUpdateRecord +
                    ". \nPlease update whenever you make changes to the group members.";

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void button_MGS_AssignScore_Apply_Click(object sender, EventArgs e)
        {

            try
            {

                // assigns score to the selected student
                if (textBox_MGS_AssignScore.Text != "")
                {

                    string TempString = array_StudentGroupTable_Count[fetchedStudentID, 6];
                    array_StudentGroupTable_Count[fetchedStudentID, 6] = textBox_MGS_AssignScore.Text;

                    // run check if Total Score Given for a group has exceeded 90%
                    CheckTotalScore();

                    // if Total Score Given for a group has exceeded 90% then revert back to previous value
                    if (CheckedResult_TotalScoreGiven == true)
                    {

                        array_StudentGroupTable_Count[fetchedStudentID, 6] = TempString;
                        MessageBox.Show("The score you entered makes the Total Score alloted to exceeded 100%", "Info");

                    }
                    else
                    {

                        lblMGS_StudentScore.Text = array_StudentGroupTable_Count[fetchedStudentID, 6] + "%";

                        // this gets the total score for each group and displays it
                        DisplayTotalGiveScore();

                    }

                }
                else
                {

                    MessageBox.Show("Please enter a valid number", "Info");

                }

                label_MGS_RefreshTotalScoreGiven.Visible = false;
                label_MGS_RefreshTotalScoreGiven2.Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        // this clears the necessary ListBox and Lists
        private void button_MG_ClearListBox_Click(object sender, EventArgs e)
        {
            listBoxViewStudentGrouping.DataSource = null;
            listBoxViewStudentGrouping.Items.Clear();
            StudentGroupTable_ListCollection.Clear();
            ListStudentsGrouping.Clear();
        }

        // this saves "Manage Group Score" to excel
        private void button_MGS_SaveToExcel_Click(object sender, EventArgs e)
        {

            try
            {

                // prepare "DataTable dt" which will be used to save data into Excel
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("SerialNumber", typeof(string));
                dt.Columns.Add("StudentID", typeof(string));
                dt.Columns.Add("FirstName", typeof(string));
                dt.Columns.Add("LastName", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Group", typeof(string));
                dt.Columns.Add("Grade(%)", typeof(string));

                // assign array_StudentGroupTable_Count array to "ManageGroupScore_SavingList" list 
                int count = 1;

                // this gets the total score for each group and displays it
                for (int f = 0; f < array_StudentGroupTable_Count.Length; f++)  // this stages accesses the row of the array
                {

                    if (count <= 12)  // this stages accesses the column of the array
                    {

                        // assign each list index to a cell in the row
                        dt.Rows.Add(
                            array_StudentGroupTable_Count[f, 0],
                            array_StudentGroupTable_Count[f, 1],
                            array_StudentGroupTable_Count[f, 2],
                            array_StudentGroupTable_Count[f, 3],
                            array_StudentGroupTable_Count[f, 4],
                            array_StudentGroupTable_Count[f, 5],
                            array_StudentGroupTable_Count[f, 6]
                        );

                        ++count;

                    }

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
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        // this saves "Manage Group" to excel
        private void button_MG_SaveToExcel_Click(object sender, EventArgs e)
        {

            try
            {

                // prepare "DataTable dt" which will be used to save data into Excel
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("S/N", typeof(string));
                dt.Columns.Add("Student ID", typeof(string));
                dt.Columns.Add("FirstName", typeof(string));
                dt.Columns.Add("LastName", typeof(string));
                dt.Columns.Add("Email Address", typeof(string));
                dt.Columns.Add("Group ID", typeof(string));

                // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                CheckTrimedListHeader(TrimedListHeader);

                // variable diclarations
                var lap = 1;
                var Index1 = 0;
                var Index2 = 1;
                var Index3 = 2;
                var Index4 = 3;
                var Index5 = 4;
                var Index6 = 5;

                // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                CheckTrimedListHeader(TrimedListHeader);

                // loop through each "StudentGroupTable_ListCollection" and add them to "dt" row
                for (var i = 0; i <= StudentGroupTable_ListCollection.Count; i++)
                {

                    // this ensures that four items are added to a row at once. it adds items by batch
                    if (lap > 6)
                    {

                        lap = 1;
                        // assign each list index to a cell in the row
                        dt.Rows.Add(
                            StudentGroupTable_ListCollection[Index1],
                            StudentGroupTable_ListCollection[Index2],
                            StudentGroupTable_ListCollection[Index3],
                            StudentGroupTable_ListCollection[Index4],
                            StudentGroupTable_ListCollection[Index5],
                            StudentGroupTable_ListCollection[Index6]
                            );

                        // go to the next items on the list that needs to be added to Datatable row
                        Index1 += 6;
                        Index2 += 6;
                        Index3 += 6;
                        Index4 += 6;
                        Index5 += 6;
                        Index6 += 6;

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
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        // this imports saved "Manage Students"  tab section
        private void button_SD_ImportStudentsfile_Click(object sender, EventArgs e)
        {

            try
            {

                Check_If_Clicked = 0; // make "Check_If_Clicked" to be zero so that user can import new csv file if they want
                                      // switch the to the relevant DataGridView
                dataGridViewListItems.Visible = true;
                dgvCsvImport.Visible = false;
                dataGridViewListItems.DataSource = null;
                TrimedListHeader = true;

                // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                CheckTrimedListHeader(TrimedListHeader);

                // open the file dialog and choose the .csv file
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
                {

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        string filePath = Path.GetFullPath(openFileDialog.FileName);

                        // display the filepath above datagGidView
                        lblFilePath.Text = filePath;

                        var workbook = new XLWorkbook(filePath);
                        var WorkSheet = workbook.Worksheet(1);
                        bool ColumnEmpty = false;
                        bool CheckRowEmpty = false;


                        var RowCount = WorkSheet.RangeUsed().RowsUsed();    // get the used rows from excel
                        int newcount = 0;   // intialize a new counter

                        foreach (var row in RowCount)   // access each data in the used rows
                        {

                            newcount++; // increment counter to be used to loop through each row and get all the non-empty cells
                            CheckRowEmpty = true;   // used to know if "listNewlyAddedStudents" should be cleared or not 

                        }

                        if (CheckRowEmpty)  // check if row is empty before clearing the contents of "listNewlyAddedStudents"
                        {

                            listNewlyAddedStudents.Clear(); // clear this list only if there is one or more data from excel file

                            for (int i = 2; i <= newcount; i++) // this loops through each row and will not exceed the number of used rows
                            {

                                var row = WorkSheet.Row(i); // this selects the row from the second row skipping the first row

                                for (int j = 1; j < 5; j++) // loop through each cell
                                {

                                    var cell = row.Cell(j);
                                    ColumnEmpty = cell.IsEmpty();

                                    if (!ColumnEmpty) // check if cell is empty
                                    {

                                        string value = cell.GetValue<string>(); // assign cell value to variable
                                        listNewlyAddedStudents.Add(value);  // add new item to the list "listNewlyAddedStudents"

                                    }

                                }

                                //MessageBox.Show("Value is: " + value + ". Empty is: " + empty, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            // display the number of students
                            lblNumberOfStudent.Text = (listNewlyAddedStudents.Count / 4).ToString();

                            // check if the "StudentGroupTable.Columns" have already been created
                            if (StudentGroupTable.Columns.Count > 0)
                            {

                                // this fixes the error that comes up when user tries to import saved Students data after importing CSV file
                                StudentGroupTable.Columns.Remove("S/N");
                                StudentGroupTable.Columns.Remove("Student ID");
                                StudentGroupTable.Columns.Remove("FirstName");
                                StudentGroupTable.Columns.Remove("LastName");
                                StudentGroupTable.Columns.Remove("Email Address");
                                StudentGroupTable.Columns.Remove("Group ID");

                            }

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

                            // loop through each "listNewlyAddedStudents" and add them to DataTable row
                            for (var i = 0; i <= listNewlyAddedStudents.Count; i++)
                            {

                                // this ensures that four items are added to a row at once. it adds items by batch
                                if (lap > 4)
                                {

                                    lap = 1;
                                    // assign each list index to a cell in the row
                                    dt.Rows.Add(listNewlyAddedStudents[Index1],
                                        listNewlyAddedStudents[Index2],
                                        listNewlyAddedStudents[Index3],
                                        listNewlyAddedStudents[Index4]
                                    );

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

                        // this lets the program know it must clear "dgvStudentGroupingTable"
                        Check_If_Clicked++;
                        AutoAssignStudentToGrouping(Check_If_Clicked);
                        MessageBox.Show("Import 'Manage Students' file was successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        MessageBox.Show("File doesn't exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        // this imports saved "Manage Group Score" tab section
        private void button_SD_ImportManageGroupScorefile_Click(object sender, EventArgs e)
        {

            try
            {

                // open the file dialog and choose the .csv file
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
                {

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        string filePath = Path.GetFullPath(openFileDialog.FileName);

                        // display the filepath above datagGidView
                        lblFilePath.Text = filePath;

                        var workbook = new XLWorkbook(filePath);
                        var WorkSheet = workbook.Worksheet(1);
                        bool ColumnEmpty = false;
                        bool CheckRowEmpty = false;


                        var RowCount = WorkSheet.RangeUsed().RowsUsed();    // get the used rows from excel
                        int newcount = 0;   // intialize a new counter

                        foreach (var row in RowCount)   // access each data in the used rows
                        {

                            newcount++; // increment counter to be used to loop through each row and get all the non-empty cells
                            CheckRowEmpty = true;   // used to know if "StudentGroupTable_ListCollection" should be cleared or not 

                        }

                        if (CheckRowEmpty)  // check if row is empty before clearing the contents of "StudentGroupTable_ListCollection"
                        {

                            StudentGroupTable_ListCollection.Clear(); // clear this list only if there is one or more data from excel file

                            for (int i = 2; i <= newcount; i++) // this loops through each row and will not exceed the number of used rows
                            {

                                var row = WorkSheet.Row(i); // this selects the row from the second row skipping the first row

                                for (int j = 1; j < 8; j++) // loop through each cell
                                {

                                    var cell = row.Cell(j);
                                    ColumnEmpty = cell.IsEmpty();

                                    if (!ColumnEmpty) // check if cell is empty
                                    {

                                        string value = cell.GetValue<string>(); // assign cell value to variable
                                        StudentGroupTable_ListCollection.Add(value);  // add new item to the list "StudentGroupTable_ListCollection"

                                    }

                                }

                            }

                            // variable diclarations
                            var lap = 1;
                            var array_index = 0;
                            var Index1 = 0;
                            var Index2 = 1;
                            var Index3 = 2;
                            var Index4 = 3;
                            var Index5 = 4;
                            var Index6 = 5;
                            var Index7 = 6;   // note: this is what makes it different from the "Update Group" button because now there is a variable for grade


                            // get the number of rows to be given to the array
                            StudentGroupTable_Count = StudentGroupTable_ListCollection.Count / 7;

                            // initiate a 2-dimensional array with the set rows and colume
                            InitiateStudentArray();


                            // loop through each "StudentGroupTable_ListCollection" and add them to "ManageScoreStudentList"
                            for (var i = 0; i <= StudentGroupTable_ListCollection.Count; i++)
                            {

                                // this ensures that four items are added to a row at once. it adds items by batch
                                if (lap > 7)
                                {

                                    lap = 1;

                                    /*
                                     * get all items in "StudentGroupTable_ListCollection" and add them to "ManageScoreStudentList"
                                     * including temporary Grade of zero(0)
                                    */
                                    ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index1]);   // S/N
                                    ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index2]);   // Student_ID
                                    ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index3]);   // First name
                                    ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index4]);   // Last name
                                    ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index5]);   // Email
                                    ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index6]);   // Group_ID
                                    ManageScoreStudentList.Add(StudentGroupTable_ListCollection[Index7]);   // Grade


                                    string? _SerialNumber = StudentGroupTable_ListCollection[Index1];
                                    string? _studentID = StudentGroupTable_ListCollection[Index2];
                                    string? _FirstName = StudentGroupTable_ListCollection[Index3];
                                    string? _LastName = StudentGroupTable_ListCollection[Index4];
                                    string? _Email = StudentGroupTable_ListCollection[Index5];
                                    string? _GroupID = StudentGroupTable_ListCollection[Index6];
                                    string? _Grade = StudentGroupTable_ListCollection[Index7];


                                    array_StudentGroupTable_Count[array_index, 0] = _SerialNumber;
                                    array_StudentGroupTable_Count[array_index, 1] = _studentID;
                                    array_StudentGroupTable_Count[array_index, 2] = _FirstName;
                                    array_StudentGroupTable_Count[array_index, 3] = _LastName;
                                    array_StudentGroupTable_Count[array_index, 4] = _Email;
                                    array_StudentGroupTable_Count[array_index, 5] = _GroupID;
                                    array_StudentGroupTable_Count[array_index, 6] = _Grade;


                                    // go to the next items on the list that needs to be added to Datatable row
                                    Index1 += 7;  // increment "Index1" by 7
                                    Index2 += 7;  // increment "Index2" by 7
                                    Index3 += 7;  // increment "Index3" by 7
                                    Index4 += 7;  // increment "Index4" by 7
                                    Index5 += 7;  // increment "Index5" by 7
                                    Index6 += 7;  // increment "Index6" by 7
                                    Index7 += 7;  // increment "Index7" by 7. Note: this is an addition compared to "Update Goupe" button
                                    array_index++;  // increment "array_index"

                                }

                                lap++;

                            }

                            // get the number of groups
                            // variable diclarations
                            lap = 1;
                            Index6 = 5;
                            int NumIndex = 0;
                            string MatchingValueString;
                            int MatchingValueInt;
                            Get_Num_Array_Count = (StudentGroupTable_ListCollection.Count / 7);
                            int[] Num = new int[Get_Num_Array_Count];


                            // loop through each "StudentGroupTable_ListCollection" and add them to DataTable row
                            for (int a = 0; a <= StudentGroupTable_ListCollection.Count; a++)
                            {

                                // this ensures that four items are added to a row at once. it adds items by batch
                                if (lap > 7)
                                {

                                    try
                                    {

                                        lap = 1;
                                        MatchingValueString = StudentGroupTable_ListCollection[Index6];
                                        MatchingValueInt = int.Parse(MatchingValueString);
                                        Num[NumIndex] = int.Parse(MatchingValueString);
                                        // go to the next items on the list that needs to be added to Datatable row
                                        Index6 += 7;
                                        NumIndex++;

                                    }
                                    catch (Exception ex)
                                    {

                                        goto Lap;

                                    }
                                }

                                Lap:
                                lap++;

                            }

                            // sort array
                            Array.Sort(Num);
                            int TempArrayValue = Num[0];

                            // check how many groups there are
                            foreach (var x in Num)
                            {

                                if (TempArrayValue != x)
                                {

                                    TempArrayValue = x;

                                }

                            }

                            // this is the base "StudentGroupTable_GroupID" value. This assigns the number of groups
                            StudentGroupTable_GroupID = TempArrayValue;
                            Final_StudentGroupTable_GroupID_Value = StudentGroupTable_GroupID;
                            UpdateComboBoxChangeGroupID();


                            // MessageBox.Show("number of groups are: " + TempArrayValue, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            InitialGroupUpdateRecord++;
                            comboBoxMGS_ChooseGroup.Visible = true;
                            label_MGS_UpdateNotice.Text = "Update commited: " + InitialGroupUpdateRecord +
                                ". \nPlease update whenever you make changes to the group members.";

                        }

                        // this changes how list "MatchingValues" poupulates "listBoxManageGroupScore" with data
                        IsImportGroupScore_Clicked = true;
                        button_MGS_UpdateGroup.Visible = false;
                        MessageBox.Show("Import 'Manage Group Score' file was successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        MessageBox.Show("File doesn't exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        // this imports saved "Manage Groups" tab section
        private void button_SD_ImportManageGroupsFile_Click(object sender, EventArgs e)
        {

            try
            {

                TrimedListHeader = true;
                // check if "listNewlyAddedStudents" header has been removed else remove the first row of the list
                CheckTrimedListHeader(TrimedListHeader);

                // open the file dialog and choose the .csv file
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
                {

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        string filePath = Path.GetFullPath(openFileDialog.FileName);

                        // display the filepath above datagGidView
                        lblFilePath.Text = filePath;

                        var workbook = new XLWorkbook(filePath);
                        var WorkSheet = workbook.Worksheet(1);
                        bool ColumnEmpty = false;
                        bool CheckRowEmpty = false;

                        var RowCount = WorkSheet.RangeUsed().RowsUsed();    // get the used rows from excel
                        int newcount = 0;   // intialize a new counter

                        foreach (var row in RowCount)   // access each data in the used rows
                        {

                            newcount++; // increment counter to be used to loop through each row and get all the non-empty cells
                            CheckRowEmpty = true;   // used to know if "listNewlyAddedStudents" should be cleared or not 

                        }

                        if (CheckRowEmpty)  // check if row is empty before clearing the contents of "listNewlyAddedStudents"
                        {

                            listNewlyAddedStudents.Clear(); // clear this list only if there is one or more data from excel file

                            for (int i = 2; i <= newcount; i++) // this loops through each row and will not exceed the number of used rows
                            {

                                var row = WorkSheet.Row(i); // this selects the row from the second row skipping the first row

                                for (int j = 1; j < 7; j++) // loop through each cell
                                {

                                    var cell = row.Cell(j);
                                    ColumnEmpty = cell.IsEmpty();

                                    if (!ColumnEmpty) // check if cell is empty
                                    {

                                        string value = cell.GetValue<string>(); // assign cell value to variable
                                        listNewlyAddedStudents.Add(value);  // add new item to the list "listNewlyAddedStudents"

                                    }

                                }

                                //MessageBox.Show("Value is: " + value + ". Empty is: " + empty, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                            // display the number of students
                            lblNumberOfStudent.Text = (listNewlyAddedStudents.Count / 6).ToString();

                            /*
                             * this corrects the errr that occurs when user imports saved student data and afterwards
                             * imports saved "Manage Group"
                             */

                            if (Check_If_Clicked > 0)
                            {

                                StudentGroupTable.Columns.Remove("S/N");
                                StudentGroupTable.Columns.Remove("Student ID");
                                StudentGroupTable.Columns.Remove("FirstName");
                                StudentGroupTable.Columns.Remove("LastName");
                                StudentGroupTable.Columns.Remove("Email Address");
                                StudentGroupTable.Columns.Remove("Group ID");

                            }

                            StudentGroupTable.Clear();  // clear the current data to make room for new data
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
                            var Index5 = 4;
                            var Index6 = 5;

                            // loop through each "listNewlyAddedStudents" and add them to DataTable row
                            for (var i = 0; i <= listNewlyAddedStudents.Count; i++)
                            {

                                // this ensures that four items are added to a row at once. it adds items by batch
                                if (lap > 6)
                                {

                                    lap = 1;
                                    // assign each list index to a cell in the row
                                    StudentGroupTable.Rows.Add(
                                        listNewlyAddedStudents[Index1],
                                        listNewlyAddedStudents[Index2],
                                        listNewlyAddedStudents[Index3],
                                        listNewlyAddedStudents[Index4],
                                        listNewlyAddedStudents[Index5],
                                        listNewlyAddedStudents[Index6]
                                        );

                                    // go to the next items on the list that needs to be added to Datatable row
                                    Index1 += 6;
                                    Index2 += 6;
                                    Index3 += 6;
                                    Index4 += 6;
                                    Index5 += 6;
                                    Index6 += 6;

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

                        MessageBox.Show("Import 'Manage Group' file was successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        MessageBox.Show("File doesn't exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid Operation.\n\n" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        // this asks the user if they really want to exit the application
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {

                DialogResult dialog = new DialogResult();
                // this makes sure the user remeber's to save any unsaved data
                dialog = MessageBox.Show("Do you want to exit this application?\n\n" +
                    "Note: All unsaved data will be lost. " +
                    "Please make sure you save your data before closing.\n",
                    "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    // The user wants to exit the application. Close everything down.
                    System.Environment.Exit(1);
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid operation. Please try to close the application again.\n\n" + ex,
                    "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }

        }
    }
}