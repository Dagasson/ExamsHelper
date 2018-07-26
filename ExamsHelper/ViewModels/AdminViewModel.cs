using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Models;

namespace ExamsHelper.ViewModels
{
    public class AdminViewModel
    {
        public List<User> users { get; set; }
        public List<Univers> univers { get; set; }
        public List<Faculties> faculties { get; set; }
    }
}
