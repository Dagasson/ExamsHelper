using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamsHelper.Models
{
    public class Questions
    {
        [Key]
        public Int32 Id { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }

        public Int32 SubjectsId { get; set; }
        public Subjects Subjects { get; set; }
    }
}
