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
            var applicationDbContext = _context.NumbersOfNumbers.Include(n => n.Contact).Include(n => n.PhoneType);
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
                .Include(n => n.Contact)
                .Include(n => n.PhoneType)
                .FirstOrDefaultAsync(m => m.NumbersOfContactId == id);
            if (numbersOfContact == null)
            {
                return NotFound();
            }

            return View(numbersOfContact);
        }

        // GET: NumbersOfContacts/Create
        public IActionResult Create(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }
            var applicationDbContext = _context.PhoneTypes.ToList();
            var model = new CreateNumOfContViewModel();
            model.ContactId = (int)id;
            model.PhoneTypesList = new List<SelectListItem>();
            foreach (var item in applicationDbContext)
            {
                model.PhoneTypesList.Add(new SelectListItem { Text = item.PhoneTypeName, Value = item.PhoneTypeId.ToString() });
            }
            

            //ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "ContactId");
            //ViewData["PhoneTypeId"] = new SelectList(_context.PhoneTypes, "PhoneTypeId", "PhoneTypeId");
            return View(model);
        }

        // POST: NumbersOfContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNumOfContViewModel inputNumbersOfContact)
        {
            if (ModelState.IsValid)
            {
                NumbersOfContact newNumOfCon = new NumbersOfContact
                {
                    ContactId = inputNumbersOfContact.ContactId,
                    NumbersOfContactNumber = inputNumbersOfContact.NumbersOfContactNumber,
                    PhoneTypeId = (int)inputNumbersOfContact.PhoneTypeId,
                };
                _context.Add(newNumOfCon);
                await _context.SaveChangesAsync();
                //return RedirectToRoute(nameof(ContactsController) + nameof(ContactsController.Details), new { id = inputNumbersOfContact.ContactId});
                return RedirectToAction("Details", "Contacts", new { id = inputNumbersOfContact.ContactId });
            }
            //ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "ContactId", numbersOfContact.ContactId);
            //ViewData["PhoneTypeId"] = new SelectList(_context.PhoneTypes, "PhoneTypeId", "PhoneTypeId", numbersOfContact.PhoneTypeId);
            return View(inputNumbersOfContact);
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
            var applicationDbContext = _context.PhoneTypes.ToList();
            var model = new EditNumOfContViewModel();
            model.NumbersOfContactId = (int)id;
            model.NumbersOfContactNumber = numbersOfContact.NumbersOfContactNumber;
            model.ContactId = numbersOfContact.ContactId;
            model.PhoneTypeId = (int)numbersOfContact.PhoneTypeId;
            model.PhoneTypesList = new List<SelectListItem>();
            foreach (var item in applicationDbContext)
            {
                model.PhoneTypesList.Add(new SelectListItem { Text = item.PhoneTypeName, Value = item.PhoneTypeId.ToString() });
            }
            return View(model);
        }

        // POST: NumbersOfContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditNumOfContViewModel inputNumbersOfContact)
        {
            if (id != inputNumbersOfContact.NumbersOfContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                NumbersOfContact newNumOfConModel = new NumbersOfContact
                {
                    NumbersOfContactId = inputNumbersOfContact.NumbersOfContactId,
                    ContactId = inputNumbersOfContact.ContactId,
                    NumbersOfContactNumber = inputNumbersOfContact.NumbersOfContactNumber,
                    PhoneTypeId = inputNumbersOfContact.PhoneTypeId

                };
                try
                {
                    _context.Update(newNumOfConModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumbersOfContactExists(inputNumbersOfContact.NumbersOfContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Contacts", new { id = inputNumbersOfContact.ContactId });
            }
            //ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "ContactId", numbersOfContact.ContactId);
            //ViewData["PhoneTypeId"] = new SelectList(_context.PhoneTypes, "PhoneTypeId", "PhoneTypeId", numbersOfContact.PhoneTypeId);
            return View(inputNumbersOfContact);
        }

        // GET: NumbersOfContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NumbersOfNumbers == null)
            {
                return NotFound();
            }

            var numbersOfContact = await _context.NumbersOfNumbers
                .Include(n => n.Contact)
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
            return RedirectToAction("Details", "Contacts", new { id = numbersOfContact.ContactId });
        }

        private bool NumbersOfContactExists(int id)
        {
          return _context.NumbersOfNumbers.Any(e => e.NumbersOfContactId == id);
        }
    }
}
