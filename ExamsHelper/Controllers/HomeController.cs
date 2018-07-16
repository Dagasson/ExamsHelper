using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamsHelper.Models;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Authorization;

namespace ExamsHelper.Controllers
{
    public class HomeController : Controller
    {
      UserService uS;
      UniversityService unvS;
      FacultyService fS;

        public HomeController(dbcontext context)
        {
            uS = new UserService(context);
            unvS = new UniversityService(context);
            fS = new FacultyService(context);
         }

        public IActionResult Index()
        {
            return View("Index",unvS.getAllUnivers());
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp([FromForm] User user)
        {
            user.FacultiesId = 0;
            user.UniversId = 0;
                uS.createUser(user);
                uS.Save();
            return View("Index");
        }

        [HttpGet]
        public IActionResult GetFaculties(Int32 Id)
        {
            IEnumerable<Faculties> Faculties = fS.getAllFaculties().Where(t => t.UniverId == Id);
            Univers Uni = unvS.getAllUnivers().Where(t => t.Id == Id).First();
            string qwe = Uni.NameOfUniver;
            ViewBag.ChoisenUniver = qwe;
            return View("FacultyList", Faculties.ToList());
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Registration()
          {
            return View();
          }
    }
}
