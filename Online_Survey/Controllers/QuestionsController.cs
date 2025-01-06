using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Survey.Data;
using Online_Survey.Models;

namespace Online_Survey.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly OnlineDbCon _context;

        public QuestionsController(OnlineDbCon context)
        {
            _context = context;
        }

		public async Task<IActionResult> Report()
		{
			var onlineDbCon = _context.Questions.Include(q => q.Survey);
			return View(await onlineDbCon.ToListAsync());
		}

		// GET: Questions
		public async Task<IActionResult> Index()
        {
            var onlineDbCon = _context.Questions.Include(q => q.Survey);
            return View(await onlineDbCon.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions
                .Include(q => q.Survey)
                .FirstOrDefaultAsync(m => m.Question_id == id);
            if (questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            ViewData["Survey_id"] = new SelectList(_context.Surveys, "Survey_id", "Title");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Question_id,Survey_id,Question_text,Created_at")] Questions questions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Survey_id"] = new SelectList(_context.Surveys, "Survey_id", "Title", questions.Survey_id);
            return View(questions);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions.FindAsync(id);
            if (questions == null)
            {
                return NotFound();
            }
            ViewData["Survey_id"] = new SelectList(_context.Surveys, "Survey_id", "Title", questions.Survey_id);
            return View(questions);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Question_id,Survey_id,Question_text,Created_at")] Questions questions)
        {
            if (id != questions.Question_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionsExists(questions.Question_id))
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
            ViewData["Survey_id"] = new SelectList(_context.Surveys, "Survey_id", "Title", questions.Survey_id);
            return View(questions);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions
                .Include(q => q.Survey)
                .FirstOrDefaultAsync(m => m.Question_id == id);
            if (questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questions = await _context.Questions.FindAsync(id);
            if (questions != null)
            {
                _context.Questions.Remove(questions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionsExists(int id)
        {
            return _context.Questions.Any(e => e.Question_id == id);
        }
    }
}
