using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_App.Models
{
    public class StudentInGroup
    {
        public int id { get; set; }
 
        //Navigation Properties
        public int id_student { get; set; }
        public Student student { get; set; }
        public int id_group { get; set; }
        public Group groups { get; set; }
    }
}
