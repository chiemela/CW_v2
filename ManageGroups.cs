using System;
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
    public partial class ManageGroups : UserControl
    {
        public ManageGroups()
        {
            InitializeComponent();
        }

        public List<string> ListNewlyAddedStudents = new List<string>();   // create a new list with variable name "listNewlyAddedStudents"

        public ManageGroups(List<string> i)
        {
            ListNewlyAddedStudents = i.ToList();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAutoAssignStudents_Click(object sender, EventArgs e)
        {
            ManageStudents ManageStudents = new ManageStudents();
            lstBxAutoAssignStudents1.DataSource = ManageStudents.name;
        }
    }
}
