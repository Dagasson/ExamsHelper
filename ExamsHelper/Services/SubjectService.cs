using ExamsHelper.Context;
using ExamsHelper.Models;
using ExamsHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Services
{
    public class SubjectService
    {
        UnitOfWork unitOfWork;

        public SubjectService(dbcontext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<Subjects> getSubjectsOfFaculty(int idOfFaculty)
        {
            return unitOfWork.Subjects.GetSubjectsOfFaculty(idOfFaculty);
        }

        public void Save()
        {
            unitOfWork.Save();
        }
    }
}
