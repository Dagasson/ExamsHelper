using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamsHelper.Controllers
{
    public class FacultiesController : Controller
    {
        UserService uS;
        FacultyService fS;
        UniversityService unvS;

        public FacultiesController(dbcontext context)
        {
            uS = new UserService(context);
            fS = new FacultyService(context);
            unvS = new UniversityService(context);
        }

        public IActionResult Create(string fac, int uid)
        {
            if (uS.checkAdmRole(User.Identity.Name))
            {
                if (fac != null)
                {
                    fS.createFaculty(fac, uid);
                    fS.Save();

                    return RedirectToAction("CreateErrorReturn", new { errMsg = "Факультет создан." });
                }
                else
                {
                   return RedirectToAction("CreateErrorReturn", new { errMsg = "Введите название факультета" });
                }
            }
            return View();
        }
        public IActionResult CreateErrorReturn(string errMsg)
        {
            ViewBag.unv = new SelectList(unvS.getAllUnivers(), "Id", "NameOfUniver");
            ModelState.AddModelError("", errMsg);
            return View("Create");
        }

        public IActionResult CreateFaculty()
        {
            if (uS.checkAdmRole(User.Identity.Name))
            {
                ViewBag.unv = new SelectList(unvS.getAllUnivers(), "Id", "NameOfUniver");

                return View("Create");

            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
