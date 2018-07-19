using ExamsHelper.Context;
using ExamsHelper.Models;
using ExamsHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Services
{
    public class UniversityService
    {
        UnitOfWork unitOfWork;

        public UniversityService(dbcontext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void Save()
        {
            unitOfWork.Save();
        }

        public IEnumerable<Univers> getAllUnivers()
        {
            return unitOfWork.Univers.GetAll();
        }

        public Univers getUniverById(int id)
        {
            return unitOfWork.Univers.Get(id);
        }
    }
}
