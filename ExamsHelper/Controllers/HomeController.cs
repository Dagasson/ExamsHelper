using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamsHelper.Models;
using ExamsHelper.ViewModels;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamsHelper.Controllers
{
    public class HomeController : Controller
    {
      UserService uS;
      UniversityService unvS;
      FacultyService fS;
      SubjectService sS;
      QuestionService qS;

        public HomeController(dbcontext context)
        {
            uS = new UserService(context);
            unvS = new UniversityService(context);
            fS = new FacultyService(context);
            sS = new SubjectService(context);
            qS = new QuestionService(context);
         }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Index()
        {
            int defaultUniversId;
            IEnumerable<Univers> univers = new List<Univers> { };
            univers = unvS.getAllUnivers();
            defaultUniversId = univers.First().Id;
            ViewBag.univers = new SelectList(univers, "Id", "NameOfUniver", defaultUniversId);
            IEnumerable<Faculties> faculties = new List<Faculties> { };
            faculties = fS.getFacultiesOfUniver(defaultUniversId);
            ViewBag.faculties = new SelectList(faculties, "Id", "NameOfFaculties");

            return View("Index",unvS.getAllUnivers());
        }

        public ActionResult GetFacultiesOfUnivers(int id)
        {
            return PartialView(fS.getFacultiesOfUniver(id));
        }

        public ActionResult Search(string inputSearch)
        {
            var search = (from q in qS.getAllQuestionsWithSubjects()
                          where q.Question.ToUpper().Contains(inputSearch.ToUpper()) ||
q.Subjects.NameOfSubject.ToUpper().Contains(inputSearch.ToUpper()) ||
q.Subjects.Teacher.ToUpper().Contains(inputSearch.ToUpper()) ||
q.Subjects.Speciality.ToUpper().Contains(inputSearch.ToUpper())
                          select q).ToList();    
                return View("ResultSearch", search);
        }

        public ActionResult GetSubjectsOfFaculty(int id)
        {
            return View(sS.getSubjectsOfFaculty(id));
        }
        public IActionResult Reg()
        {
            int defaultUniversId;
            IEnumerable<Univers> univers = new List<Univers> { };
            univers = unvS.getAllUnivers();
            defaultUniversId = univers.First().Id;
            ViewBag.univers = new SelectList(univers, "Id", "NameOfUniver", defaultUniversId);

            IEnumerable<Faculties> faculties = new List<Faculties> { };
            faculties = fS.getFacultiesOfUniver(defaultUniversId);
            ViewBag.faculties = new SelectList(faculties, "Id", "NameOfFaculties");
            return View("Registration",unvS.getAllUnivers());
        }

        public IActionResult registrationErrorReturn(string errMsg)
        {
            int defaultUniversId;
            IEnumerable<Univers> univers = new List<Univers> { };
            univers = unvS.getAllUnivers();
            defaultUniversId = univers.First().Id;
            ViewBag.univers = new SelectList(univers, "Id", "NameOfUniver", defaultUniversId);

            IEnumerable<Faculties> faculties = new List<Faculties> { };
            faculties = fS.getFacultiesOfUniver(defaultUniversId);
            ViewBag.faculties = new SelectList(faculties, "Id", "NameOfFaculties");

            ModelState.AddModelError("", errMsg);
            return View("Registration", unvS.getAllUnivers());
        }

        [HttpPost]
        public IActionResult SignUp(string login, string password, string email, int univer, int faculty )
        {


            if (login == null)
            {
                return RedirectToAction("registrationErrorReturn", new { errMsg = "Введите логин" });
            }
            if (email == null)
            {
                return RedirectToAction("registrationErrorReturn", new { errMsg = "Введите email" });
            }
            if (password == null)
            {
                return RedirectToAction("registrationErrorReturn", new { errMsg = "Введите пароль" });
            }
            if(!uS.checkExistLogin(login))
            {
                return RedirectToAction("registrationErrorReturn", new { errMsg = "Пользователь с таким именем уже существует" });
            }
            if (!uS.checkExistEmail(email))
            {
                return RedirectToAction("registrationErrorReturn", new { errMsg = "Пользователь с такой почтой уже существует" });
            }
            User user = new User (login,password, email, univer, faculty);
                uS.createUser(user);
                uS.Save();
            return View("Authorization");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authorization(string login, string password)
        {
            
            if (login == null)
            {
                return RedirectToAction("authorizationErrorReturn", new { errMsg = "Введите логин" });
            }
            if (password == null)
            {
                return RedirectToAction("authorizationErrorReturn", new { errMsg = "Введите пароль" });
            }
            if (uS.checkExistUser(login, password))
            {
                await Authenticate(login);
                return RedirectToAction("Index",  "Home");
            }
            else
            {
                return RedirectToAction("authorizationErrorReturn",new { errMsg="Неправильный логин или пароль"});
            }
        }

        public IActionResult authorizationErrorReturn(string errMsg)
        {
            ModelState.AddModelError("", errMsg);
            return View("Authorization");
        }

        public IActionResult SignIn()
        {
            return View("Authorization");
        }

        [HttpGet]
        public IActionResult GetFaculties(Int32 Id)
        {
            IEnumerable<Faculties> Faculties = fS.getAllFaculties().Where(t => t.UniversId == Id);
            Univers Uni = unvS.getAllUnivers().Where(t => t.Id == Id).First();
            string qwe = Uni.NameOfUniver;
            ViewBag.ChoisenUniver = qwe;
            return View("FacultyList", Faculties.ToList());
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task Authenticate(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
