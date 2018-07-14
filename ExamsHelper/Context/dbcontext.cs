using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ExamsHelper.Models;
using Microsoft.EntityFrameworkCore;


namespace ExamsHelper.Context
{
    public class dbcontext : IdentityDbContext<User>
    {
        public DbSet<Univers> Univers { get; set; }
        public DbSet<Faculties> Faculties { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Lections> Lections { get; set; }

        public dbcontext(DbContextOptions<dbcontext> options) : base(options)
        {
        }
    }
}
