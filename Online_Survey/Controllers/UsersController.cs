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
    public class UsersController : Controller
    {
        private readonly OnlineDbCon _context;

        public UsersController(OnlineDbCon context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var onlineDbCon = _context.Users.Include(u => u.People);
            return View(await onlineDbCon.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.People)
                .FirstOrDefaultAsync(m => m.User_id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // Send Message Action
        public async Task<IActionResult> Send(int id)
        {
            // Fetch user and related details
            var user = await _context.Users
                .Include(u => u.People)
                .FirstOrDefaultAsync(u => u.User_id == id);

            if (user == null)
            {
                return NotFound();
            }

           
            string name = user.People.Name;
            string username = user.Username;
            string password = user.Password;
            string phoneNumber = user.People.Tell; 

           
            string bodyWhatsApp = "*Xog Muhiim ah* %0D%0A" +
                                  "*ASC Mudane/Marwo:* " + name + " %0D%0A" +
                                  "Waxaan kugu hambalyeynayaa ka qeybgalka Surveykan Fadlan isticmaaal %0D%0A" +
                                  "*Username:* " + username + " %0D%0A" +
                                  "*Password:* " + password + " %0D%0A" +
                                  "*MAHADSANID*";

            // Redirect to WhatsApp link
            string whatsappUrl = "https://wa.me/" + phoneNumber + "?text=" + bodyWhatsApp;
            return Redirect(whatsappUrl);
        }


        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["P_no"] = new SelectList(_context.People, "P_no", "Name");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_id,Username,Password,P_no,User_type,Reg_date")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["P_no"] = new SelectList(_context.People, "P_no", "Name", user.P_no);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["P_no"] = new SelectList(_context.People, "P_no", "Email", user.P_no);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User_id,Username,Password,P_no,User_type,Reg_date")] User user)
        {
            if (id != user.User_id)
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
                    if (!UserExists(user.User_id))
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
            ViewData["P_no"] = new SelectList(_context.People, "P_no", "Email", user.P_no);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.People)
                .FirstOrDefaultAsync(m => m.User_id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.User_id == id);
        }
    }
}
