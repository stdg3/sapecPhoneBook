using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;
using test.ViewModel;
using test.ViewModel.Contacts;

namespace test.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var applicationDbContext = _context.Contacts
                .Include(c => c.User)
                .Where(c => c.User.Id==user.Id);
            //ListContactViewMoodel existContact = new ListContactViewMoodel
            //{
            //    ContactId = 
            //};
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ContactId == id);
           
            if (contact == null)
            {
                return NotFound();
            }
            ContactAllDataViewModel newModel = new ContactAllDataViewModel
            {
                ContactId = contact.ContactId,
                ContactFirstName = contact.ContactFirstName,
                ContactLastName = contact.ContactLastName,
                ContactAdress = contact.ContactAdress,
            };
            //var numbersOfContact = await _context.NumbersOfNumbers
            //    .Include(n => n.Contact)
            //    .Include(n => n.PhoneType)
            //    .Where(n => n.ContactId == incomeContactID)
            //    .FirstOrDefaultAsync(m => m.NumbersOfContactId == incomeContactID);
            newModel.NumbersOfContacts = await _context.NumbersOfNumbers
                .Include(c => c.PhoneType)
                .Where(c => c.ContactId == id)
                .ToListAsync();

            return View(newModel);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            //var applicationDbContext = _context.PhoneTypes.ToList();
            //var model = new CreateContactViewModel();
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateContactViewModel inputContact)
        {
            if (ModelState.IsValid)
            {
                var userAuthorized = await _userManager.GetUserAsync(HttpContext.User);
                Contact newContact = new Contact 
                {
                    ContactFirstName = inputContact.ContactFirstName,
                    ContactLastName = inputContact.ContactLastName,
                    ContactAdress = inputContact.ContactAdress,
                    UserId = userAuthorized?.Id
                };
                _context.Add(newContact);
                await _context.SaveChangesAsync();
                //var ssssssss = newContact.ContactId;
                return RedirectToAction(nameof(Index));
            }
            return View(inputContact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            EditContactViewMoodel newContact = new EditContactViewMoodel
            {
                ContactId = contact.ContactId,
                ContactFirstName = contact.ContactFirstName,
                ContactLastName = contact.ContactLastName,
                ContactAdress = contact.ContactAdress
            };
            return View(newContact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditContactViewMoodel inputContact)
        {
            if (id != inputContact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                Contact newContact = new Contact
                {
                    ContactId = inputContact.ContactId,
                    ContactFirstName = inputContact.ContactFirstName,
                    ContactLastName = inputContact.ContactLastName,
                    ContactAdress = inputContact.ContactAdress,
                    UserId = user?.Id
                };
                try
                {
                    _context.Update(newContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(newContact.ContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Contacts", new { id = inputContact.ContactId });
            }
            return View(inputContact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
          return _context.Contacts.Any(e => e.ContactId == id);
        }
    }
}
