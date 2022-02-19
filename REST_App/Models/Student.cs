using System.Collections.Generic;

namespace REST_App.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int course { get; set; }
        public string speciality { get; set; }

        //Navigation Properties
        public int id_faculty { get; set; }
        public Faculty faculty { get; set; }
        public List<StudentInGroup> student_in_group { get; set; }
    }
}
