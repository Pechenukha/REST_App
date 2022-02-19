using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_App.Models
{
    public class Group
    {
        public int id { get; set; }
        public string number_of_group { get; set; }
        public string curator { get; set; }

        //Navigation Properties
        public List<StudentInGroup> student_in_group { get; set; }

    }
}
