using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPWeb_CRUD.Models;

namespace APPWeb_CRUD.Controllers
{
    public class UserApplicationsController : Controller
    {
        private readonly VivaPruebaContext _context;

        public UserApplicationsController(VivaPruebaContext context)
        {
            _context = context;
        }

        // GET: UserApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatUserApplications.ToListAsync());
        }

        // GET: UserApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catUserApplication = await _context.CatUserApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catUserApplication == null)
            {
                return NotFound();
            }

            return View(catUserApplication);
        }

        // GET: UserApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Name,Password,UserStatus")] CatUserApplication catUserApplication)
        {
            if (ModelState.IsValid)
            {
                var passwordEncriptado = Business.Utils.obtenermd5(catUserApplication.Password);
                catUserApplication.Password = passwordEncriptado;
                _context.Add(catUserApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catUserApplication);
        }

        // GET: UserApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catUserApplication = await _context.CatUserApplications.FindAsync(id);
            if (catUserApplication == null)
            {
                return NotFound();
            }
            return View(catUserApplication);
        }

        // POST: UserApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Name,Password,UserStatus")] CatUserApplication catUserApplication)
        {
            if (id != catUserApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var passwordEncriptado = Business.Utils.obtenermd5(catUserApplication.Password);
                    catUserApplication.Password = passwordEncriptado;
                    _context.Update(catUserApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatUserApplicationExists(catUserApplication.Id))
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
            return View(catUserApplication);
        }

        // GET: UserApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catUserApplication = await _context.CatUserApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catUserApplication == null)
            {
                return NotFound();
            }

            return View(catUserApplication);
        }

        // POST: UserApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catUserApplication = await _context.CatUserApplications.FindAsync(id);
            if (catUserApplication != null)
            {
                _context.CatUserApplications.Remove(catUserApplication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatUserApplicationExists(int id)
        {
            return _context.CatUserApplications.Any(e => e.Id == id);
        }
    }
}
