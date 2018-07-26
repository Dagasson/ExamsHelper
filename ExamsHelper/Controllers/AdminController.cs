using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Models;
using ExamsHelper.ViewModels;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;


namespace ExamsHelper.Controllers
{
    public class AdminController : Controller
    {
        UserService uS;
        FacultyService fS;
        UniversityService unvS;
      

        public AdminController(dbcontext context)
        {
            uS = new UserService(context);
            fS = new FacultyService(context);
            unvS = new UniversityService(context);
        }

        public IActionResult DeleteUser(int id)
        {
            uS.deleteUser(id);
            return View();
        }

        public IActionResult Admin(int id)
        {
            uS.makeAdmin(id);
            return View();
        }

        public IActionResult NoAdmin(int id)
        {
            uS.noAdmin(id);
            return View();
        }

        public IActionResult Moder(int id)
        {
            uS.makeModer(id);
            return View();
        }

        public IActionResult NoModer(int id)
        {
            uS.noModer(id);
            return View();
        }

        public IActionResult DeleteUniversity(int id)
        {
            unvS.deleteUniver(id);
            return View();
        }

        public IActionResult DeleteFaculty(int id)
        {
            fS.deleteFaculty(id);
            return View();
        }

        public IActionResult Index()
        {
            if (uS.checkAdmRole(User.Identity.Name))
            {
                AdminViewModel views = new AdminViewModel();
                views.users = uS.getAllUsers().ToList();
                views.univers = unvS.getAllUnivers().ToList();
                views.faculties = fS.getAllFaculties().ToList();
                return View("Index",views);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
