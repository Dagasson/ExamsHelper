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
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult Admin(int id)
        {
            uS.makeAdmin(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult NoAdmin(int id)
        {
            uS.noAdmin(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult Moder(int id)
        {
            uS.makeModer(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult NoModer(int id)
        {
            uS.noModer(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult DeleteUniversity(int id)
        {
            unvS.deleteUniver(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult DeleteFaculty(int id)
        {
            fS.deleteFaculty(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();    
            return View("Index", views);
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
