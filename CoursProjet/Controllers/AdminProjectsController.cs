using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursProjet.Data;
using CoursProjet.Models;

namespace CoursProjet.Controllers
{
    public class AdminProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminProjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: AdminProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        // GET: AdminProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .SingleOrDefaultAsync(m => m.ID == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // GET: AdminProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NameProject,Date,CurrentDonate,NeedMoney,Goal,Status,Category")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projects);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(projects);
        }

        // GET: AdminProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.SingleOrDefaultAsync(m => m.ID == id);
            if (projects == null)
            {
                return NotFound();
            }
            return View(projects);
        }

        // POST: AdminProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NameProject,Date,CurrentDonate,NeedMoney,Goal,Status,Category")] Projects projects)
        {
            if (id != projects.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsExists(projects.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(projects);
        }

        // GET: AdminProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .SingleOrDefaultAsync(m => m.ID == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // POST: AdminProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projects = await _context.Projects.SingleOrDefaultAsync(m => m.ID == id);
            _context.Projects.Remove(projects);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectsExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }
    }
}
