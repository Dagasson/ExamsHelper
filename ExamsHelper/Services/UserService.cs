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


        public bool checkAdmRole(string login)
        {
            foreach (User u in unitOfWork.Users.GetAll())
            {
                if (u.Login.Equals(login) && u.Admin)
                    return true;
            }
            return false;
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

        public void deleteUser(int id)
        {
            unitOfWork.Users.Delete(id);
            unitOfWork.Save();
        }

        public void makeModer(int id)
        {
            User u = unitOfWork.Users.Get(id);
            u.Moderator = true;
            unitOfWork.Users.Update(u);
            unitOfWork.Save();
        }

        public void noModer(int id)
        {
            User u = unitOfWork.Users.Get(id);
            u.Moderator = false;
            unitOfWork.Users.Update(u);
            unitOfWork.Save();
        }

        public void makeAdmin(int id)
        {
            User u = unitOfWork.Users.Get(id);
            u.Admin = true;
            unitOfWork.Users.Update(u);
            unitOfWork.Save();
        }

        public void noAdmin(int id)
        {
            User u = unitOfWork.Users.Get(id);
            u.Admin = false;
            unitOfWork.Users.Update(u);
            unitOfWork.Save();
        }

        public User getUserById(int id)
        {
           return unitOfWork.Users.Get(id);
        }

        public void updateUser(User user)
        {
            unitOfWork.Users.Update(user);
        }

        public IEnumerable<User> getAllUsers()
        {
            return unitOfWork.Users.GetAll();
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

        public void deleteUserbyuniversid(int id)
        {
            IEnumerable<User> usersfordelete = unitOfWork.Users.GetByUniversId(id);
            foreach (User user in usersfordelete)
            {
                unitOfWork.Users.Delete(user.Id);
            }
            unitOfWork.Save();
        }

        public void deleteUserbyfacultiesid(int id)
        {
            IEnumerable<User> usersfordelete = unitOfWork.Users.GetByFacultiesId(id);
            foreach (User user in usersfordelete)
            {
                unitOfWork.Users.Delete(user.Id);
            }
            unitOfWork.Save();
        }
    }
}
