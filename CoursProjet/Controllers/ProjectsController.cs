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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

       
        // GET: Projects
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Projects.ToListAsync());
        //}
        public async Task<IActionResult> Index(ECategory category)
        {
            if (category != 0) 
                return View(await _context.Projects.Where(p => p.Category == category).ToListAsync());

            return View(await _context.Projects.ToListAsync());
        }

        // GET: Projects/Details/5
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

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NameProject,Date,NeedMoney,Goal,Status,Category")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projects);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(projects);
        }

        // GET: Projects/Edit/5
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

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NameProject,Date,NeedMoney,Goal,Status,Category")] Projects projects)
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

        // GET: Projects/Delete/5
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

        // POST: Projects/Delete/5
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
