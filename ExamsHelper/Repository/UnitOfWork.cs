using ExamsHelper.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsHelper.Repository
{
    public class UnitOfWork : IDisposable
    {
        public dbcontext db = new dbcontext();

        public UnitOfWork(dbcontext context)
        {
            db = context;
        }

        private UserRepository userRepository;
        private UniversityRepository univerRepository;
        private FacultiesRepository facultyRepository;
        private LectionsRepository lectionRepository;
        private QuestionsRepository questionRepository;
        private SubjectsRepository subjectRepository;

        public SubjectsRepository Subjects
        {
            get
            {
                if (subjectRepository == null)
                    subjectRepository = new SubjectsRepository(db);
                return subjectRepository;
            }
        }

        public QuestionsRepository Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionsRepository(db);
                return questionRepository;
            }
        }

        public LectionsRepository Lections
        {
            get
            {
                if (lectionRepository == null)
                    lectionRepository = new LectionsRepository(db);
                return lectionRepository;
            }
        }

        public FacultiesRepository Faculties
        {
            get
            {
                if (facultyRepository == null)
                    facultyRepository = new FacultiesRepository(db);
                return facultyRepository;
            }
        }

        public UniversityRepository Univers
        {
            get
            {
                if (univerRepository == null)
                    univerRepository = new UniversityRepository(db);
                return univerRepository;
            }
        }


        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
