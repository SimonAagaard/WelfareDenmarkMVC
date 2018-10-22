﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WelfareDenmarkMVC.Data;
using WelfareDenmarkMVC.Models.AccountViewModels;

namespace WelfareDenmarkMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class ChecklistViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChecklistViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChecklistViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChecklistViewModel.ToListAsync());
        }

        // GET: ChecklistViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklistViewModel = await _context.ChecklistViewModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (checklistViewModel == null)
            {
                return NotFound();
            }

            return View(checklistViewModel);
        }

        // GET: ChecklistViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChecklistViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChecklistItem,Id")] ChecklistViewModel checklistViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checklistViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checklistViewModel);
        }

        // GET: ChecklistViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklistViewModel = await _context.ChecklistViewModel.SingleOrDefaultAsync(m => m.Id == id);
            if (checklistViewModel == null)
            {
                return NotFound();
            }
            return View(checklistViewModel);
        }

        // POST: ChecklistViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChecklistItem,Id")] ChecklistViewModel checklistViewModel)
        {
            if (id != checklistViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checklistViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChecklistViewModelExists(checklistViewModel.Id))
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
            return View(checklistViewModel);
        }

        // GET: ChecklistViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklistViewModel = await _context.ChecklistViewModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (checklistViewModel == null)
            {
                return NotFound();
            }

            return View(checklistViewModel);
        }

        // POST: ChecklistViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checklistViewModel = await _context.ChecklistViewModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.ChecklistViewModel.Remove(checklistViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChecklistViewModelExists(int id)
        {
            return _context.ChecklistViewModel.Any(e => e.Id == id);
        }
    }
}
