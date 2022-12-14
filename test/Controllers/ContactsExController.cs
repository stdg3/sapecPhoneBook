using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;
using test.ViewModel;

namespace test.Controllers
{
    [Authorize]
    public class ContactsExController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactsExController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var applicationDbContext = _context.Contacts.Include(c => c.User).Where
                (c => c.UserId==user.Id);
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
                //.Include(c => c.PhoneType)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            var applicationDbContext = _context.PhoneTypes.ToList();
            var model = new CreateViewModel();
            model.PhoneTypesSelectedList = new List<SelectListItem>();
            foreach (var item in applicationDbContext)
            {
                model.PhoneTypesSelectedList.Add(new SelectListItem { Text = item.PhoneTypeName, Value = item.PhoneTypeId.ToString() });
            }
            return View(model);
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel input)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                Contact newContact = new Contact
                {
                    ContactFirstName = input.ContactName,
                    //ContactNumber = input.ContactNumber,
                    UserId = user?.Id,
                    //PhoneTypeId = input.SelectedTypeId,
                };
                _context.Add(newContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["PhoneTypeId"] = new SelectList(_context.PhoneTypes, "PhoneTypeId", "PhoneTypeId", contact.PhoneTypeId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contact.UserId);
            return View(input);     
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
            var myList = _context.PhoneTypes.ToList();
            var existContact = new EditViewModel 
            {
                ContactId = contact.ContactId,
                //ContactName = contact.ContactName,
                //ContactNumber = contact.NumbersOfContact.NumbersOfContactNumber,
                //SelectedTypeId = contact.PhoneTypeId,
                PhoneTypesSelectedList = new List<SelectListItem>()
            };
            foreach (var item in myList) 
            {
                existContact.PhoneTypesSelectedList.Add(new SelectListItem { Text = item.PhoneTypeName, Value = item.PhoneTypeId.ToString()});
            }
            //ViewData["PhoneTypeId"] = new SelectList(_context.PhoneTypes, "PhoneTypeId", "PhoneTypeId", contact.PhoneTypeId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contact.UserId);
            return View(existContact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditViewModel input)
        {
            if (id != input.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                Contact new_contact = new()
                {
                    ContactFirstName = input.ContactName,
                    //ContactNumber = input.ContactNumber,
                    //PhoneTypeId = input.SelectedTypeId,
                    UserId = user?.Id,
                    ContactId = input.ContactId
                };
                    //U
                try
                {
                    _context.Update(new_contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(new_contact.ContactId))
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
            //ViewData["PhoneTypeId"] = new SelectList(_context.PhoneTypes, "PhoneTypeId", "PhoneTypeId", contact.PhoneTypeId);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contact.UserId);
            return View(input);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                //.Include(c => c.PhoneType)
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
