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
        public Int32 Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Int32 FacultiesId { get; set; }
        public Faculties Faculties { get; set; }

        public Int32 UniversId { get; set; }
        public Univers Univers { get; set; }
        
        public User (string login, string password, string email, int univer, int faculty)
        {
            Login = login;
            Email = email;
            Password = password;
            FacultiesId = faculty;
            UniversId = univer;
        }

        public User()
        {

        }

    }
}
