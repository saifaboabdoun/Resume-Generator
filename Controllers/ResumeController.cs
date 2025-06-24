using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeGenerator.Data;
using ResumeGenerator.Models;

namespace ResumeGenerator.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResumeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resume
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resumes.ToListAsync());
        }

        // GET: Resume/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var resume = await _context.Resumes
                .Include(r => r.educations) // <-- تضمين الشهادات
                .FirstOrDefaultAsync(m => m.resumeId == id);

            if (resume == null)
                return NotFound();

            return View(resume);
        }


        // GET: Resume/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Resume resume)
        {
            resume.endUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // شيل الحقل من ModelState عشان ما يوقف التحقق
            ModelState.Remove(nameof(resume.endUserId));

            if (!ModelState.IsValid)
            {
                return View(resume);
            }

            _context.Add(resume);
            await _context.SaveChangesAsync();

            return RedirectToAction("Create", "Education", new { resumeId = resume.resumeId });
        }



        // GET: Resume/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var resume = await _context.Resumes.FindAsync(id);
            if (resume == null)
                return NotFound();

            return View(resume);
        }

        // POST: Resume/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("resumeId,createdDate,modifiedDate,endUserId,isDeleted,firstName,secondName,thridName,lastName,email,dateOfBirth,phoneNumber,linkedInLink,githubLink,Address,bio,Title")] Resume resume)
        {
            if (id != resume.resumeId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResumeExists(resume.resumeId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resume);
        }

        // GET: Resume/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var resume = await _context.Resumes
                .FirstOrDefaultAsync(m => m.resumeId == id);

            if (resume == null)
                return NotFound();

            return View(resume);
        }

        // POST: Resume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resume = await _context.Resumes.FindAsync(id);
            if (resume != null)
                _context.Resumes.Remove(resume);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResumeExists(int id)
        {
            return _context.Resumes.Any(e => e.resumeId == id);
        }
    }
}
