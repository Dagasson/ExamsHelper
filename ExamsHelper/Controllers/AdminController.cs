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

        // GET: Users1/Edit/5
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
            ViewData["FacultiesId"] = new SelectList(_context.Faculties, "Id", "Id", user.FacultiesId);
            ViewData["UniversId"] = new SelectList(_context.Univers, "Id", "Id", user.UniversId);
            return View(user);
        }

        // POST: Users1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, [Bind("Id,Login,Email,Password,Moderator,Admin,FacultiesId,UniversId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

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




    }
}
