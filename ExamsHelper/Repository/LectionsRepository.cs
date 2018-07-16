using ExamsHelper.Context;
using ExamsHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Repository
{
    public class LectionsRepository
    {
        private dbcontext db;

        public LectionsRepository(dbcontext context)
        {
            this.db = context;
        }

        public IEnumerable<Lections> GetAll()
        {
            return db.Lections;
        }

        public Lections Get(int id)
        {
            return db.Lections.Find(id);
        }

        public void Create(Lections lection)
        {
            db.Lections.Add(lection);
        }

        public void Update(Lections lection)
        {
            db.Entry(lection).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Lections lection = db.Lections.Find(id);
            if (lection != null)
                db.Lections.Remove(lection);
        }
    }
}
