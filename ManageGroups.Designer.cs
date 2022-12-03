namespace CourseWorkManagementSystem
{
    partial class ManageGroups
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAutoAssignStudents = new System.Windows.Forms.Button();
            this.lstBxAutoAssignStudents1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 62);
            this.label1.TabIndex = 5;
            this.label1.Text = "Manage Groups";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAutoAssignStudents);
            this.groupBox1.Controls.Add(this.lstBxAutoAssignStudents1);
            this.groupBox1.Location = new System.Drawing.Point(59, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 1035);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Assign Students";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnAutoAssignStudents
            // 
            this.btnAutoAssignStudents.Location = new System.Drawing.Point(33, 876);
            this.btnAutoAssignStudents.Name = "btnAutoAssignStudents";
            this.btnAutoAssignStudents.Size = new System.Drawing.Size(862, 105);
            this.btnAutoAssignStudents.TabIndex = 19;
            this.btnAutoAssignStudents.Text = "Auto Assign Students";
            this.btnAutoAssignStudents.UseVisualStyleBackColor = true;
            this.btnAutoAssignStudents.Click += new System.EventHandler(this.btnAutoAssignStudents_Click);
            // 
            // lstBxAutoAssignStudents1
            // 
            this.lstBxAutoAssignStudents1.FormattingEnabled = true;
            this.lstBxAutoAssignStudents1.ItemHeight = 41;
            this.lstBxAutoAssignStudents1.Location = new System.Drawing.Point(33, 87);
            this.lstBxAutoAssignStudents1.Name = "lstBxAutoAssignStudents1";
            this.lstBxAutoAssignStudents1.Size = new System.Drawing.Size(862, 783);
            this.lstBxAutoAssignStudents1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(1030, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(920, 1035);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manually Asign Students";
            // 
            // ManageGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ManageGroups";
            this.Size = new System.Drawing.Size(2014, 1204);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox lstBxAutoAssignStudents1;
        private Button btnAutoAssignStudents;
    }
}
