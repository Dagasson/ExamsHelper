using ExamsHelper.Context;
using ExamsHelper.Models;
using ExamsHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Services
{
    public class UserService
    {
        UnitOfWork unitOfWork;

        public UserService(dbcontext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void Save()
        {
            unitOfWork.Save();
        }

        public void createUser(User user)
        {
            unitOfWork.Users.Create(user);
        }

        public bool checkExistUser(string login, string password)
        {
            foreach (User user in unitOfWork.Users.GetAll())
            {
                if (user.Login.Equals(login) && user.Password.Equals(password))
                    return true;
            }
            return false;
        }

    }
}
