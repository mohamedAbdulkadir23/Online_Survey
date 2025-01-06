using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Survey.Data;
using Online_Survey.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Survey.Controllers
{
    public class PeopleController : Controller
    {
        private readonly OnlineDbCon _context;

        public PeopleController(OnlineDbCon context)
        {
            _context = context;
        }
		public async Task<IActionResult> Report()
		{
			var people = _context.People.Include(p => p.Address); // Include Address for FK display
			return View(await people.ToListAsync());
		}
		// GET: People
		public async Task<IActionResult> Index()
        {
			
			var people = _context.People.Include(p => p.Address); // Include Address for FK display
            return View(await people.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Address)
                .FirstOrDefaultAsync(m => m.P_no == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
			
			ViewData["Add_no"] = new SelectList(_context.Addresses, "Add_no", "District");
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("P_no,Name,Tell,Email,Gender,Add_no,Reg_date")] People people)
        {
            if (ModelState.IsValid)
            {
                _context.Add(people);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Add_no"] = new SelectList(_context.Addresses, "Add_no", "District", people.Add_no);
            return View(people);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
			
			if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            ViewData["Add_no"] = new SelectList(_context.Addresses, "Add_no", "District", people.Add_no);
            return View(people);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("P_no,Name,Tell,Email,Gender,Add_no,Reg_date")] People people)
        {
            if (id != people.P_no)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(people);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleExists(people.P_no))
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
            ViewData["Add_no"] = new SelectList(_context.Addresses, "Add_no", "District", people.Add_no);
            return View(people);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
			
			if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People
                .Include(p => p.Address)
                .FirstOrDefaultAsync(m => m.P_no == id);

            if (people == null)
            {
                return NotFound();
            }

            return View(people);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var people = await _context.People.FindAsync(id);
            if (people != null)
            {
                _context.People.Remove(people);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleExists(int id)
        {
            return _context.People.Any(e => e.P_no == id);
        }
    }
}
