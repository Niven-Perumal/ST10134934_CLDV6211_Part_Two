using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST10134934_CLDV6211_Part_Two.Data;
using ST10134934_CLDV6211_Part_Two.Models;

namespace ST10134934_CLDV6211_Part_Two.Controllers
{
    [Authorize(Roles="Admin")]
    public class KusersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KusersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kusers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kuser.ToListAsync());
        }

        // GET: Kusers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuser = await _context.Kuser
                .FirstOrDefaultAsync(m => m.KuserId == id);
            if (kuser == null)
            {
                return NotFound();
            }

            return View(kuser);
        }

        // GET: Kusers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kusers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KuserId,KuserName,KuserEmail,KuserType")] Kuser kuser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kuser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kuser);
        }

        // GET: Kusers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuser = await _context.Kuser.FindAsync(id);
            if (kuser == null)
            {
                return NotFound();
            }
            return View(kuser);
        }

        // POST: Kusers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KuserId,KuserName,KuserEmail,KuserType")] Kuser kuser)
        {
            if (id != kuser.KuserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kuser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KuserExists(kuser.KuserId))
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
            return View(kuser);
        }

        // GET: Kusers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuser = await _context.Kuser
                .FirstOrDefaultAsync(m => m.KuserId == id);
            if (kuser == null)
            {
                return NotFound();
            }

            return View(kuser);
        }

        // POST: Kusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kuser = await _context.Kuser.FindAsync(id);
            if (kuser != null)
            {
                _context.Kuser.Remove(kuser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KuserExists(int id)
        {
            return _context.Kuser.Any(e => e.KuserId == id);
        }
    }
}
