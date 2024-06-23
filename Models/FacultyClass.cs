using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.Models
{
    public class FacultyClass
    {

        [PrimaryKey, AutoIncrement]
        public int Faculty_Id { get; set; }
        public string Faculty_Name { get; set; }
        public string Faculty_Department { get; set; }
        public bool IsDean { get; set; } // Example job role
        public bool IsHeadOfDepartment { get; set; } // Example job role
        public bool IsProfessor { get; set; } // Example job role

    }
}
