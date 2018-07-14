using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ExamsHelper.Models
{
    public class User : IdentityUser
    {
        public Int32 FacultiesId { get; set; }
        public Faculties Faculties { get; set; }

        public Int32 UniversId { get; set; }
        public Univers Univers { get; set; }
    }
}
