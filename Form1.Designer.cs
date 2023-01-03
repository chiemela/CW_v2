namespace CourseWorkManagementSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageManageStudents = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.lblNumberOfStudent = new System.Windows.Forms.Label();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.dataGridViewListItems = new System.Windows.Forms.DataGridView();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.dgvCsvImport = new System.Windows.Forms.DataGridView();
            this.studentIDnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImportNewCSV = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStudentIDnumber = new System.Windows.Forms.TextBox();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.tabPageManageGroups = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxManualSettings = new System.Windows.Forms.GroupBox();
            this.button_MG_ClearListBox = new System.Windows.Forms.Button();
            this.btnChangeGroupID = new System.Windows.Forms.Button();
            this.btnSaveGroups = new System.Windows.Forms.Button();
            this.labelAddOrMinusGroupFeedback = new System.Windows.Forms.Label();
            this.btnMinusGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.labelChangeGroupIDFeedback = new System.Windows.Forms.Label();
            this.comboBoxChangeGroupID = new System.Windows.Forms.ComboBox();
            this.labelChangeGroupID = new System.Windows.Forms.Label();
            this.labelCurrentGroupID = new System.Windows.Forms.Label();
            this.lblCurrentGroupID = new System.Windows.Forms.Label();
            this.btnChooseStudent = new System.Windows.Forms.Button();
            this.lblSelectedStudent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImportStudentGroupingTable = new System.Windows.Forms.Button();
            this.listBoxViewStudentGrouping = new System.Windows.Forms.ListBox();
            this.groupBoxStudentGroupingTable = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvStudentGroupingTable = new System.Windows.Forms.DataGridView();
            this.tabPageViewGroups = new System.Windows.Forms.TabPage();
            this.labelVG_Selected = new System.Windows.Forms.Label();
            this.labelVG_GroupSelected = new System.Windows.Forms.Label();
            this.labelVG_Group = new System.Windows.Forms.Label();
            this.labelVG_TotalGroups = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxChooseGroup = new System.Windows.Forms.ComboBox();
            this.labelChooseGroup = new System.Windows.Forms.Label();
            this.listBoxViewGroups = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageManageGroupScore = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblMGS_StudentScore = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMGS_StudentID = new System.Windows.Forms.Label();
            this.lblMGS_StudentFullName = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_MGS_AssignScore_Apply = new System.Windows.Forms.Button();
            this.textBox_MGS_AssignScore = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMGS_NumberOfStudents = new System.Windows.Forms.Label();
            this.labelMGS_NumberOfStudents = new System.Windows.Forms.Label();
            this.labelMGS_GroupSelected = new System.Windows.Forms.Label();
            this.labelMGS_Group = new System.Windows.Forms.Label();
            this.comboBoxMGS_ChooseGroup = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelMGS_TotalScoreGiven = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button_MGS_UpdateGroup = new System.Windows.Forms.Button();
            this.listBoxManageGroupScore = new System.Windows.Forms.ListBox();
            this.tabPageSavedData = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPageManageStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPageManageGroups.SuspendLayout();
            this.groupBoxManualSettings.SuspendLayout();
            this.groupBoxStudentGroupingTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentGroupingTable)).BeginInit();
            this.tabPageViewGroups.SuspendLayout();
            this.tabPageManageGroupScore.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageManageStudents);
            this.tabControl.Controls.Add(this.tabPageManageGroups);
            this.tabControl.Controls.Add(this.tabPageViewGroups);
            this.tabControl.Controls.Add(this.tabPageManageGroupScore);
            this.tabControl.Controls.Add(this.tabPageSavedData);
            this.tabControl.Location = new System.Drawing.Point(1, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(60, 20);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(2532, 1239);
            this.tabControl.TabIndex = 6;
            // 
            // tabPageManageStudents
            // 
            this.tabPageManageStudents.Controls.Add(this.label3);
            this.tabPageManageStudents.Controls.Add(this.btnSaveExcel);
            this.tabPageManageStudents.Controls.Add(this.lblNumberOfStudent);
            this.tabPageManageStudents.Controls.Add(this.btnDeleteStudent);
            this.tabPageManageStudents.Controls.Add(this.dataGridViewListItems);
            this.tabPageManageStudents.Controls.Add(this.lblFilePath);
            this.tabPageManageStudents.Controls.Add(this.dgvCsvImport);
            this.tabPageManageStudents.Controls.Add(this.groupBox1);
            this.tabPageManageStudents.Location = new System.Drawing.Point(10, 88);
            this.tabPageManageStudents.Name = "tabPageManageStudents";
            this.tabPageManageStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManageStudents.Size = new System.Drawing.Size(2512, 1141);
            this.tabPageManageStudents.TabIndex = 0;
            this.tabPageManageStudents.Text = "Manage Students";
            this.tabPageManageStudents.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 35);
            this.label3.TabIndex = 30;
            this.label3.Text = "Manage Students Page";
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(1992, 203);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(268, 78);
            this.btnSaveExcel.TabIndex = 29;
            this.btnSaveExcel.Text = "Save to Excel";
            this.btnSaveExcel.UseVisualStyleBackColor = true;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // lblNumberOfStudent
            // 
            this.lblNumberOfStudent.AutoSize = true;
            this.lblNumberOfStudent.Location = new System.Drawing.Point(667, 1084);
            this.lblNumberOfStudent.Name = "lblNumberOfStudent";
            this.lblNumberOfStudent.Size = new System.Drawing.Size(39, 41);
            this.lblNumberOfStudent.TabIndex = 28;
            this.lblNumberOfStudent.Text = "...";
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Location = new System.Drawing.Point(1992, 119);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(268, 78);
            this.btnDeleteStudent.TabIndex = 27;
            this.btnDeleteStudent.Text = "Delete Student";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // dataGridViewListItems
            // 
            this.dataGridViewListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListItems.Location = new System.Drawing.Point(667, 119);
            this.dataGridViewListItems.Name = "dataGridViewListItems";
            this.dataGridViewListItems.RowHeadersWidth = 102;
            this.dataGridViewListItems.RowTemplate.Height = 49;
            this.dataGridViewListItems.Size = new System.Drawing.Size(1319, 953);
            this.dataGridViewListItems.TabIndex = 26;
            this.dataGridViewListItems.Visible = false;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(667, 61);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(177, 41);
            this.lblFilePath.TabIndex = 25;
            this.lblFilePath.Text = "File location";
            // 
            // dgvCsvImport
            // 
            this.dgvCsvImport.AutoGenerateColumns = false;
            this.dgvCsvImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCsvImport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentIDnumberDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.emailAddressDataGridViewTextBoxColumn});
            this.dgvCsvImport.DataSource = this.studentBindingSource;
            this.dgvCsvImport.Location = new System.Drawing.Point(667, 119);
            this.dgvCsvImport.Name = "dgvCsvImport";
            this.dgvCsvImport.ReadOnly = true;
            this.dgvCsvImport.RowHeadersWidth = 102;
            this.dgvCsvImport.RowTemplate.Height = 49;
            this.dgvCsvImport.Size = new System.Drawing.Size(1319, 953);
            this.dgvCsvImport.TabIndex = 24;
            // 
            // studentIDnumberDataGridViewTextBoxColumn
            // 
            this.studentIDnumberDataGridViewTextBoxColumn.DataPropertyName = "studentIDnumber";
            this.studentIDnumberDataGridViewTextBoxColumn.HeaderText = "studentIDnumber";
            this.studentIDnumberDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.studentIDnumberDataGridViewTextBoxColumn.Name = "studentIDnumberDataGridViewTextBoxColumn";
            this.studentIDnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.studentIDnumberDataGridViewTextBoxColumn.Width = 250;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "firstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "firstName";
            this.firstNameDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.firstNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "lastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "lastName";
            this.lastNameDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // emailAddressDataGridViewTextBoxColumn
            // 
            this.emailAddressDataGridViewTextBoxColumn.DataPropertyName = "emailAddress";
            this.emailAddressDataGridViewTextBoxColumn.HeaderText = "emailAddress";
            this.emailAddressDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.emailAddressDataGridViewTextBoxColumn.Name = "emailAddressDataGridViewTextBoxColumn";
            this.emailAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailAddressDataGridViewTextBoxColumn.Width = 250;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(CourseWorkManagementSystem.Student);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImportNewCSV);
            this.groupBox1.Controls.Add(this.btnResetForm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEmailAddress);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.txtStudentIDnumber);
            this.groupBox1.Controls.Add(this.btnAddStudent);
            this.groupBox1.Location = new System.Drawing.Point(47, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 974);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Students Form";
            // 
            // btnImportNewCSV
            // 
            this.btnImportNewCSV.Location = new System.Drawing.Point(35, 809);
            this.btnImportNewCSV.Name = "btnImportNewCSV";
            this.btnImportNewCSV.Size = new System.Drawing.Size(514, 105);
            this.btnImportNewCSV.TabIndex = 18;
            this.btnImportNewCSV.Text = "Import from CSV File";
            this.btnImportNewCSV.UseVisualStyleBackColor = true;
            this.btnImportNewCSV.Click += new System.EventHandler(this.btnImportNewCSV_Click);
            // 
            // btnResetForm
            // 
            this.btnResetForm.Location = new System.Drawing.Point(35, 593);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(514, 105);
            this.btnResetForm.TabIndex = 20;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(257, 743);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 35);
            this.label2.TabIndex = 18;
            this.label2.Text = "OR";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(35, 345);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.PlaceholderText = "Email Address";
            this.txtEmailAddress.Size = new System.Drawing.Size(514, 47);
            this.txtEmailAddress.TabIndex = 17;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(35, 252);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderText = "Last Name";
            this.txtLastName.Size = new System.Drawing.Size(514, 47);
            this.txtLastName.TabIndex = 16;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(35, 165);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderText = "First Name";
            this.txtFirstName.Size = new System.Drawing.Size(514, 47);
            this.txtFirstName.TabIndex = 15;
            // 
            // txtStudentIDnumber
            // 
            this.txtStudentIDnumber.Location = new System.Drawing.Point(35, 83);
            this.txtStudentIDnumber.Name = "txtStudentIDnumber";
            this.txtStudentIDnumber.PlaceholderText = "Student ID Number";
            this.txtStudentIDnumber.Size = new System.Drawing.Size(514, 47);
            this.txtStudentIDnumber.TabIndex = 14;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(35, 463);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(514, 105);
            this.btnAddStudent.TabIndex = 13;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // tabPageManageGroups
            // 
            this.tabPageManageGroups.Controls.Add(this.label1);
            this.tabPageManageGroups.Controls.Add(this.groupBoxManualSettings);
            this.tabPageManageGroups.Controls.Add(this.groupBoxStudentGroupingTable);
            this.tabPageManageGroups.Location = new System.Drawing.Point(10, 88);
            this.tabPageManageGroups.Name = "tabPageManageGroups";
            this.tabPageManageGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManageGroups.Size = new System.Drawing.Size(2512, 1141);
            this.tabPageManageGroups.TabIndex = 1;
            this.tabPageManageGroups.Text = "Manage Groups";
            this.tabPageManageGroups.UseVisualStyleBackColor = true;
            this.tabPageManageGroups.Click += new System.EventHandler(this.tabPageManageGroups_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 35);
            this.label1.TabIndex = 31;
            this.label1.Text = "Manage Groups Page";
            // 
            // groupBoxManualSettings
            // 
            this.groupBoxManualSettings.Controls.Add(this.button_MG_ClearListBox);
            this.groupBoxManualSettings.Controls.Add(this.btnChangeGroupID);
            this.groupBoxManualSettings.Controls.Add(this.btnSaveGroups);
            this.groupBoxManualSettings.Controls.Add(this.labelAddOrMinusGroupFeedback);
            this.groupBoxManualSettings.Controls.Add(this.btnMinusGroup);
            this.groupBoxManualSettings.Controls.Add(this.btnAddGroup);
            this.groupBoxManualSettings.Controls.Add(this.labelChangeGroupIDFeedback);
            this.groupBoxManualSettings.Controls.Add(this.comboBoxChangeGroupID);
            this.groupBoxManualSettings.Controls.Add(this.labelChangeGroupID);
            this.groupBoxManualSettings.Controls.Add(this.labelCurrentGroupID);
            this.groupBoxManualSettings.Controls.Add(this.lblCurrentGroupID);
            this.groupBoxManualSettings.Controls.Add(this.btnChooseStudent);
            this.groupBoxManualSettings.Controls.Add(this.lblSelectedStudent);
            this.groupBoxManualSettings.Controls.Add(this.label4);
            this.groupBoxManualSettings.Controls.Add(this.btnImportStudentGroupingTable);
            this.groupBoxManualSettings.Controls.Add(this.listBoxViewStudentGrouping);
            this.groupBoxManualSettings.Location = new System.Drawing.Point(1073, 93);
            this.groupBoxManualSettings.Name = "groupBoxManualSettings";
            this.groupBoxManualSettings.Size = new System.Drawing.Size(1410, 1001);
            this.groupBoxManualSettings.TabIndex = 16;
            this.groupBoxManualSettings.TabStop = false;
            this.groupBoxManualSettings.Text = "Manual Settings";
            // 
            // button_MG_ClearListBox
            // 
            this.button_MG_ClearListBox.Location = new System.Drawing.Point(1166, 611);
            this.button_MG_ClearListBox.Name = "button_MG_ClearListBox";
            this.button_MG_ClearListBox.Size = new System.Drawing.Size(224, 55);
            this.button_MG_ClearListBox.TabIndex = 36;
            this.button_MG_ClearListBox.Text = "Clear ListBox";
            this.button_MG_ClearListBox.UseVisualStyleBackColor = true;
            this.button_MG_ClearListBox.Click += new System.EventHandler(this.button_MG_ClearListBox_Click);
            // 
            // btnChangeGroupID
            // 
            this.btnChangeGroupID.Location = new System.Drawing.Point(352, 822);
            this.btnChangeGroupID.Name = "btnChangeGroupID";
            this.btnChangeGroupID.Size = new System.Drawing.Size(249, 49);
            this.btnChangeGroupID.TabIndex = 35;
            this.btnChangeGroupID.Text = "Change";
            this.btnChangeGroupID.UseVisualStyleBackColor = true;
            this.btnChangeGroupID.Click += new System.EventHandler(this.btnChangeGroupID_Click);
            // 
            // btnSaveGroups
            // 
            this.btnSaveGroups.Location = new System.Drawing.Point(1166, 877);
            this.btnSaveGroups.Name = "btnSaveGroups";
            this.btnSaveGroups.Size = new System.Drawing.Size(224, 105);
            this.btnSaveGroups.TabIndex = 34;
            this.btnSaveGroups.Text = "Save Groups";
            this.btnSaveGroups.UseVisualStyleBackColor = true;
            this.btnSaveGroups.Click += new System.EventHandler(this.btnSaveGroups_Click);
            // 
            // labelAddOrMinusGroupFeedback
            // 
            this.labelAddOrMinusGroupFeedback.AutoSize = true;
            this.labelAddOrMinusGroupFeedback.Location = new System.Drawing.Point(1052, 719);
            this.labelAddOrMinusGroupFeedback.Name = "labelAddOrMinusGroupFeedback";
            this.labelAddOrMinusGroupFeedback.Size = new System.Drawing.Size(39, 41);
            this.labelAddOrMinusGroupFeedback.TabIndex = 33;
            this.labelAddOrMinusGroupFeedback.Text = "...";
            // 
            // btnMinusGroup
            // 
            this.btnMinusGroup.Location = new System.Drawing.Point(938, 877);
            this.btnMinusGroup.Name = "btnMinusGroup";
            this.btnMinusGroup.Size = new System.Drawing.Size(222, 105);
            this.btnMinusGroup.TabIndex = 32;
            this.btnMinusGroup.Text = "Minus Group";
            this.btnMinusGroup.UseVisualStyleBackColor = true;
            this.btnMinusGroup.Click += new System.EventHandler(this.btnMinusGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(719, 877);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(213, 105);
            this.btnAddGroup.TabIndex = 31;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // labelChangeGroupIDFeedback
            // 
            this.labelChangeGroupIDFeedback.AutoSize = true;
            this.labelChangeGroupIDFeedback.Location = new System.Drawing.Point(698, 719);
            this.labelChangeGroupIDFeedback.Name = "labelChangeGroupIDFeedback";
            this.labelChangeGroupIDFeedback.Size = new System.Drawing.Size(39, 41);
            this.labelChangeGroupIDFeedback.TabIndex = 29;
            this.labelChangeGroupIDFeedback.Text = "...";
            // 
            // comboBoxChangeGroupID
            // 
            this.comboBoxChangeGroupID.FormattingEnabled = true;
            this.comboBoxChangeGroupID.Location = new System.Drawing.Point(352, 763);
            this.comboBoxChangeGroupID.Name = "comboBoxChangeGroupID";
            this.comboBoxChangeGroupID.Size = new System.Drawing.Size(249, 49);
            this.comboBoxChangeGroupID.TabIndex = 28;
            this.comboBoxChangeGroupID.Text = "Select...";
            this.comboBoxChangeGroupID.SelectedValueChanged += new System.EventHandler(this.comboBoxChangeGroupID_SelectedValueChanged);
            // 
            // labelChangeGroupID
            // 
            this.labelChangeGroupID.AutoSize = true;
            this.labelChangeGroupID.Location = new System.Drawing.Point(352, 719);
            this.labelChangeGroupID.Name = "labelChangeGroupID";
            this.labelChangeGroupID.Size = new System.Drawing.Size(249, 41);
            this.labelChangeGroupID.TabIndex = 27;
            this.labelChangeGroupID.Text = "Change Group ID";
            // 
            // labelCurrentGroupID
            // 
            this.labelCurrentGroupID.AutoSize = true;
            this.labelCurrentGroupID.Location = new System.Drawing.Point(20, 719);
            this.labelCurrentGroupID.Name = "labelCurrentGroupID";
            this.labelCurrentGroupID.Size = new System.Drawing.Size(246, 41);
            this.labelCurrentGroupID.TabIndex = 26;
            this.labelCurrentGroupID.Text = "Current Group ID";
            // 
            // lblCurrentGroupID
            // 
            this.lblCurrentGroupID.AutoSize = true;
            this.lblCurrentGroupID.Location = new System.Drawing.Point(20, 751);
            this.lblCurrentGroupID.Name = "lblCurrentGroupID";
            this.lblCurrentGroupID.Size = new System.Drawing.Size(39, 41);
            this.lblCurrentGroupID.TabIndex = 25;
            this.lblCurrentGroupID.Text = "...";
            // 
            // btnChooseStudent
            // 
            this.btnChooseStudent.Location = new System.Drawing.Point(474, 877);
            this.btnChooseStudent.Name = "btnChooseStudent";
            this.btnChooseStudent.Size = new System.Drawing.Size(239, 105);
            this.btnChooseStudent.TabIndex = 24;
            this.btnChooseStudent.Text = "Choose Student";
            this.btnChooseStudent.UseVisualStyleBackColor = true;
            this.btnChooseStudent.Click += new System.EventHandler(this.btnChooseStudent_Click);
            // 
            // lblSelectedStudent
            // 
            this.lblSelectedStudent.AutoSize = true;
            this.lblSelectedStudent.Location = new System.Drawing.Point(20, 652);
            this.lblSelectedStudent.Name = "lblSelectedStudent";
            this.lblSelectedStudent.Size = new System.Drawing.Size(39, 41);
            this.lblSelectedStudent.TabIndex = 21;
            this.lblSelectedStudent.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 611);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 41);
            this.label4.TabIndex = 20;
            this.label4.Text = "Selected Student";
            // 
            // btnImportStudentGroupingTable
            // 
            this.btnImportStudentGroupingTable.Location = new System.Drawing.Point(20, 877);
            this.btnImportStudentGroupingTable.Name = "btnImportStudentGroupingTable";
            this.btnImportStudentGroupingTable.Size = new System.Drawing.Size(448, 105);
            this.btnImportStudentGroupingTable.TabIndex = 19;
            this.btnImportStudentGroupingTable.Text = "Import Student Grouping Table";
            this.btnImportStudentGroupingTable.UseVisualStyleBackColor = true;
            this.btnImportStudentGroupingTable.Click += new System.EventHandler(this.btnImportStudentGroupingTable_Click);
            // 
            // listBoxViewStudentGrouping
            // 
            this.listBoxViewStudentGrouping.FormattingEnabled = true;
            this.listBoxViewStudentGrouping.ItemHeight = 41;
            this.listBoxViewStudentGrouping.Location = new System.Drawing.Point(20, 61);
            this.listBoxViewStudentGrouping.Name = "listBoxViewStudentGrouping";
            this.listBoxViewStudentGrouping.Size = new System.Drawing.Size(1370, 537);
            this.listBoxViewStudentGrouping.TabIndex = 0;
            this.listBoxViewStudentGrouping.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxViewStudentGrouping_MouseUp);
            // 
            // groupBoxStudentGroupingTable
            // 
            this.groupBoxStudentGroupingTable.Controls.Add(this.label5);
            this.groupBoxStudentGroupingTable.Controls.Add(this.dgvStudentGroupingTable);
            this.groupBoxStudentGroupingTable.Location = new System.Drawing.Point(22, 93);
            this.groupBoxStudentGroupingTable.Name = "groupBoxStudentGroupingTable";
            this.groupBoxStudentGroupingTable.Size = new System.Drawing.Size(1028, 1001);
            this.groupBoxStudentGroupingTable.TabIndex = 15;
            this.groupBoxStudentGroupingTable.TabStop = false;
            this.groupBoxStudentGroupingTable.Text = "Student Grouping Table";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 787);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 41);
            this.label5.TabIndex = 28;
            // 
            // dgvStudentGroupingTable
            // 
            this.dgvStudentGroupingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentGroupingTable.Location = new System.Drawing.Point(19, 62);
            this.dgvStudentGroupingTable.Name = "dgvStudentGroupingTable";
            this.dgvStudentGroupingTable.ReadOnly = true;
            this.dgvStudentGroupingTable.RowHeadersWidth = 102;
            this.dgvStudentGroupingTable.RowTemplate.Height = 49;
            this.dgvStudentGroupingTable.Size = new System.Drawing.Size(989, 722);
            this.dgvStudentGroupingTable.TabIndex = 27;
            // 
            // tabPageViewGroups
            // 
            this.tabPageViewGroups.Controls.Add(this.labelVG_Selected);
            this.tabPageViewGroups.Controls.Add(this.labelVG_GroupSelected);
            this.tabPageViewGroups.Controls.Add(this.labelVG_Group);
            this.tabPageViewGroups.Controls.Add(this.labelVG_TotalGroups);
            this.tabPageViewGroups.Controls.Add(this.label7);
            this.tabPageViewGroups.Controls.Add(this.comboBoxChooseGroup);
            this.tabPageViewGroups.Controls.Add(this.labelChooseGroup);
            this.tabPageViewGroups.Controls.Add(this.listBoxViewGroups);
            this.tabPageViewGroups.Controls.Add(this.label6);
            this.tabPageViewGroups.Location = new System.Drawing.Point(10, 88);
            this.tabPageViewGroups.Name = "tabPageViewGroups";
            this.tabPageViewGroups.Size = new System.Drawing.Size(2512, 1141);
            this.tabPageViewGroups.TabIndex = 2;
            this.tabPageViewGroups.Text = "View Groups";
            this.tabPageViewGroups.UseVisualStyleBackColor = true;
            // 
            // labelVG_Selected
            // 
            this.labelVG_Selected.AutoSize = true;
            this.labelVG_Selected.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelVG_Selected.Location = new System.Drawing.Point(2128, 436);
            this.labelVG_Selected.Name = "labelVG_Selected";
            this.labelVG_Selected.Size = new System.Drawing.Size(183, 46);
            this.labelVG_Selected.TabIndex = 42;
            this.labelVG_Selected.Text = "Selected";
            this.labelVG_Selected.Visible = false;
            // 
            // labelVG_GroupSelected
            // 
            this.labelVG_GroupSelected.AutoSize = true;
            this.labelVG_GroupSelected.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelVG_GroupSelected.Location = new System.Drawing.Point(2159, 278);
            this.labelVG_GroupSelected.Name = "labelVG_GroupSelected";
            this.labelVG_GroupSelected.Size = new System.Drawing.Size(126, 139);
            this.labelVG_GroupSelected.TabIndex = 41;
            this.labelVG_GroupSelected.Text = "4";
            this.labelVG_GroupSelected.Visible = false;
            // 
            // labelVG_Group
            // 
            this.labelVG_Group.AutoSize = true;
            this.labelVG_Group.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelVG_Group.Location = new System.Drawing.Point(2147, 215);
            this.labelVG_Group.Name = "labelVG_Group";
            this.labelVG_Group.Size = new System.Drawing.Size(138, 46);
            this.labelVG_Group.TabIndex = 40;
            this.labelVG_Group.Text = "Group";
            this.labelVG_Group.Visible = false;
            // 
            // labelVG_TotalGroups
            // 
            this.labelVG_TotalGroups.AutoSize = true;
            this.labelVG_TotalGroups.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelVG_TotalGroups.Location = new System.Drawing.Point(197, 278);
            this.labelVG_TotalGroups.Name = "labelVG_TotalGroups";
            this.labelVG_TotalGroups.Size = new System.Drawing.Size(126, 139);
            this.labelVG_TotalGroups.TabIndex = 39;
            this.labelVG_TotalGroups.Text = "4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(130, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 46);
            this.label7.TabIndex = 37;
            this.label7.Text = "Total Groups";
            // 
            // comboBoxChooseGroup
            // 
            this.comboBoxChooseGroup.FormattingEnabled = true;
            this.comboBoxChooseGroup.Location = new System.Drawing.Point(1069, 722);
            this.comboBoxChooseGroup.Name = "comboBoxChooseGroup";
            this.comboBoxChooseGroup.Size = new System.Drawing.Size(306, 49);
            this.comboBoxChooseGroup.TabIndex = 36;
            this.comboBoxChooseGroup.SelectedValueChanged += new System.EventHandler(this.comboBoxChooseGroup_SelectedValueChanged);
            // 
            // labelChooseGroup
            // 
            this.labelChooseGroup.AutoSize = true;
            this.labelChooseGroup.Location = new System.Drawing.Point(1120, 666);
            this.labelChooseGroup.Name = "labelChooseGroup";
            this.labelChooseGroup.Size = new System.Drawing.Size(211, 41);
            this.labelChooseGroup.TabIndex = 35;
            this.labelChooseGroup.Text = "Choose Group";
            // 
            // listBoxViewGroups
            // 
            this.listBoxViewGroups.FormattingEnabled = true;
            this.listBoxViewGroups.ItemHeight = 41;
            this.listBoxViewGroups.Location = new System.Drawing.Point(555, 96);
            this.listBoxViewGroups.Name = "listBoxViewGroups";
            this.listBoxViewGroups.Size = new System.Drawing.Size(1370, 537);
            this.listBoxViewGroups.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(22, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(278, 35);
            this.label6.TabIndex = 32;
            this.label6.Text = "View Groups Page";
            // 
            // tabPageManageGroupScore
            // 
            this.tabPageManageGroupScore.Controls.Add(this.groupBox3);
            this.tabPageManageGroupScore.Controls.Add(this.label15);
            this.tabPageManageGroupScore.Controls.Add(this.groupBox2);
            this.tabPageManageGroupScore.Controls.Add(this.listBoxManageGroupScore);
            this.tabPageManageGroupScore.Location = new System.Drawing.Point(10, 88);
            this.tabPageManageGroupScore.Name = "tabPageManageGroupScore";
            this.tabPageManageGroupScore.Size = new System.Drawing.Size(2512, 1141);
            this.tabPageManageGroupScore.TabIndex = 3;
            this.tabPageManageGroupScore.Text = "Manage Group Score";
            this.tabPageManageGroupScore.UseVisualStyleBackColor = true;
            this.tabPageManageGroupScore.Enter += new System.EventHandler(this.tabPageManageGroupScore_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.lblMGS_StudentScore);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lblMGS_StudentID);
            this.groupBox3.Controls.Add(this.lblMGS_StudentFullName);
            this.groupBox3.Location = new System.Drawing.Point(45, 688);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1370, 386);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Student details";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 269);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(200, 41);
            this.label17.TabIndex = 38;
            this.label17.Text = "Student score";
            // 
            // lblMGS_StudentScore
            // 
            this.lblMGS_StudentScore.AutoSize = true;
            this.lblMGS_StudentScore.Location = new System.Drawing.Point(28, 301);
            this.lblMGS_StudentScore.Name = "lblMGS_StudentScore";
            this.lblMGS_StudentScore.Size = new System.Drawing.Size(39, 41);
            this.lblMGS_StudentScore.TabIndex = 37;
            this.lblMGS_StudentScore.Text = "...";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 41);
            this.label16.TabIndex = 33;
            this.label16.Text = "Student ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(251, 41);
            this.label10.TabIndex = 36;
            this.label10.Text = "Student full name";
            // 
            // lblMGS_StudentID
            // 
            this.lblMGS_StudentID.AutoSize = true;
            this.lblMGS_StudentID.Location = new System.Drawing.Point(28, 103);
            this.lblMGS_StudentID.Name = "lblMGS_StudentID";
            this.lblMGS_StudentID.Size = new System.Drawing.Size(39, 41);
            this.lblMGS_StudentID.TabIndex = 34;
            this.lblMGS_StudentID.Text = "...";
            // 
            // lblMGS_StudentFullName
            // 
            this.lblMGS_StudentFullName.AutoSize = true;
            this.lblMGS_StudentFullName.Location = new System.Drawing.Point(28, 202);
            this.lblMGS_StudentFullName.Name = "lblMGS_StudentFullName";
            this.lblMGS_StudentFullName.Size = new System.Drawing.Size(39, 41);
            this.lblMGS_StudentFullName.TabIndex = 35;
            this.lblMGS_StudentFullName.Text = "...";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(22, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(396, 35);
            this.label15.TabIndex = 32;
            this.label15.Text = "Manage Group Score Page";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_MGS_AssignScore_Apply);
            this.groupBox2.Controls.Add(this.textBox_MGS_AssignScore);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblMGS_NumberOfStudents);
            this.groupBox2.Controls.Add(this.labelMGS_NumberOfStudents);
            this.groupBox2.Controls.Add(this.labelMGS_GroupSelected);
            this.groupBox2.Controls.Add(this.labelMGS_Group);
            this.groupBox2.Controls.Add(this.comboBoxMGS_ChooseGroup);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.labelMGS_TotalScoreGiven);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button_MGS_UpdateGroup);
            this.groupBox2.Location = new System.Drawing.Point(1498, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(965, 1004);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Group score details";
            // 
            // button_MGS_AssignScore_Apply
            // 
            this.button_MGS_AssignScore_Apply.Location = new System.Drawing.Point(340, 662);
            this.button_MGS_AssignScore_Apply.Name = "button_MGS_AssignScore_Apply";
            this.button_MGS_AssignScore_Apply.Size = new System.Drawing.Size(230, 58);
            this.button_MGS_AssignScore_Apply.TabIndex = 52;
            this.button_MGS_AssignScore_Apply.Text = "Apply";
            this.button_MGS_AssignScore_Apply.UseVisualStyleBackColor = true;
            this.button_MGS_AssignScore_Apply.Click += new System.EventHandler(this.button_MGS_AssignScore_Apply_Click);
            // 
            // textBox_MGS_AssignScore
            // 
            this.textBox_MGS_AssignScore.Location = new System.Drawing.Point(340, 609);
            this.textBox_MGS_AssignScore.Name = "textBox_MGS_AssignScore";
            this.textBox_MGS_AssignScore.Size = new System.Drawing.Size(230, 47);
            this.textBox_MGS_AssignScore.TabIndex = 51;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(340, 551);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(230, 41);
            this.label13.TabIndex = 50;
            this.label13.Text = "Assign Score(%)";
            // 
            // lblMGS_NumberOfStudents
            // 
            this.lblMGS_NumberOfStudents.AutoSize = true;
            this.lblMGS_NumberOfStudents.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMGS_NumberOfStudents.Location = new System.Drawing.Point(619, 351);
            this.lblMGS_NumberOfStudents.Name = "lblMGS_NumberOfStudents";
            this.lblMGS_NumberOfStudents.Size = new System.Drawing.Size(126, 139);
            this.lblMGS_NumberOfStudents.TabIndex = 49;
            this.lblMGS_NumberOfStudents.Text = "4";
            this.lblMGS_NumberOfStudents.Visible = false;
            // 
            // labelMGS_NumberOfStudents
            // 
            this.labelMGS_NumberOfStudents.AutoSize = true;
            this.labelMGS_NumberOfStudents.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMGS_NumberOfStudents.Location = new System.Drawing.Point(524, 305);
            this.labelMGS_NumberOfStudents.Name = "labelMGS_NumberOfStudents";
            this.labelMGS_NumberOfStudents.Size = new System.Drawing.Size(305, 46);
            this.labelMGS_NumberOfStudents.TabIndex = 48;
            this.labelMGS_NumberOfStudents.Text = "No. of students";
            this.labelMGS_NumberOfStudents.Visible = false;
            // 
            // labelMGS_GroupSelected
            // 
            this.labelMGS_GroupSelected.AutoSize = true;
            this.labelMGS_GroupSelected.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMGS_GroupSelected.Location = new System.Drawing.Point(619, 116);
            this.labelMGS_GroupSelected.Name = "labelMGS_GroupSelected";
            this.labelMGS_GroupSelected.Size = new System.Drawing.Size(126, 139);
            this.labelMGS_GroupSelected.TabIndex = 47;
            this.labelMGS_GroupSelected.Text = "4";
            this.labelMGS_GroupSelected.Visible = false;
            // 
            // labelMGS_Group
            // 
            this.labelMGS_Group.AutoSize = true;
            this.labelMGS_Group.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMGS_Group.Location = new System.Drawing.Point(607, 70);
            this.labelMGS_Group.Name = "labelMGS_Group";
            this.labelMGS_Group.Size = new System.Drawing.Size(138, 46);
            this.labelMGS_Group.TabIndex = 46;
            this.labelMGS_Group.Text = "Group";
            this.labelMGS_Group.Visible = false;
            // 
            // comboBoxMGS_ChooseGroup
            // 
            this.comboBoxMGS_ChooseGroup.FormattingEnabled = true;
            this.comboBoxMGS_ChooseGroup.Location = new System.Drawing.Point(69, 607);
            this.comboBoxMGS_ChooseGroup.Name = "comboBoxMGS_ChooseGroup";
            this.comboBoxMGS_ChooseGroup.Size = new System.Drawing.Size(211, 49);
            this.comboBoxMGS_ChooseGroup.TabIndex = 45;
            this.comboBoxMGS_ChooseGroup.SelectedValueChanged += new System.EventHandler(this.comboBoxMGS_ChooseGroup_SelectedValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 551);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(211, 41);
            this.label12.TabIndex = 44;
            this.label12.Text = "Choose Group";
            // 
            // labelMGS_TotalScoreGiven
            // 
            this.labelMGS_TotalScoreGiven.AutoSize = true;
            this.labelMGS_TotalScoreGiven.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMGS_TotalScoreGiven.Location = new System.Drawing.Point(102, 351);
            this.labelMGS_TotalScoreGiven.Name = "labelMGS_TotalScoreGiven";
            this.labelMGS_TotalScoreGiven.Size = new System.Drawing.Size(299, 139);
            this.labelMGS_TotalScoreGiven.TabIndex = 43;
            this.labelMGS_TotalScoreGiven.Text = "90%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(69, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(340, 46);
            this.label11.TabIndex = 42;
            this.label11.Text = "Total score given";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(102, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(299, 139);
            this.label8.TabIndex = 41;
            this.label8.Text = "90%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(69, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(364, 46);
            this.label9.TabIndex = 40;
            this.label9.Text = "Max score allotted";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(483, 865);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 105);
            this.button2.TabIndex = 34;
            this.button2.Text = "Save Groups";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(255, 865);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(222, 105);
            this.button3.TabIndex = 32;
            this.button3.Text = "Minus Group";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button_MGS_UpdateGroup
            // 
            this.button_MGS_UpdateGroup.Location = new System.Drawing.Point(22, 865);
            this.button_MGS_UpdateGroup.Name = "button_MGS_UpdateGroup";
            this.button_MGS_UpdateGroup.Size = new System.Drawing.Size(226, 105);
            this.button_MGS_UpdateGroup.TabIndex = 31;
            this.button_MGS_UpdateGroup.Text = "Update Group";
            this.button_MGS_UpdateGroup.UseVisualStyleBackColor = true;
            this.button_MGS_UpdateGroup.Click += new System.EventHandler(this.button_MGS_UpdateGroup_Click);
            // 
            // listBoxManageGroupScore
            // 
            this.listBoxManageGroupScore.FormattingEnabled = true;
            this.listBoxManageGroupScore.ItemHeight = 41;
            this.listBoxManageGroupScore.Location = new System.Drawing.Point(45, 125);
            this.listBoxManageGroupScore.Name = "listBoxManageGroupScore";
            this.listBoxManageGroupScore.Size = new System.Drawing.Size(1370, 537);
            this.listBoxManageGroupScore.TabIndex = 0;
            this.listBoxManageGroupScore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxManageGroupScore_MouseUp);
            // 
            // tabPageSavedData
            // 
            this.tabPageSavedData.Location = new System.Drawing.Point(10, 88);
            this.tabPageSavedData.Name = "tabPageSavedData";
            this.tabPageSavedData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSavedData.Size = new System.Drawing.Size(2512, 1141);
            this.tabPageSavedData.TabIndex = 4;
            this.tabPageSavedData.Text = "Saved Data";
            this.tabPageSavedData.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2532, 1245);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CourseWork Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageManageStudents.ResumeLayout(false);
            this.tabPageManageStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageManageGroups.ResumeLayout(false);
            this.tabPageManageGroups.PerformLayout();
            this.groupBoxManualSettings.ResumeLayout(false);
            this.groupBoxManualSettings.PerformLayout();
            this.groupBoxStudentGroupingTable.ResumeLayout(false);
            this.groupBoxStudentGroupingTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentGroupingTable)).EndInit();
            this.tabPageViewGroups.ResumeLayout(false);
            this.tabPageViewGroups.PerformLayout();
            this.tabPageManageGroupScore.ResumeLayout(false);
            this.tabPageManageGroupScore.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl;
        private TabPage tabPageManageStudents;
        private TabPage tabPageManageGroups;
        private TabPage tabPageViewGroups;
        private TabPage tabPageManageGroupScore;
        private TabPage tabPageSavedData;
        private BindingSource studentBindingSource;
        private Button btnSaveExcel;
        private Label lblNumberOfStudent;
        private Button btnDeleteStudent;
        private DataGridView dataGridViewListItems;
        private Label lblFilePath;
        private DataGridView dgvCsvImport;
        private DataGridViewTextBoxColumn studentIDnumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailAddressDataGridViewTextBoxColumn;
        private GroupBox groupBox1;
        private Button btnImportNewCSV;
        private Button btnResetForm;
        private Label label2;
        private TextBox txtEmailAddress;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtStudentIDnumber;
        private Button btnAddStudent;
        private Label label3;
        private GroupBox groupBoxStudentGroupingTable;
        private DataGridView dgvStudentGroupingTable;
        private Label label1;
        private GroupBox groupBoxManualSettings;
        private Button btnImportStudentGroupingTable;
        private ListBox listBoxViewStudentGrouping;
        private Label lblSelectedStudent;
        private Label label4;
        private Button btnChooseStudent;
        private Label labelCurrentGroupID;
        private Label lblCurrentGroupID;
        private ComboBox comboBoxChangeGroupID;
        private Label labelChangeGroupID;
        private Label labelChangeGroupIDFeedback;
        private Button btnAddGroup;
        private Button btnMinusGroup;
        private Label labelAddOrMinusGroupFeedback;
        private Button btnSaveGroups;
        private Button btnChangeGroupID;
        private Label label5;
        private Label labelChooseGroup;
        private ListBox listBoxViewGroups;
        private Label label6;
        private ComboBox comboBoxChooseGroup;
        private Label labelVG_Selected;
        private Label labelVG_GroupSelected;
        private Label labelVG_Group;
        private Label labelVG_TotalGroups;
        private Label label7;
        private Label label15;
        private GroupBox groupBox2;
        private ComboBox comboBoxMGS_ChooseGroup;
        private Label label12;
        private Label labelMGS_TotalScoreGiven;
        private Label label11;
        private Label label8;
        private Label label9;
        private Button button2;
        private Button button3;
        private Button button_MGS_UpdateGroup;
        private ListBox listBoxManageGroupScore;
        public Label labelMGS_GroupSelected;
        public Label labelMGS_Group;
        private GroupBox groupBox3;
        private Label label17;
        private Label lblMGS_StudentScore;
        private Label label16;
        private Label label10;
        private Label lblMGS_StudentID;
        private Label lblMGS_StudentFullName;
        public Label lblMGS_NumberOfStudents;
        public Label labelMGS_NumberOfStudents;
        private Label label13;
        private Button button_MGS_AssignScore_Apply;
        private TextBox textBox_MGS_AssignScore;
        private Button button_MG_ClearListBox;
    }
}