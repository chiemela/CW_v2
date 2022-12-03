using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkManagementSystem
{
    public class Storage
    {
        private List<string> UpToDateStudentsList = new List<string>();


        public Storage(List<string> i)
        {
            UpToDateStudentsList = i.ToList();
        }

        public List<string> GetStudentList()
        {
            return UpToDateStudentsList;
        }

    }
}
