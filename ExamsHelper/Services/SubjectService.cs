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
        public IEnumerable<Faculties> getUserUniversityFaculties(int id)
        {
            return unitOfWork.Faculties.GetAll().Where(f => f.Id.Equals(unitOfWork.Users.Get(id).FacultiesId));
        }

        public void deleteSubject(int id)
        {
            unitOfWork.Subjects.Delete(id);
            unitOfWork.Save();
        }

        public void CreateSubject(string n, string t, string s, int fId)
        {
            Subjects subj = new Subjects();
            subj.NameOfSubject = n;
            subj.Teacher = t;
            subj.Speciality = s;
            subj.FacultiesId = fId;
            unitOfWork.Subjects.Create(subj);
            unitOfWork.Save();
        }

        public void Save()
        {
            unitOfWork.Save();
        }
    }
}
