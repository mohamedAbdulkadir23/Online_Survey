using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Survey.Data;
using Online_Survey.Models;


public class AddressesController : Controller
{
	private readonly OnlineDbCon _context;

	public AddressesController(OnlineDbCon context)
	{
		_context = context;
	}

	private bool IsAuthenticated()
	{
		var userEmail = HttpContext.Session.GetString("UserEmail");
		return !string.IsNullOrEmpty(userEmail);
	}

	// GET: Addresses
	public async Task<IActionResult> Index()
	{
		if (!IsAuthenticated())
		{
			return RedirectToAction("Index", "Login");
		}

		return View(await _context.Addresses.ToListAsync());
	}

	// GET: Addresses/Details/5
	public async Task<IActionResult> Details(int? id)
	{
		if (!IsAuthenticated())
		{
			return RedirectToAction("Index", "Login");
		}

		if (id == null)
		{
			return NotFound();
		}

		var address = await _context.Addresses.FirstOrDefaultAsync(m => m.Add_no == id);
		if (address == null)
		{
			return NotFound();
		}

		return View(address);
	}

	// GET: Addresses/Create
	public IActionResult Create()
	{
		if (!IsAuthenticated())
		{
			return RedirectToAction("Index", "Login");
		}

		return View();
	}

	// POST: Addresses/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Add_no,District,Village")] Address address)
	{
		if (!IsAuthenticated())
		{
			return RedirectToAction("Index", "Login");
		}

		if (ModelState.IsValid)
		{
			_context.Add(address);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		return View(address);
	}

	// GET: Addresses/Edit/5
	public async Task<IActionResult> Edit(int? id)
	{
		if (!IsAuthenticated())
		{
			return RedirectToAction("Index", "Login");
		}

		if (id == null)
		{
			return NotFound();
		}

		var address = await _context.Addresses.FindAsync(id);
		if (address == null)
		{
			return NotFound();
		}

		return View(address);
	}

	// POST: Addresses/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Add_no,District,Village")] Address address)
	{
		if (!IsAuthenticated())
		{
			return RedirectToAction("Index", "Login");
		}

		if (id != address.Add_no)
		{
			return NotFound();
		}

		if (ModelState.IsValid)
		{
			try
			{
				_context.Update(address);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AddressExists(address.Add_no))
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
		return View(address);
	}

	// GET: Addresses/Delete/5
	public async Task<IActionResult> Delete(int? id)
	{
		if (!IsAuthenticated())
		{
			return RedirectToAction("Index", "Login");
		}

		if (id == null)
		{
			return NotFound();
		}

		var address = await _context.Addresses.FirstOrDefaultAsync(m => m.Add_no == id);
		if (address == null)
		{
			return NotFound();
		}

		return View(address);
	}

	// POST: Addresses/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		if (!IsAuthenticated())
		{
			return RedirectToAction("Index", "Login");
		}

		var address = await _context.Addresses.FindAsync(id);
		if (address != null)
		{
			_context.Addresses.Remove(address);
		}

		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

	private bool AddressExists(int id)
	{
		return _context.Addresses.Any(e => e.Add_no == id);
	}
}

