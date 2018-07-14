using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamsHelper.Models
{
    public class Subjects
    {
        [Key]
        public Int32 Id { get; set; }

        public string NameOfSubject { get; set; }
        public string Speciality { get; set; }
        public string Teacher { get; set; }

        public Int32 FacultiesId { get; set; }
        public Faculties Faculties { get; set; }

        public List<Questions> Questions { get; set; }
        public List<Lections> Lections { get; set; }
    }
}
