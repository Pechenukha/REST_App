using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_App.Models
{
    public class Faculty
    {
        public int id { get; set; }
        public string name_of_faculty { get; set; }
        public string head_of_faculty { get; set; }

        //Navigation Properties
        public List<Student> student { get; set; }
    }
}
