﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamsHelper.Controllers
{
    [Route("api/[controller]")]
    public class SubjectsAPIController : Controller
    {
        SubjectService sS;
        FacultyService fS;
        QuestionService qS;

        public  SubjectsAPIController(dbcontext context)
        {
            fS = new FacultyService(context);
            sS = new SubjectService(context);
            qS = new QuestionService(context);
        }
        // GET: api/<controller>
        [HttpGet]
        public JsonResult GetS(int id)
        {
           return Json(sS.getSubjectsOfFaculty(id));
        }



        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
