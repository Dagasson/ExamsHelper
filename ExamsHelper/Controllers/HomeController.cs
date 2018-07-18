﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamsHelper.Models;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            user.FacultiesId = 1;
            user.UniversId = 1;
                uS.createUser(user);
                uS.Save();
            return View("Index", unvS.getAllUnivers());
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
