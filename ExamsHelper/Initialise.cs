using System.Linq;
using ExamsHelper.Models;
using ExamsHelper.Context;

namespace ExamsHelper
{
    public static class SampleData
    {
        public static void Initialize(dbcontext context)
        {
            if (!context.Univers.Any())
            {
                context.Univers.AddRange(
                    new Univers
                    {
                        NameOfUniver="BSTU",
                        Town="Minsk"
                    },
                    new Univers
                    {
                        NameOfUniver="BSU",
                        Town="Minsk"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Faculties.Any())
            {
                context.Faculties.AddRange(
                    new Faculties
                    {
                        NameOfFaculties = "FIT",
                        UniverId=1
                    },
                    new Faculties
                    {
                        NameOfFaculties = "TOV",
                        UniverId=1
                    },
                    new Faculties
                    {
                        NameOfFaculties = "FITr",
                        UniverId = 2
                    }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.Add(
                    new User
                    {
                        UserName="Kekus",
                        Email = "Kekus@mail.ru",
                        PasswordHash = "AQAAAAEAACcQAAAAEKh+R8WlkZZgqOCr2vnzQ8vuA4rujj+nDPaF6/Uj75TFdKaye55PHRseXVAOakzIpA=="//Kola0707 или Kola0707!
                    }
                    );

                context.SaveChanges();
            }

        }
    }
}