using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WelfareDenmarkMVC.Data;
using WelfareDenmarkMVC.Models;

namespace WelfareDenmarkMVC.Controllers
{
    
    public class ContactListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactList
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: ContactList/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListViewModel = await _context.Contacts
                .SingleOrDefaultAsync(m => m.ContactID == id);
            if (contactListViewModel == null)
            {
                return NotFound();
            }

            return View(contactListViewModel);
        }

        // GET: ContactList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactID,FullName,PhoneNumber")] ContactListViewModel contactListViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactListViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactListViewModel);
        }

        // GET: ContactList/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListViewModel = await _context.Contacts.SingleOrDefaultAsync(m => m.ContactID == id);
            if (contactListViewModel == null)
            {
                return NotFound();
            }
            return View(contactListViewModel);
        }

        // POST: ContactList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ContactID,FullName,PhoneNumber")] ContactListViewModel contactListViewModel)
        {
            if (id != contactListViewModel.ContactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactListViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactListViewModelExists(contactListViewModel.ContactID))
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
            return View(contactListViewModel);
        }

        // GET: ContactList/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListViewModel = await _context.Contacts
                .SingleOrDefaultAsync(m => m.ContactID == id);
            if (contactListViewModel == null)
            {
                return NotFound();
            }

            return View(contactListViewModel);
        }

        // POST: ContactList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var contactListViewModel = await _context.Contacts.SingleOrDefaultAsync(m => m.ContactID == id);
            _context.Contacts.Remove(contactListViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactListViewModelExists(string id)
        {
            return _context.Contacts.Any(e => e.ContactID == id);
        }
    }
}
