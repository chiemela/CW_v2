namespace CourseWorkManagementSystem
{
    partial class ManageStudents
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImportNewCSV = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStudentIDnumber = new System.Windows.Forms.TextBox();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCsvImport = new System.Windows.Forms.DataGridView();
            this.studentIDnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblFilePath = new System.Windows.Forms.Label();
            this.dataGridViewListItems = new System.Windows.Forms.DataGridView();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.lblNumberOfStudent = new System.Windows.Forms.Label();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListItems)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(36, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 1015);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Students Form";
            // 
            // btnImportNewCSV
            // 
            this.btnImportNewCSV.Location = new System.Drawing.Point(35, 857);
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
            this.label2.Location = new System.Drawing.Point(260, 764);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 62);
            this.label1.TabIndex = 4;
            this.label1.Text = "Manage Students";
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
            this.dgvCsvImport.Location = new System.Drawing.Point(656, 100);
            this.dgvCsvImport.Name = "dgvCsvImport";
            this.dgvCsvImport.ReadOnly = true;
            this.dgvCsvImport.RowHeadersWidth = 102;
            this.dgvCsvImport.RowTemplate.Height = 49;
            this.dgvCsvImport.Size = new System.Drawing.Size(1319, 994);
            this.dgvCsvImport.TabIndex = 6;
            this.dgvCsvImport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCsvImport_CellContentClick);
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
            this.studentBindingSource.CurrentChanged += new System.EventHandler(this.studentBindingSource_CurrentChanged);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(656, 42);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(177, 41);
            this.lblFilePath.TabIndex = 14;
            this.lblFilePath.Text = "File location";
            // 
            // dataGridViewListItems
            // 
            this.dataGridViewListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListItems.Location = new System.Drawing.Point(656, 100);
            this.dataGridViewListItems.Name = "dataGridViewListItems";
            this.dataGridViewListItems.RowHeadersWidth = 102;
            this.dataGridViewListItems.RowTemplate.Height = 49;
            this.dataGridViewListItems.Size = new System.Drawing.Size(1319, 994);
            this.dataGridViewListItems.TabIndex = 18;
            this.dataGridViewListItems.Visible = false;
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Location = new System.Drawing.Point(1707, 1106);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(268, 78);
            this.btnDeleteStudent.TabIndex = 19;
            this.btnDeleteStudent.Text = "Delete Student";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // lblNumberOfStudent
            // 
            this.lblNumberOfStudent.AutoSize = true;
            this.lblNumberOfStudent.Location = new System.Drawing.Point(656, 1106);
            this.lblNumberOfStudent.Name = "lblNumberOfStudent";
            this.lblNumberOfStudent.Size = new System.Drawing.Size(39, 41);
            this.lblNumberOfStudent.TabIndex = 20;
            this.lblNumberOfStudent.Text = "...";
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(1159, 1106);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(268, 78);
            this.btnSaveExcel.TabIndex = 21;
            this.btnSaveExcel.Text = "Save to Excel";
            this.btnSaveExcel.UseVisualStyleBackColor = true;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // ManageStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveExcel);
            this.Controls.Add(this.lblNumberOfStudent);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.dataGridViewListItems);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.dgvCsvImport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ManageStudents";
            this.Size = new System.Drawing.Size(2014, 1204);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button btnAddStudent;
        private DataGridView dgvCsvImport;
        private Label lblFilePath;
        private BindingSource studentBindingSource;
        private DataGridViewTextBoxColumn studentIDnumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailAddressDataGridViewTextBoxColumn;
        private TextBox txtEmailAddress;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtStudentIDnumber;
        private Label label2;
        private Button btnResetForm;
        private Button btnImportNewCSV;
        private DataGridView dataGridViewListItems;
        private Button btnDeleteStudent;
        private Label lblNumberOfStudent;
        private Button btnSaveExcel;
    }
}
