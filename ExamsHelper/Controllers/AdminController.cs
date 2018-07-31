using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsHelper.Context;
using ExamsHelper.Models;
using ExamsHelper.ViewModels;
using ExamsHelper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamsHelper.Controllers
{
    public class AdminController : Controller
    {
        UserService uS;
        FacultyService fS;
        UniversityService unvS;
        dbcontext _context;

        public AdminController(dbcontext context)
        {
            uS = new UserService(context);
            fS = new FacultyService(context);
            unvS = new UniversityService(context);
            _context = context;
        }

        public IActionResult DeleteUser(int id)
        {
            uS.deleteUser(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult Admin(int id)
        {
            uS.makeAdmin(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult NoAdmin(int id)
        {
            uS.noAdmin(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult Moder(int id)
        {
            uS.makeModer(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult NoModer(int id)
        {
            uS.noModer(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult DeleteUniversity(int id)
        {
            unvS.deleteUniver(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult DeleteFaculty(int id)
        {
            fS.deleteFaculty(id);
            AdminViewModel views = new AdminViewModel();
            views.users = uS.getAllUsers().ToList();
            views.univers = unvS.getAllUnivers().ToList();
            views.faculties = fS.getAllFaculties().ToList();
            return View("Index", views);
        }

        public IActionResult Index()
        {
            if (uS.checkAdmRole(User.Identity.Name))
            {
                AdminViewModel views = new AdminViewModel();
                views.users = uS.getAllUsers().ToList();
                views.univers = unvS.getAllUnivers().ToList();
                views.faculties = fS.getAllFaculties().ToList();
                return View("Index", views);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetFacultiesOfUnivers(int id)
        {
            return PartialView(fS.getFacultiesOfUniver(id));
        }

        public async Task<IActionResult> EditUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            IEnumerable<Univers> univers = new List<Univers> { };
            univers = unvS.getAllUnivers();
            ViewBag.univers = new SelectList(univers, "Id", "NameOfUniver", user.UniversId);

            IEnumerable<Faculties> faculties = new List<Faculties> { };
            faculties = fS.getFacultiesOfUniver(user.UniversId);
            ViewBag.faculties = new SelectList(faculties, "Id", "NameOfFaculties");
            return View(user);
        }

       
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, [Bind("Id,Login,Email,Password,Moderator,Admin")] User user, int faculty, int univer )
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            user.UniversId = univer;
            user.FacultiesId = faculty;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                 }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultiesId"] = new SelectList(_context.Faculties, "Id", "Id", user.FacultiesId);
            ViewData["UniversId"] = new SelectList(_context.Univers, "Id", "Id", user.UniversId);
            return View(user);
        }


        public async Task<IActionResult> EditUniver(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var univer = await _context.Univers.SingleOrDefaultAsync(m => m.Id == id);
            if (univer == null)
            {
                return NotFound();
            }
            return View(univer);
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUniver(int id, [Bind("Id,NameOfUniver, Town")] Univers univer)
        {
            if (id != univer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(univer);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(univer);
        }


        public async Task<IActionResult> EditFaculty(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties.SingleOrDefaultAsync(m => m.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }

            ViewData["UniversId"] = new SelectList(_context.Univers, "Id", "Id", faculty.UniversId);
            return View(faculty);
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFaculty(int id, [Bind("Id,NameOfFaculties, UniversId")] Faculties faculty)
        {
            if (id != faculty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculty);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversId"] = new SelectList(_context.Univers, "Id", "Id", faculty.UniversId);
            return View(faculty);
        }


    }
}
