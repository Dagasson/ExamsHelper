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
