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
    public class CouponController : Controller
    {
        private readonly BookStoreDBContext _context;

        public CouponController(BookStoreDBContext context)
        {
            _context = context;
        }

        // GET: Coupon
        public async Task<IActionResult> Index()
        {
            return View(await _context.CouponTable.ToListAsync());
        }

        // GET: Coupon/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponTable = await _context.CouponTable
                .FirstOrDefaultAsync(m => m.CoId == id);
            if (couponTable == null)
            {
                return NotFound();
            }

            return View(couponTable);
        }

        // GET: Coupon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coupon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoId,CoName,CoExpiryDate,CoDiscount")] CouponTable couponTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(couponTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(couponTable);
        }

        // GET: Coupon/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponTable = await _context.CouponTable.FindAsync(id);
            if (couponTable == null)
            {
                return NotFound();
            }
            return View(couponTable);
        }

        // POST: Coupon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CoId,CoName,CoExpiryDate,CoDiscount")] CouponTable couponTable)
        {
            if (id != couponTable.CoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(couponTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponTableExists(couponTable.CoId))
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
            return View(couponTable);
        }

        // GET: Coupon/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponTable = await _context.CouponTable
                .FirstOrDefaultAsync(m => m.CoId == id);
            if (couponTable == null)
            {
                return NotFound();
            }

            return View(couponTable);
        }

        // POST: Coupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var couponTable = await _context.CouponTable.FindAsync(id);
            _context.CouponTable.Remove(couponTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouponTableExists(string id)
        {
            return _context.CouponTable.Any(e => e.CoId == id);
        }
    }
}
