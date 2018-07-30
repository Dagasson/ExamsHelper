using ExamsHelper.Context;
using ExamsHelper.Models;
using ExamsHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Services
{
    public class QuestionService
    {
        UnitOfWork unitOfWork;

        public QuestionService(dbcontext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void CreateQuest(string q, int s)
        {
            Questions ques = new Questions();
            ques.Question = q;
            ques.SubjectsId = s;
            unitOfWork.Questions.Create(ques);
            unitOfWork.Save();
        }

        public void deleteQuestion(int id)
        {
            unitOfWork.Questions.Delete(id);
            unitOfWork.Save();
        }


        public void saveAnswer(string content, int id)
        {
            Questions q = unitOfWork.Questions.Get(id);
            q.Answer = content;
            unitOfWork.Questions.Update(q);
            unitOfWork.Save();
        }

        public Questions getQuestionById(int id)
        {
            return unitOfWork.Questions.Get(id);
        }

        public IEnumerable<Questions> getAllQuestions()
        {
            return unitOfWork.Questions.GetAll();
        }

        public IEnumerable<Subjects> getUserFacultySubjects(int id)
        {
            
            return unitOfWork.Subjects.GetAll().Where(s => s.FacultiesId.Equals(unitOfWork.Users.Get(id).FacultiesId));
        }

        public IEnumerable<Questions> getSubjectQuestions(int id)
        {
           return unitOfWork.Questions.GetAll().Where(q => q.SubjectsId.Equals(id));
        }

        public void Save()
        {
            unitOfWork.Save();
        }
    }
}
