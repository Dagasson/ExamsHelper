using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamsHelper.Models;
using ExamsHelper.Context;
using ExamsHelper.Services;
using ExamsHelper.Context;
using Microsoft.AspNetCore.Authorization;

namespace ExamsHelper.Controllers
{
    public class HomeController : Controller
    {
      UserService uS;
      
        public IActionResult Index()

        dbcontext db;

        public HomeController(dbcontext context)
        {
            uS=new UserService
            db = context;
         }

        public IActionResult Index()
        {
            return View(db.Univers.ToList());
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp([FromForm] User user)
        {                    
                uS.createUser(user);
                uS.Save();
            return View("Index");
        }

        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpGet]
        public IActionResult GetFaculties(Int32 Id)
        {
            IEnumerable<Faculties> Faculties = db.Faculties.Where(t => t.UniverId == Id);
            Univers Uni = db.Univers.Where(t => t.Id == Id).First() ;
            string qwe = Uni.NameOfUniver;
            ViewBag.ChoisenUniver= qwe;
            return View("FacultyList", Faculties.ToList());
        }
        
        public IActionResult Registration()
          {
            return View();
          }
    }
}
