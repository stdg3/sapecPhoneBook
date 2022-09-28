using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;
using test.ViewModel;

namespace test.Controllers
{
    public class NumbersOfContactsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;   

        public NumbersOfContactsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: NumbersOfContacts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NumbersOfNumbers.Include(n => n.PhoneType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NumbersOfContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NumbersOfNumbers == null)
            {
                return NotFound();
            }

            var numbersOfContact = await _context.NumbersOfNumbers
                .Include(n => n.PhoneType)
                .FirstOrDefaultAsync(m => m.NumbersOfContactId == id);
            if (numbersOfContact == null)
            {
                return NotFound();
            }

            return View(numbersOfContact);
        }

        // GET: NumbersOfContacts/Create
        public IActionResult Create()
        {
            var applicationDbContext = _context.PhoneTypes.ToList();
            var model = new CreateNumsOfContactViewModel();
            model.ListOfTypes = new List<SelectListItem>();
            foreach (var item in applicationDbContext)
            {
                model.ListOfTypes.Add(new SelectListItem { Text = item.PhoneTypeName, Value = item.PhoneTypeId.ToString() });
            }
            return View(model);
        }

        // POST: NumbersOfContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumbersOfContactId,NumbersOfContactNumber,PhoneTypeId")] NumbersOfContact numbersOfContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numbersOfContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhoneTypeId"] = new SelectList(_context.PhoneTypes, "PhoneTypeId", "PhoneTypeId", numbersOfContact.PhoneTypeId);
            return View(numbersOfContact);
        }

        // GET: NumbersOfContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NumbersOfNumbers == null)
            {
                return NotFound();
            }

            var numbersOfContact = await _context.NumbersOfNumbers.FindAsync(id);
            if (numbersOfContact == null)
            {
                return NotFound();
            }
            ViewData["PhoneTypeId"] = new SelectList(_context.PhoneTypes, "PhoneTypeId", "PhoneTypeId", numbersOfContact.PhoneTypeId);
            return View(numbersOfContact);
        }

        // POST: NumbersOfContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumbersOfContactId,NumbersOfContactNumber,PhoneTypeId")] NumbersOfContact numbersOfContact)
        {
            if (id != numbersOfContact.NumbersOfContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numbersOfContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumbersOfContactExists(numbersOfContact.NumbersOfContactId))
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
            ViewData["PhoneTypeId"] = new SelectList(_context.PhoneTypes, "PhoneTypeId", "PhoneTypeId", numbersOfContact.PhoneTypeId);
            return View(numbersOfContact);
        }

        // GET: NumbersOfContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NumbersOfNumbers == null)
            {
                return NotFound();
            }

            var numbersOfContact = await _context.NumbersOfNumbers
                .Include(n => n.PhoneType)
                .FirstOrDefaultAsync(m => m.NumbersOfContactId == id);
            if (numbersOfContact == null)
            {
                return NotFound();
            }

            return View(numbersOfContact);
        }

        // POST: NumbersOfContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NumbersOfNumbers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NumbersOfNumbers'  is null.");
            }
            var numbersOfContact = await _context.NumbersOfNumbers.FindAsync(id);
            if (numbersOfContact != null)
            {
                _context.NumbersOfNumbers.Remove(numbersOfContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumbersOfContactExists(int id)
        {
          return _context.NumbersOfNumbers.Any(e => e.NumbersOfContactId == id);
        }
    }
}
