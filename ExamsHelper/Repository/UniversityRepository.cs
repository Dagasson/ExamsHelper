using ExamsHelper.Context;
using ExamsHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Repository
{
    public class UniversityRepository
    {
        private dbcontext db;

        public UniversityRepository(dbcontext context)
        {
            this.db = context;
        }

        public IEnumerable<Univers> GetAll()
        {
            return db.Univers;
        }

        public Univers Get(int id)
        {
            return db.Univers.Find(id);
        }

        public void Create(Univers univer)
        {
            db.Univers.Add(univer);
        }

        public void Update(Univers univer)
        {
            db.Entry(univer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Univers univer = db.Univers.Find(id);
            if (univer != null)
                db.Univers.Remove(univer);
        }
    }
}
