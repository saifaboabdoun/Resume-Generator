using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeGenerator.Data;
using ResumeGenerator.Models;

namespace ResumeGenerator.Controllers
{
    public class EducationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Education
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Educations.Include(e => e.resume);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Education/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.resume)
                .FirstOrDefaultAsync(m => m.educationId == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Education/Create
        public IActionResult Create(int resumeId)
        {
            return View(new Education { resumeId = resumeId }); // ← صح
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Education education)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine("Validation error: " + error);
                }

                return View(education);
            }

            _context.Add(education);
            await _context.SaveChangesAsync();

            return RedirectToAction("Create", "Experience", new { resumeId = education.resumeId });
        }




        // GET: Education/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["resumeId"] = new SelectList(_context.Resumes, "resumeId", "resumeId", education.resumeId);
            return View(education);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("educationId,collageName,degreeType,startDate,endDate,major,gpa,resumeId")] Education education)
        {
            if (id != education.educationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.educationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["resumeId"] = new SelectList(_context.Resumes, "resumeId", "resumeId", education.resumeId);
            return View(education);
        }

        // GET: Education/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.resume)
                .FirstOrDefaultAsync(m => m.educationId == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education != null)
            {
                _context.Educations.Remove(education);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.educationId == id);
        }
    }
}
