using ExamsHelper.Context;
using ExamsHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Repository
{
    public class SubjectsRepository
    {
        private dbcontext db;

        public SubjectsRepository(dbcontext context)
        {
            this.db = context;
        }

        public IEnumerable<Subjects> GetAll()
        {
            return db.Subjects;
        }

        public Subjects Get(int id)
        {
            return db.Subjects.Find(id);
        }

        public void Create(Subjects subject)
        {
            db.Subjects.Add(subject);
        }

        public void Update(Subjects subject)
        {
            db.Entry(subject).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Subjects subject = db.Subjects.Find(id);
            if (subject != null)
                db.Subjects.Remove(subject);
        }
    }
}
