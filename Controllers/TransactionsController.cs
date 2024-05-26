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
using ST10134934_CLDV6211_Part_Two.ViewModels;

namespace ST10134934_CLDV6211_Part_Two.Controllers
{
    [Authorize(Roles ="Admin,User")]
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var transactions = await _context.Transaction.Include(e => e.Product).Include(e => e.Kuser).ToListAsync();
            var products = await _context.Product.ToListAsync();

            var viewModel = new TransactionProductViewModel
            {
                Transactions = transactions,
                Products = products
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Process(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            // Update the ArtStatus to "Shipped"
            transaction.ArtStatus = "Shipped";

            // Save changes to the database
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(e => e.Product)
                .Include(e => e.Kuser)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["ArtId"] = new SelectList(_context.Set<Product>(), "ArtId", "ArtId");
            ViewData["KuserId"] = new SelectList(_context.Kuser, "KuserId", "KuserId");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,ArtId,KuserId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
              
                Random random = new Random();
                DateTime startDate = DateTime.Now; // Start date for the range
                DateTime endDate = new DateTime (2024, 12, 31); // End date for the range 

                TimeSpan timeSpan = endDate - startDate;
                int totalDays = timeSpan.Days;

                // Generate a random number of days to add to the start date
                int randomDaysToAdd = random.Next(totalDays);

                // Add the random number of days to the start date to get the random date
                DateTime randomDate = startDate.AddDays(randomDaysToAdd);


                transaction.TransactionDate = DateTime.Now;
                // transaction.ModifiedDate = DateTime.Now;
                transaction.ModifiedDate = randomDate;


                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtId"] = new SelectList(_context.Set<Product>(), "ArtId", "ArtId", transaction.ArtId);
            ViewData["KuserId"] = new SelectList(_context.Kuser, "KuserId", "KuserId", transaction.KuserId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["ArtId"] = new SelectList(_context.Set<Product>(), "ArtId", "ArtId", transaction.ArtId);
            ViewData["KuserId"] = new SelectList(_context.Kuser, "KuserId", "KuserId", transaction.KuserId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,ArtId,KuserId")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Random random = new Random();
                DateTime startDate = DateTime.Now; // Start date for the range
                DateTime endDate = new DateTime(2024, 12, 31); // End date for the range 

                TimeSpan timeSpan = endDate - startDate;
                int totalDays = timeSpan.Days;

                // Generate a random number of days to add to the start date
                int randomDaysToAdd = random.Next(totalDays);

                // Add the random number of days to the start date to get the random date
                DateTime randomDate = startDate.AddDays(randomDaysToAdd);

                try
                {
                    transaction.TransactionDate = DateTime.Now;
                    transaction.ModifiedDate = randomDate;
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            ViewData["ArtId"] = new SelectList(_context.Set<Product>(), "ArtId", "ArtId", transaction.ArtId);
            ViewData["KuserId"] = new SelectList(_context.Kuser, "KuserId", "KuserId", transaction.KuserId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(e => e.Product)
                .Include(e => e.Kuser)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> TransactionHistory(TransactionHistoryViewModel model)
        {

            var query = _context.Transaction.Include(e => e.Product).Include(e => e.Kuser).AsQueryable();


            if (model.FilterArtId.HasValue)
            {
                query = query.Where(e => e.ArtId == model.FilterArtId.Value);
            }

            if (model.FilterKuserId.HasValue)
            {
                query = query.Where(e => e.KuserId == model.FilterKuserId.Value);
            }


            if (model.FilterOrderDate.HasValue)
            {

                query = query.Where(e => e.TransactionDate >= model.FilterOrderDate.Value);

            }

            if (model.FilterDeliveryDate.HasValue)
            {

                query = query.Where(e => e.TransactionDate <= model.FilterDeliveryDate.Value);

            }

            model.Transactions = await query.OrderByDescending(e => e.ModifiedDate).ToListAsync();

            return View(model);

        }







        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
    }
}
