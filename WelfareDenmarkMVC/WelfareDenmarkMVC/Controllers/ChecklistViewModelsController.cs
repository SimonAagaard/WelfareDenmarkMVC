﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WelfareDenmarkMVC.Data;
using WelfareDenmarkMVC.Models;
using WelfareDenmarkMVC.Models.AccountViewModels;
using WelfareDenmarkMVC.Services;

namespace WelfareDenmarkMVC.Controllers
{
    [Authorize]
    public class ChecklistViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ProxyAPI _proxy;

        public ChecklistViewModelsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ProxyAPI proxy)
        {
            _context = context;
            _userManager = userManager;
            _proxy = proxy;
        }

        // GET: ChecklistViewModels
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUserId);
            if (user != null)
            {
                var checklists = await _proxy.GetAllAsync();
                var sortedlist = checklists.Where(c => c.ApplicationUserId == user.Id).ToList();
                return View(sortedlist);
            }
            return View("Create");
        }

        // GET: ChecklistViewModels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklistViewModel = await _proxy.GetDetailsAsync(id);
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
        public async Task<IActionResult> Create([Bind("ChecklistItem,Id,ApplicationUser.Id")] ChecklistViewModel checklistViewModel)
        {
            ClaimsPrincipal currentUser = User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser user = await _userManager.FindByIdAsync(currentUserId);
            checklistViewModel.ApplicationUser = user;

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
        public async Task<IActionResult> Edit(int id, [Bind("ChecklistItem,Id,ApplicationUser.Id")] ChecklistViewModel checklistViewModel)
        {
            if (id != checklistViewModel.Id)
            {
                return NotFound();
            }

            ClaimsPrincipal currentUser = User;
            checklistViewModel.ApplicationUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
             //= await _userManager.FindByIdAsync(currentUserId);

            if (ModelState.IsValid)
            {
                try
                {
                    await _proxy.EditChecklistAsync(checklistViewModel);
                    //_context.Update(checklistViewModel);
                    //await _context.SaveChangesAsync();
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
