using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore1.Models;

namespace BookStore1.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BookStoreDBContext _context;

        public AuthorController(BookStoreDBContext context)
        {
            _context = context;
        }

        // GET: Author
        public async Task<IActionResult> Index()
        {
            return View(await _context.AuthorTable.ToListAsync());
        }

        // GET: Author/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorTable = await _context.AuthorTable
                .FirstOrDefaultAsync(m => m.AId == id);
            if (authorTable == null)
            {
                return NotFound();
            }

            return View(authorTable);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AId,AFname,ASname,ACountry")] AuthorTable authorTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorTable);
        }

        // GET: Author/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorTable = await _context.AuthorTable.FindAsync(id);
            if (authorTable == null)
            {
                return NotFound();
            }
            return View(authorTable);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AId,AFname,ASname,ACountry")] AuthorTable authorTable)
        {
            if (id != authorTable.AId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorTableExists(authorTable.AId))
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
            return View(authorTable);
        }

        // GET: Author/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorTable = await _context.AuthorTable
                .FirstOrDefaultAsync(m => m.AId == id);
            if (authorTable == null)
            {
                return NotFound();
            }

            return View(authorTable);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorTable = await _context.AuthorTable.FindAsync(id);
            _context.AuthorTable.Remove(authorTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorTableExists(int id)
        {
            return _context.AuthorTable.Any(e => e.AId == id);
        }
    }
}
