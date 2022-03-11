using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Card_Tracker_v3.Data;
using Card_Tracker_v3.Models;
using Card_Tracker_v3.ViewModels;

namespace Card_Tracker_v3.Controllers
{
    public class CardRepositoryLookUpsController : Controller
    {
        private readonly TrackerContext _context;

        public CardRepositoryLookUpsController(TrackerContext context)
        {
            _context = context;
        }

        // GET: CardRepositoryLookUps
        public IActionResult Index()
        {

            CollectionViewerViewModel model = new()
            {
                CardRepositoryLookUp = _context.CardRepositoryLookUp.Include(c => c.CardRepositories).ToList(),
                CardRepositories = _context.CardRepositories.ToList()
            };
            return View(model);
        }

        // GET: CardRepositoryLookUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardRepositoryLookUp = await _context.CardRepositoryLookUp
                .Include(c => c.CardRepositories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardRepositoryLookUp == null)
            {
                return NotFound();
            }

            return View(cardRepositoryLookUp);
        }

        // GET: CardRepositoryLookUps/Create
        public IActionResult Create()
        {
            ViewData["CardRepositoriesId"] = new SelectList(_context.CardRepositories, "Id", "Id");
            return View();
        }

        // POST: CardRepositoryLookUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CardApiID,CardName,Amount,CardRepositoriesId")] CardRepositoryLookUp cardRepositoryLookUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardRepositoryLookUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CardRepositoriesId"] = new SelectList(_context.CardRepositories, "Id", "Id", cardRepositoryLookUp.CardRepositoriesId);
            return View(cardRepositoryLookUp);
        }

        // GET: CardRepositoryLookUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardRepositoryLookUp = await _context.CardRepositoryLookUp.FindAsync(id);
            if (cardRepositoryLookUp == null)
            {
                return NotFound();
            }
            ViewData["CardRepositoriesId"] = new SelectList(_context.CardRepositories, "Id", "Id", cardRepositoryLookUp.CardRepositoriesId);
            return View(cardRepositoryLookUp);
        }

        // POST: CardRepositoryLookUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CardApiID,CardName,Amount,CardRepositoriesId")] CardRepositoryLookUp cardRepositoryLookUp)
        {
            if (id != cardRepositoryLookUp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardRepositoryLookUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardRepositoryLookUpExists(cardRepositoryLookUp.Id))
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
            ViewData["CardRepositoriesId"] = new SelectList(_context.CardRepositories, "Id", "Id", cardRepositoryLookUp.CardRepositoriesId);
            return View(cardRepositoryLookUp);
        }

        // GET: CardRepositoryLookUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardRepositoryLookUp = await _context.CardRepositoryLookUp
                .Include(c => c.CardRepositories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardRepositoryLookUp == null)
            {
                return NotFound();
            }

            return View(cardRepositoryLookUp);
        }

        // POST: CardRepositoryLookUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardRepositoryLookUp = await _context.CardRepositoryLookUp.FindAsync(id);
            _context.CardRepositoryLookUp.Remove(cardRepositoryLookUp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardRepositoryLookUpExists(int id)
        {
            return _context.CardRepositoryLookUp.Any(e => e.Id == id);
        }
    }
}
