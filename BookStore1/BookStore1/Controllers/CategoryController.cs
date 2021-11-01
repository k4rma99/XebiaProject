using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore1.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BookStore1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookStoreDBContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CategoryController(BookStoreDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryTable.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTable = await _context.CategoryTable
                .FirstOrDefaultAsync(m => m.CId == id);
            if (categoryTable == null)
            {
                return NotFound();
            }

            return View(categoryTable);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CId,CName,CDescription,CStatus,CPosition,CCreatedAt,PicFile")] CategoryTable categoryTable)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(categoryTable);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                string rPath = webHostEnvironment.WebRootPath;
                string fName = Path.GetFileNameWithoutExtension(categoryTable.PicFile.FileName);
                string ext = Path.GetExtension(categoryTable.PicFile.FileName);
                categoryTable.CImage = fName + ext;
                string path = rPath + "/Images/Categories/" + categoryTable.CImage;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await categoryTable.PicFile.CopyToAsync(fileStream);
                }
                _context.Add(categoryTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryTable);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTable = await _context.CategoryTable.FindAsync(id);
            if (categoryTable == null)
            {
                return NotFound();
            }
            return View(categoryTable);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CId,CName,CDescription,CStatus,CPosition,CCreatedAt,PicFile")] CategoryTable categoryTable)
        {
            if (id != categoryTable.CId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string rPath = webHostEnvironment.WebRootPath;
                    string fName = Path.GetFileNameWithoutExtension(categoryTable.PicFile.FileName);
                    string ext = Path.GetExtension(categoryTable.PicFile.FileName);
                    categoryTable.CImage = fName + ext;
                    string path = rPath + "/Images/Categories/" + categoryTable.CImage;
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await categoryTable.PicFile.CopyToAsync(fileStream);
                    }
                    _context.Update(categoryTable);
                    await _context.SaveChangesAsync();
                    
                    //_context.Update(categoryTable);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryTableExists(categoryTable.CId))
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
            return View(categoryTable);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTable = await _context.CategoryTable
                .FirstOrDefaultAsync(m => m.CId == id);
            if (categoryTable == null)
            {
                return NotFound();
            }

            return View(categoryTable);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryTable = await _context.CategoryTable.FindAsync(id);
            _context.CategoryTable.Remove(categoryTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryTableExists(int id)
        {
            return _context.CategoryTable.Any(e => e.CId == id);
        }
    }
}
