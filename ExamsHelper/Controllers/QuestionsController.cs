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
    public class QuestionsController : Controller
    {
        QuestionService qS;
        UserService uS;

        public QuestionsController(dbcontext context)
        {
            qS = new QuestionService(context);
            uS = new UserService(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAnswer(int id)
        {
            return View("Answer", qS.getQuestionById(id));
        }

        public IActionResult SaveAnswer(string content,int id, int sid)
        {
            if(User.Identity.IsAuthenticated)
            {
                if(uS.checkModerRole(uS.getUserByLogin(User.Identity.Name).Login))
                {
                    qS.saveAnswer(content, id);
                }
            }    
            return View("Index", qS.getSubjectQuestions(sid));
        }

        public IActionResult DeleteQuestion(int id, int sid)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (uS.checkModerRole(User.Identity.Name))
                {
                    qS.deleteQuestion(id);
                    return View("Index", qS.getSubjectQuestions(sid));
                }
            }
            return View("Index", qS.getSubjectQuestions(sid));
        }


        public IActionResult Create(string Question, int Subject)
        {
            
            if (Question != null)
            {
                qS.CreateQuest(Question, Subject);
                return View("Index", qS.getSubjectQuestions(Subject));
            }
            else
            {
                return RedirectToAction("CreateErrorReturn", new { errMsg = "Введите вопрос" });
            }
        }

        public IActionResult CreateErrorReturn(string errMsg)
        {
            ModelState.AddModelError("", errMsg);
            ViewBag.subj = new SelectList(qS.getUserFacultySubjects(uS.getUserByLogin(User.Identity.Name).Id), "Id", "NameOfSubject");

            return View("Create");
        }


        public IActionResult CreateQuestion()
        {
            if(uS.checkModerRole(User.Identity.Name))
            {
                ViewBag.subj = new SelectList(qS.getUserFacultySubjects(uS.getUserByLogin(User.Identity.Name).Id), "Id", "NameOfSubject");
               
                return View("Create");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ShowSubjectQuestions(int id)
        {
            return View("Index", qS.getSubjectQuestions(id));
        }
    }
}
