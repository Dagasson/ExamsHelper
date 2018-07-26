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

        public void deleteFaculty(int id)
        {
            unitOfWork.Faculties.Delete(id);
            unitOfWork.Save();
        }

        public void createFaculty(string n, int Uid)
        {
            Faculties f = new Faculties();
            f.NameOfFaculties = n;
            f.UniversId = Uid;
            unitOfWork.Faculties.Create(f);
        }

        public IEnumerable<Faculties> getAllFaculties()
        {
            return unitOfWork.Faculties.GetAll();
        }

        public Faculties getFaculty(int idOfFaculty)
        {
            return unitOfWork.Faculties.Get(idOfFaculty);
        }

        public IEnumerable<Faculties> getFacultiesOfUniver(int idOfUniver)
        {
            return unitOfWork.Faculties.GetFacultiesOfUniver(idOfUniver);
        }
    }
}
