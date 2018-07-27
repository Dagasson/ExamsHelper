using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamsHelper.Models
{
    public class Faculties
    {
        [Key]
        public Int32 Id { get; set; }

        public string NameOfFaculties { get; set; }

        public Int32 UniversId { get; set; }
        public Univers Univers { get; set; }

        public List<User> Users { get; set; }

        public List<Subjects> Subjects { get; set; }
        
    }
}
