using ExamsHelper.Context;
using ExamsHelper.Models;
using ExamsHelper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Services
{
    public class FacultyService
    {
        UnitOfWork unitOfWork;

        public FacultyService(dbcontext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void Save()
        {
            unitOfWork.Save();
        }

        public IEnumerable<Faculties> getAllFaculties()
        {
            return unitOfWork.Faculties.GetAll();
        }
    }
}
