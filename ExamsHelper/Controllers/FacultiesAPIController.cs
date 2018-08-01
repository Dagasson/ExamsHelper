using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Models;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;
using static ExamsHelper.Errors.Errors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamsHelper.Controllers
{
    [Route("api/[controller]")]
    public class FacultiesAPIController : Controller
    {
        FacultyService fS;
        UniversityService uS;
        SubjectService sS;

        public FacultiesAPIController(dbcontext context)
        {
            fS = new FacultyService(context);
            uS = new UniversityService(context);
            sS = new SubjectService(context);
        }
        // GET: api/<controller>
        [HttpGet]
        public JsonResult Get(String Univer)
        {
            if (Univer != null)
            {
                Univers q=uS.getUniverByName(Univer);
                return Json(fS.getFacultiesOfUniver(q.Id));
            }
            else
            {
                return Json(fS.getAllFaculties());
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(fS.getFaculty(id));
        }

        // POST api/<controller>
        [HttpPost]
        public JsonResult Post([FromBody]string NameOfUniver, [FromBody] string NameOfFaculty)
        {
            Univers choisenUniver = uS.getUniverByName(NameOfUniver);

            List<Faculties> facultiesOfUniver = new List<Faculties>(fS.getFacultiesOfUniver(choisenUniver.Id));

            Faculties choisenFaculty = facultiesOfUniver.First(c => c.NameOfFaculties == NameOfFaculty);

            return Json(sS.getSubjectsOfFaculty(choisenFaculty.Id));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return StatusCode(403, ErrorCode.CouldNotUpdateItem.ToString());
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(403, ErrorCode.CouldNotDeleteItem.ToString());
        }
    }
}
