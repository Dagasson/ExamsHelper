using ExamsHelper.Context;
using ExamsHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Repository
{
    public class QuestionsRepository
    {
        private dbcontext db;

        public QuestionsRepository(dbcontext context)
        {
            this.db = context;
        }

        public IEnumerable<Questions> GetAll()
        {
            return db.Questions.Include(q =>q.Subjects);
        }

        public Questions Get(int id)
        {
            return db.Questions.Find(id);
        }

        public void Create(Questions question)
        {
            db.Questions.Add(question);
        }

        public void Update(Questions question)
        {
            db.Entry(question).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Questions question = db.Questions.Find(id);
            if (question != null)
                db.Questions.Remove(question);
        }
    }
}
