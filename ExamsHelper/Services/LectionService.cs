using ExamsHelper.Context;
using ExamsHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Services
{
    public class LectionService
    {
        UnitOfWork unitOfWork;

        public LectionService(dbcontext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void Save()
        {
            unitOfWork.Save();
        }
    }
}
