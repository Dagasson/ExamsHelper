﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExamsHelper.Controllers
{
    public class LectionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
