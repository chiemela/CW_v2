using ClosedXML.Excel;
using CsvHelper;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Excel;
using System;
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
        int MGS_GetStudentID_Column;
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

        // this section puts the students into various groups in the Dictionary
        public static List<string> DeclareDictionary(List<string> list)
        {
            // variable diclarations
            int lap = 1;
            var Index2 = 1;
            var Index3 = 2;
            var Index4 = 3;
            var Index5 = 4;
            var Index6 = 5;
            int SerialNumber = 1;

            // delcare the dictionary to save all groups
            var StudentGrouping = new Dictionary<int, StudentGroups>();

            // loop through each "listNewlyAddedStudents" and add them to DataTable row
            for (int a = 0; a <= list.Count; a++)
            {
                // variable diclarations
                string test = "";
                string studentID = "";
                string FirstName = "";
                string LastName = "";
                string Email = "";
                string GroupID = "";
                string Grade = "30%";
                // this ensures that four items are added to a row at once. it adds items by batch
                if (lap > 6)
                {
                    try
                    {
                        lap = 1;
                        studentID = list[Index2];
                        FirstName = list[Index3];
                        LastName = list[Index4];
                        Email = list[Index5];
                        GroupID = list[Index6];
                        // Grade is not given by the lecturer yet
                        test = list[Index6];
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
            List<string> listNumber = new List<string>();
            --SerialNumber;
            foreach (var index in Enumerable.Range(1, SerialNumber))
            {
                string s = StudentGrouping[index].studentID + " " +
                    StudentGrouping[index].FirstName + " " +
                    StudentGrouping[index].LastName + " " +
                    StudentGrouping[index].Email + " " +
                    StudentGrouping[index].GroupID + " " +
                    StudentGrouping[index].Grade;
                listNumber.Add(s);
            }
            return listNumber;
        }

        // check how many times a groupID appears
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
            lblNumberOfStudent.Text = (listNewlyAddedStudents.Count / 4).ToString();

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

        private void btnImportStudentGroupingTable_Click(object sender, EventArgs e)
        {
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

        private void btnChooseStudent_Click(object sender, EventArgs e)
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

        private void comboBoxChangeGroupID_SelectedValueChanged(object sender, EventArgs e)
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
            // variable diclarations
            var lap = 1;
            var Index6 = 5;
            int NumIndex = 0;
            string MatchingValueString;
            int MatchingValueInt;
            bool GroupNumberExceeded = false;
            int[] Num = new int[(StudentGroupTable_ListCollection.Count / 6)];


            // loop through each "listNewlyAddedStudents" and add them to DataTable row
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
                MessageBox.Show("Groups saved without errors",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
            }
            // set the "labelVG_TotalGroups" to the correct number of groups
            labelVG_TotalGroups.Text = StudentGroupTable_GroupID.ToString();

            // save list into a Dictionary and return the Dictionary as list
            //listBoxManageGroupScore.DataSource = DeclareDictionary(StudentGroupTable_ListCollection);
        }

        private void listBoxViewStudentGrouping_MouseUp(object sender, MouseEventArgs e)
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

        private void btnChangeGroupID_Click(object sender, EventArgs e)
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

        private void comboBoxChooseGroup_SelectedValueChanged(object sender, EventArgs e)
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
            // loop through each "listNewlyAddedStudents" and add them to DataTable row
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
                        MatchingValues.Add("(" + (SerialNumber.ToString()) + ")     " + MatchingValueString);
                        SerialNumber++;
                    }
                }
                lap++;
            }
            listBoxViewGroups.DataSource = MatchingValues;
        }

        private void comboBoxMGS_ChooseGroup_SelectedValueChanged(object sender, EventArgs e)
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
            // loop through each "listNewlyAddedStudents" and add them to DataTable row
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
                        MatchingValues.Add("(" + (SerialNumber.ToString()) + ")     " + MatchingValueString);
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


            // Student details section on the "Manage Group Score" page
            int GroupStudentID_Column = 1;
            int GroupFirstName_Column = 2;
            int GroupLastName_Column = 3;
            //int GroupID_Column = 5;
            string? SelectedStudentIndex = listBoxManageGroupScore.GetItemText(listBoxManageGroupScore.SelectedIndex);
            var StudentIndexNumber = int.Parse(SelectedStudentIndex);
            // increment "StudentIndexNumber" to jump to the appropriate column in the row
            StudentIndexNumber++;
            // get the appropriate column index in the "StudentGroupTable_ListCollection"
            //ApprColumnIndex = GroupID_Column * StudentIndexNumber;
            MGS_GetStudentID_Column = GroupStudentID_Column * StudentIndexNumber;
            MGS_GetFirstName_Column = GroupFirstName_Column * StudentIndexNumber;
            MGS_GetLastName_Column = GroupLastName_Column * StudentIndexNumber;
            /* 
             * get the appropriate column index for each column in the "StudentGroupTable_ListCollection"
             * and without this, when you select from the second column in the list it always gets the previous
             * value
            */
            //ApprColumnIndex += --StudentIndexNumber;
            MGS_GetStudentID_Column += --StudentIndexNumber;
            MGS_GetFirstName_Column += --StudentIndexNumber;
            MGS_GetLastName_Column += --StudentIndexNumber;
            //lblCurrentGroupID.Text = StudentGroupTable_ListCollection[ApprColumnIndex];
            lblMGS_StudentID.Text = StudentGroupTable_ListCollection[MGS_GetStudentID_Column];
            lblMGS_StudentFullName.Text = StudentGroupTable_ListCollection[MGS_GetFirstName_Column];
            lblMGS_StudentScore.Text = StudentGroupTable_ListCollection[MGS_GetLastName_Column];
        }

        private void listBoxManageGroupScore_MouseUp(object sender, MouseEventArgs e)
        {
            int GroupStudentID_Column = 1;
            int GroupFirstName_Column = 2;
            int GroupLastName_Column = 3;
            //int GroupID_Column = 5;
            string? SelectedStudentIndex = listBoxManageGroupScore.GetItemText(listBoxManageGroupScore.SelectedIndex);
            var StudentIndexNumber = int.Parse(SelectedStudentIndex);
            // increment "StudentIndexNumber" to jump to the appropriate column in the row
            StudentIndexNumber++;
            // get the appropriate column index in the "StudentGroupTable_ListCollection"
            //ApprColumnIndex = GroupID_Column * StudentIndexNumber;
            MGS_GetStudentID_Column = GroupStudentID_Column * StudentIndexNumber;
            MGS_GetFirstName_Column = GroupFirstName_Column * StudentIndexNumber;
            MGS_GetLastName_Column = GroupLastName_Column * StudentIndexNumber;
            /* 
             * get the appropriate column index for each column in the "StudentGroupTable_ListCollection"
             * and without this, when you select from the second column in the list it always gets the previous
             * value
            */
            //ApprColumnIndex += --StudentIndexNumber;
            MGS_GetStudentID_Column += --StudentIndexNumber;
            MGS_GetFirstName_Column += --StudentIndexNumber;
            MGS_GetLastName_Column += --StudentIndexNumber;
            //lblCurrentGroupID.Text = StudentGroupTable_ListCollection[ApprColumnIndex];
            lblMGS_StudentID.Text = StudentGroupTable_ListCollection[MGS_GetStudentID_Column];
            lblMGS_StudentFullName.Text = StudentGroupTable_ListCollection[MGS_GetFirstName_Column];
            lblMGS_StudentScore.Text = StudentGroupTable_ListCollection[MGS_GetLastName_Column];
        }
    }
}