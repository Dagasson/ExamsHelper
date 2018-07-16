using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ExamsHelper.Models
{
    public class User 
    {
        [Key]
        public Int32 id { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Int32 FacultiesId { get; set; }
        public Faculties Faculties { get; set; }

        public Int32 UniversId { get; set; }
        public Univers Univers { get; set; }

        public Lections Lections { get; set; }
    }
}
