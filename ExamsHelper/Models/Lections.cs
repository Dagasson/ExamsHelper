using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamsHelper.Models
{
    public class Lections
    {
        public Int32 Id { get; set; }

        public byte[] Content { get; set; }

        public string UserName { get; set;}
        public User User { get; set; }

        public Int32 SubjectsId { get; set; }
        public Subjects Subjects { get; set; }
    }
}
