using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Card_Tracker_v3.Data;
using Card_Tracker_v3.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Card_Tracker_v3.Controllers
{
    public class CommanderDecksController : Controller
    {
        private readonly TrackerContext _context;

        public CommanderDecksController(TrackerContext context)
        {
            _context = context;
        }

        // GET: CommanderDecks
        public async Task<IActionResult> Index()
        {
            var trackerContext = _context.CommanderDeck.Include(c => c.MagicGameFormats);
            return View(await trackerContext.ToListAsync());
        }

        [HttpPost]
        public IActionResult UploadDeck(IFormFile file, int id)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0) {
                    var test = reader.ReadLine();
                    DeckLookUp newCard = new()
                    {
                        CardAmount = Int32.Parse(test.Split(' ')[0]),
                        CardName = test.Split(' ', 2)[1],
                        CommanderDeckId = 1, //This is manual for now
                        CardTypeId = 1,
                        LegalityStatus = true
                    };
                    _context.DeckLookUp.Add(newCard);
                    _context.SaveChanges();
                    Console.WriteLine(reader.ReadLine());
                }
            }
            return View();
        }

        // GET: CommanderDecks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardList = await _context.DeckLookUp.Where(x => x.CommanderDeckId == id).ToListAsync();
            if (cardList == null)
            {
                return NotFound();
            }

            return View(cardList);
        }

        // GET: CommanderDecks/Create
        public IActionResult Create()
        {
            ViewData["MagicGameFormatsId"] = new SelectList(_context.MagicGameFormats, "Id", "FormatName");
            return View();
        }

        // POST: CommanderDecks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeckName,AmountOfCards,MagicGameFormatsId,PlayReadyStatus,Cost")] CommanderDeck commanderDeck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commanderDeck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MagicGameFormatsId"] = new SelectList(_context.MagicGameFormats, "Id", "Id", commanderDeck.MagicGameFormatsId);
            return View(commanderDeck);
        }

        // GET: CommanderDecks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commanderDeck = await _context.CommanderDeck.FindAsync(id);
            if (commanderDeck == null)
            {
                return NotFound();
            }
            ViewData["MagicGameFormatsId"] = new SelectList(_context.MagicGameFormats, "Id", "Id", commanderDeck.MagicGameFormatsId);
            return View(commanderDeck);
        }

        // POST: CommanderDecks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeckName,AmountOfCards,MagicGameFormatsId,PlayReadyStatus,Cost")] CommanderDeck commanderDeck)
        {
            if (id != commanderDeck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commanderDeck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommanderDeckExists(commanderDeck.Id))
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
            ViewData["MagicGameFormatsId"] = new SelectList(_context.MagicGameFormats, "Id", "Id", commanderDeck.MagicGameFormatsId);
            return View(commanderDeck);
        }

        // GET: CommanderDecks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commanderDeck = await _context.CommanderDeck
                .Include(c => c.MagicGameFormats)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commanderDeck == null)
            {
                return NotFound();
            }

            return View(commanderDeck);
        }

        // POST: CommanderDecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commanderDeck = await _context.CommanderDeck.FindAsync(id);
            _context.CommanderDeck.Remove(commanderDeck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommanderDeckExists(int id)
        {
            return _context.CommanderDeck.Any(e => e.Id == id);
        }
    }
}
