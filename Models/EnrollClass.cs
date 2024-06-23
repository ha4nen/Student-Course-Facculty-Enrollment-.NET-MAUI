using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.Models
{
    public class EnrollClass
    {
        [PrimaryKey, AutoIncrement]
        public int Enroll_Id { get; set; }
        public string Student_Name { get; set; }
        public string Cousre_Name { get; set; }
        public string Faculty_Name { get; set; }

    }
}
