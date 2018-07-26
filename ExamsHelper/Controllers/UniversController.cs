using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;


namespace ExamsHelper.Controllers
{
    public class UniversController : Controller
    {
        UniversityService unvS;
        UserService uS;

        public UniversController(dbcontext context)
        {
            unvS = new UniversityService(context);
            uS = new UserService(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string univer, string town)
        {
            if (uS.checkAdmRole(User.Identity.Name))
            {
                unvS.createUniver(univer, town);
                unvS.Save();
                return View("Create");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateUniversity()
        {
            if (uS.checkAdmRole(User.Identity.Name))
            {
                return View("Create");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
