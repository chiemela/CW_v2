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
            this.btnGroupStudentManually = new System.Windows.Forms.Button();
            this.groupBoxStudentGroupingTable = new System.Windows.Forms.GroupBox();
            this.dgvStudentGroupingTable = new System.Windows.Forms.DataGridView();
            this.tabPageViewGroups = new System.Windows.Forms.TabPage();
            this.tabPageManageGroupScore = new System.Windows.Forms.TabPage();
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
            this.groupBoxManualSettings.Controls.Add(this.btnGroupStudentManually);
            this.groupBoxManualSettings.Location = new System.Drawing.Point(1720, 6);
            this.groupBoxManualSettings.Name = "groupBoxManualSettings";
            this.groupBoxManualSettings.Size = new System.Drawing.Size(769, 1114);
            this.groupBoxManualSettings.TabIndex = 16;
            this.groupBoxManualSettings.TabStop = false;
            this.groupBoxManualSettings.Text = "Manual Settings";
            // 
            // btnGroupStudentManually
            // 
            this.btnGroupStudentManually.Location = new System.Drawing.Point(81, 717);
            this.btnGroupStudentManually.Name = "btnGroupStudentManually";
            this.btnGroupStudentManually.Size = new System.Drawing.Size(514, 105);
            this.btnGroupStudentManually.TabIndex = 18;
            this.btnGroupStudentManually.Text = "Group Student Manually";
            this.btnGroupStudentManually.UseVisualStyleBackColor = true;
            // 
            // groupBoxStudentGroupingTable
            // 
            this.groupBoxStudentGroupingTable.Controls.Add(this.dgvStudentGroupingTable);
            this.groupBoxStudentGroupingTable.Location = new System.Drawing.Point(22, 93);
            this.groupBoxStudentGroupingTable.Name = "groupBoxStudentGroupingTable";
            this.groupBoxStudentGroupingTable.Size = new System.Drawing.Size(1659, 807);
            this.groupBoxStudentGroupingTable.TabIndex = 15;
            this.groupBoxStudentGroupingTable.TabStop = false;
            this.groupBoxStudentGroupingTable.Text = "Student Grouping Table";
            // 
            // dgvStudentGroupingTable
            // 
            this.dgvStudentGroupingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentGroupingTable.Location = new System.Drawing.Point(19, 62);
            this.dgvStudentGroupingTable.Name = "dgvStudentGroupingTable";
            this.dgvStudentGroupingTable.ReadOnly = true;
            this.dgvStudentGroupingTable.RowHeadersWidth = 102;
            this.dgvStudentGroupingTable.RowTemplate.Height = 49;
            this.dgvStudentGroupingTable.Size = new System.Drawing.Size(1622, 722);
            this.dgvStudentGroupingTable.TabIndex = 27;
            // 
            // tabPageViewGroups
            // 
            this.tabPageViewGroups.Location = new System.Drawing.Point(10, 88);
            this.tabPageViewGroups.Name = "tabPageViewGroups";
            this.tabPageViewGroups.Size = new System.Drawing.Size(2512, 1141);
            this.tabPageViewGroups.TabIndex = 2;
            this.tabPageViewGroups.Text = "View Groups";
            this.tabPageViewGroups.UseVisualStyleBackColor = true;
            // 
            // tabPageManageGroupScore
            // 
            this.tabPageManageGroupScore.Location = new System.Drawing.Point(10, 88);
            this.tabPageManageGroupScore.Name = "tabPageManageGroupScore";
            this.tabPageManageGroupScore.Size = new System.Drawing.Size(2512, 1141);
            this.tabPageManageGroupScore.TabIndex = 3;
            this.tabPageManageGroupScore.Text = "Manage Group Score";
            this.tabPageManageGroupScore.UseVisualStyleBackColor = true;
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
            this.groupBoxStudentGroupingTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentGroupingTable)).EndInit();
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
        private Button btnGroupStudentManually;
    }
}