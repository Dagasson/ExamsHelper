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
    public class SubjectsController : Controller
    {
        SubjectService sS;
        UserService uS;

        public SubjectsController(dbcontext context)
        {
            sS = new SubjectService(context);
            uS = new UserService(context);
        }

        public IActionResult Index(int faculty)
        {
            return View("Index",sS.getSubjectsOfFaculty(faculty));
        }

        public IActionResult CreateSubject()
        {
            if (uS.checkModerRole(User.Identity.Name))
            {
               // ViewBag.fac = new SelectList(sS.getUserUniversityFaculties(uS.getUserByLogin(User.Identity.Name).Id), "Id", "NameOfSubject");

                return View("Create");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create(string nameSubj, string teacher, string spec)
        {
            if(nameSubj==null) return RedirectToAction("CreateErrorReturn", new { errMsg = "Введите название предмета" });
            if(teacher==null) return RedirectToAction("CreateErrorReturn", new { errMsg = "Введите преподавателя" });
            if(spec==null) return RedirectToAction("CreateErrorReturn", new { errMsg = "Введите специальность" });
            sS.CreateSubject(nameSubj, teacher, spec, uS.getUserByLogin(User.Identity.Name).FacultiesId);
            return View("Index", sS.getSubjectsOfFaculty(uS.getUserByLogin(User.Identity.Name).FacultiesId));
        }

        public IActionResult CreateErrorReturn(string errMsg)
        {
            ModelState.AddModelError("", errMsg);
         
            return View("Create");
        }

        public IActionResult DeleteSubject(int id, int fid)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (uS.checkModerRole(User.Identity.Name))
                {
                    sS.deleteSubject(id);
                    return View("Index", sS.getSubjectsOfFaculty(fid));
                }
            }
            return View("Index", sS.getSubjectsOfFaculty(fid));
        }
    }
}
