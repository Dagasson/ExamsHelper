using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;


namespace ExamsHelper.Controllers
{
    public class SubjectsController : Controller
    {
        SubjectService sS;

        public SubjectsController(dbcontext context)
        {
            sS = new SubjectService(context);
        }

        public IActionResult Index(int faculty)
        {
            return View("Index",sS.getSubjectsOfFaculty(faculty));
        }
    }
}
