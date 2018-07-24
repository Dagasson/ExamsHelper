using ExamsHelper.Context;
using ExamsHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Repository
{
    public class UserRepository
    {
        private dbcontext db;

        public UserRepository(dbcontext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.Include(u => u.Univers).Include(f => f.Faculties);
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
