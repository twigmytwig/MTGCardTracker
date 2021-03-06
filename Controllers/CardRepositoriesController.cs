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
    public class CardRepositoriesController : Controller
    {
        private readonly TrackerContext _context;

        public CardRepositoriesController(TrackerContext context)
        {
            _context = context;
        }

        public IActionResult AddCardsToRepository()
        {
            ViewData["CardPostStatus"] = "";
            AddCardViewModel viewModel = new()
            {
                CardRepositories = _context.CardRepositories.ToList()
            };
            return View(viewModel);
        }

        // POST: AddCardsToRepository
        [HttpPost]
        public IActionResult AddCardsToRepository(CardRepositories repository ,AddCardViewModel card)
        {
            try
            {
                CardRepositoryLookUp newCard = new()
                {
                    CardName = card.CardRepositoryLookUp.CardName,
                    CardApiID = card.CardRepositoryLookUp.CardApiID,
                    Amount = card.CardRepositoryLookUp.Amount,
                    CardRepositoriesId = card.CardRepositoryLookUp.CardRepositoriesId

                };
                //Grabbing all cards under this current repository id to prevent duplicate entries
                var listOfCards =_context.CardRepositoryLookUp.Where(x => x.CardRepositoriesId == newCard.CardRepositoriesId).ToList();
                bool isDuplicate = false;
                foreach(CardRepositoryLookUp singleCard in listOfCards)
                {
                    if(singleCard.CardName == newCard.CardName)
                    {
                        //If its a duplicate, invrement the original's amount total
                        singleCard.Amount += newCard.Amount;
                        _context.SaveChanges();
                        isDuplicate = true;
                    }
                }
                //If the card was not a duplicate, save it
                if (!isDuplicate)
                {
                    _context.CardRepositoryLookUp.Add(newCard);
                    _context.SaveChanges();
                }
                    

                //After successful save
                ViewData["CardPostStatus"] = "Card Saved Successfully!";
                //This reloads the model
                AddCardViewModel viewModel = new()
                {
                    CardRepositories = _context.CardRepositories.ToList()
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewData["CardPostStatus"] = "Error: " + ex.Message;
                AddCardViewModel viewModel = new()
                {
                    CardRepositories = _context.CardRepositories.ToList()
                };
                return View(viewModel);
            }
            
        }

        // GET: CardRepositories
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardRepositories.ToListAsync());
        }

        // GET: CardRepositories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardRepositories = await _context.CardRepositories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardRepositories == null)
            {
                return NotFound();
            }

            return View(cardRepositories);
        }

        // GET: CardRepositories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardRepositories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RepositoryName")] CardRepositories cardRepositories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardRepositories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardRepositories);
        }

        // GET: CardRepositories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardRepositories = await _context.CardRepositories.FindAsync(id);
            if (cardRepositories == null)
            {
                return NotFound();
            }
            return View(cardRepositories);
        }

        // POST: CardRepositories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RepositoryName")] CardRepositories cardRepositories)
        {
            if (id != cardRepositories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardRepositories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardRepositoriesExists(cardRepositories.Id))
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
            return View(cardRepositories);
        }

        // GET: CardRepositories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardRepositories = await _context.CardRepositories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardRepositories == null)
            {
                return NotFound();
            }

            return View(cardRepositories);
        }

        // POST: CardRepositories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardRepositories = await _context.CardRepositories.FindAsync(id);
            _context.CardRepositories.Remove(cardRepositories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardRepositoriesExists(int id)
        {
            return _context.CardRepositories.Any(e => e.Id == id);
        }
    }
}
