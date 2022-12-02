namespace CourseWorkManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            manageStudents1.Visible = true;
            manageGroups1.Visible = false;
            viewGroups1.Visible = false;
            manageGroupMark1.Visible = false;
            savedData1.Visible = false;
            ManageStudents manageStudent = new ManageStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manageStudents1.Visible = true;
            manageGroups1.Visible = false;
            viewGroups1.Visible = false;
            manageGroupMark1.Visible = false;
            savedData1.Visible = false;



        }

        private void btnManageGroups_Click(object sender, EventArgs e)
        {
            manageStudents1.Visible = false;
            manageGroups1.Visible = true;
            viewGroups1.Visible = false;
            manageGroupMark1.Visible = false;
            savedData1.Visible = false;
        }

        private void btnViewGroups_Click(object sender, EventArgs e)
        {
            manageStudents1.Visible = false;
            manageGroups1.Visible = false;
            viewGroups1.Visible = true;
            manageGroupMark1.Visible = false;
            savedData1.Visible = false;
        }

        private void btnManageGroupsMark_Click(object sender, EventArgs e)
        {
            manageStudents1.Visible = false;
            manageGroups1.Visible = false;
            viewGroups1.Visible = false;
            manageGroupMark1.Visible = true;
            savedData1.Visible = false;
        }

        private void btnSavedData_Click(object sender, EventArgs e)
        {
            manageStudents1.Visible = false;
            manageGroups1.Visible = false;
            viewGroups1.Visible = false;
            manageGroupMark1.Visible = false;
            savedData1.Visible = true;
        }
    }
}