using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_App.Models
{
    public class StudentPassport
    {
        public int id { get; set; }
        public string series { get; set; }
        public string number { get; set; }

        //Navigation Properties
        public int student_id { get; set; }
        public Student student { get; set; }
    }
}
