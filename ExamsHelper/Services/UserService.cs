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

        public bool checkExistLogAndEmail(string login, string email)//оставил и такую, вдруг пригодится)
        {
            foreach (User u in unitOfWork.Users.GetAll())
            {
                if (u.Login.Equals(login) || u.Email.Equals(email))
                    return false;
            }
            return true;
        }

        public bool checkExistEmail(string email)
        {
            foreach (User u in unitOfWork.Users.GetAll())
            {
                if (u.Email.Equals(email))
                    return false;
            }
            return true;
        }

        public bool checkExistLogin(string login)
        {
            foreach (User u in unitOfWork.Users.GetAll())
            {
                if (u.Login.Equals(login))
                    return false;
            }
            return true;
        }

        public User getUserByLogin(string userLogin)
        {
            foreach(User u in unitOfWork.Users.GetAll())
            {
                if (u.Login.Equals(userLogin))
                    return u;
            }
            return null;
        }

        public bool checkModerRole(string login)
        {
            foreach(User u in unitOfWork.Users.GetAll())
            {
                if (u.Login.Equals(login) && u.Moderator)
                    return true;
            }
            return false;
        }

        public void ChangePassword(string p, string log)
        {
            User user = getUserByLogin(log);
            user.Password = p;
            updateUser(user);
        }

        public User getUserById(int id)
        {
           return unitOfWork.Users.Get(id);
        }

        public void updateUser(User user)
        {
            unitOfWork.Users.Update(user);
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
