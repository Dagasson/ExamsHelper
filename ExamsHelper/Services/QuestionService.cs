using ExamsHelper.Context;
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

        public void Save()
        {
            unitOfWork.Save();
        }
    }
}
