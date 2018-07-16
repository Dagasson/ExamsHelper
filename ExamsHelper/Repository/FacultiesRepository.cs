using ExamsHelper.Context;
using ExamsHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Repository
{
    public class FacultiesRepository
    {
        private dbcontext db;

        public FacultiesRepository(dbcontext context)
        {
            this.db = context;
        }

        public IEnumerable<Faculties> GetAll()
        {
            return db.Faculties;
        }

        public Faculties Get(int id)
        {
            return db.Faculties.Find(id);
        }

        public void Create(Faculties faculty)
        {
            db.Faculties.Add(faculty);
        }

        public void Update(Faculties faculty)
        {
            db.Entry(faculty).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Faculties faculty = db.Faculties.Find(id);
            if (faculty != null)
                db.Faculties.Remove(faculty);
        }
    }
}
