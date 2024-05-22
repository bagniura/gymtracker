using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymTracker.Data;
using GymTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GymTracker.Controllers
{
    [Authorize]
    public class UserrsController : Controller
    {
        private readonly GymTrackerContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public UserrsController(GymTrackerContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Userrs
        public async Task<IActionResult> Index()
        {
            IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            return _context.Userr != null ?
                          View(await _context.Userr.Where(m => m.UserId == user.Id).ToListAsync()) :
                          Problem("Entity set 'GymTrackerContext.Userr' is null.");
        }

        // GET: Userrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Userr == null)
            {
                return NotFound();
            }

            var Userr = await _context.Userr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Userr == null)
            {
                return NotFound();
            }

            return View(Userr);
        }




        // GET: Userrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email")] Userr Userr)
        {
            IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Userr.UserId = user.Id;

            var existingUserr = _context.Userr.FirstOrDefault(c => c.UserId == user.Id);

            if (existingUserr != null)
            {
                // Możesz obsłużyć przypadek, gdy użytkownik ma już utworzone konto klienta
                ModelState.AddModelError(string.Empty, "Nie możesz wypełnić ponownie tego formularza, ponieważ masz już istniejące konto użytkownika! Formularz można wypełnić tylko raz na jedno konto!");
            }

            if (ModelState.IsValid)
            {
                if (existingUserr == null)
                {
                    _context.Add(Userr);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(Userr);
        }








        // GET: Userrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Userr == null)
            {
                return NotFound();
            }

            var Userr = await _context.Userr.FindAsync(id);
            if (Userr == null)
            {
                return NotFound();
            }
            return View(Userr);
        }

        // POST: Userrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email")] Userr Userr)
        {
            if (id != Userr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Userr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserrExists(Userr.Id))
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
            return View(Userr);
        }

        // GET: Userrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Userr == null)
            {
                return NotFound();
            }

            var Userr = await _context.Userr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Userr == null)
            {
                return NotFound();
            }

            return View(Userr);
        }

        // POST: Userrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Userr == null)
            {
                return Problem("Entity set 'GymTrackerContext.Userr'  is null.");
            }
            var Userr = await _context.Userr.FindAsync(id);
            if (Userr != null)
            {
                _context.Userr.Remove(Userr);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserrExists(int id)
        {
            return (_context.Userr?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}