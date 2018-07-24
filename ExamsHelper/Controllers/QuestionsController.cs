using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;


namespace ExamsHelper.Controllers
{
    public class QuestionsController : Controller
    {
        QuestionService qS;

        public QuestionsController(dbcontext context)
        {
            qS = new QuestionService(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowSubjectQuestions(int id)
        {
            return View("Index", qS.getSubjectQuestions(id));
        }
    }
}
