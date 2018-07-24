using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace ExamsHelper.Controllers
{
    public class UsersController : Controller
    {
        UserService uS;
        public UsersController(dbcontext context)
        {
            uS = new UserService(context);
        }

        public IActionResult Users()
        {
            return View("User",uS.getUserByLogin(User.Identity.Name));
        }

        public IActionResult ChangePassword(string password)
        {
            uS.ChangePassword(password, User.Identity.Name);
            uS.Save();
            return View("User", uS.getUserByLogin(User.Identity.Name));
        }
    }
}
