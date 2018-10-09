using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labic.Ar.Models;

namespace Labic.Ar.Controllers
{
    public class JuegosController : Controller
    {
        private readonly LabicArContext _context;

        public JuegosController(LabicArContext context)
        {
            _context = context;
        }

        // GET: Juegos
        public async Task<IActionResult> Index(string SortOrder,string currentFilter, string searchString, int? page)
        {
            ViewData["NombreSortParm"] = String.IsNullOrEmpty(SortOrder) ? "nombre_desc" : "";
            ViewData["CategoriaSortParam"] = SortOrder == "categoria_asc" ? "categoria_desc" : "categoria_asc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = SortOrder;

            var juegos = from j in _context.Juegos select j;
            if (!String.IsNullOrEmpty(searchString))
            {
                juegos = juegos.Where(j => j.Nombre.Contains(searchString)|| j.Categoria.Contains(searchString)|| j.Descripcion.Contains(searchString));

            }

            switch (SortOrder)
            {
                case "nombre_desc":
                    juegos = juegos.OrderByDescending(j => j.Nombre);
                    break;
                case "categoria_desc":
                    juegos = juegos.OrderByDescending(j => j.Categoria);
                    break;
                case "categoria_asc":
                    juegos = juegos.OrderBy(j => j.Categoria);
                    break;
                default:
                    juegos = juegos.OrderBy(j => j.Nombre);
                    break;


            }

            int pageSize = 3;
            return View(await Paginacion<Juegos>.CreateAsync(juegos.AsNoTracking(), page ?? 1, pageSize));
           // return View(await juegos.AsNoTracking().ToListAsync());

            //return View(await _context.Juegos.ToListAsync());
        }

        // GET: Juegos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juegos = await _context.Juegos
                .FirstOrDefaultAsync(m => m.JuegosID == id);
            if (juegos == null)
            {
                return NotFound();
            }

            return View(juegos);
        }

        // GET: Juegos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juegos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JuegosID,Nombre,Categoria,Descripcion,Estado,Multijugador")] Juegos juegos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juegos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juegos);
        }

        // GET: Juegos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juegos = await _context.Juegos.FindAsync(id);
            if (juegos == null)
            {
                return NotFound();
            }
            return View(juegos);
        }

        // POST: Juegos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JuegosID,Nombre,Categoria,Descripcion,Estado,Multijugador")] Juegos juegos)
        {
            if (id != juegos.JuegosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juegos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuegosExists(juegos.JuegosID))
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
            return View(juegos);
        }

        // GET: Juegos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juegos = await _context.Juegos
                .FirstOrDefaultAsync(m => m.JuegosID == id);
            if (juegos == null)
            {
                return NotFound();
            }

            return View(juegos);
        }

        // POST: Juegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juegos = await _context.Juegos.FindAsync(id);
            _context.Juegos.Remove(juegos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuegosExists(int id)
        {
            return _context.Juegos.Any(e => e.JuegosID == id);
        }
    }
}
