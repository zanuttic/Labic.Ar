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
    public class MetricasViewController : Controller
    {
        private readonly LabicArContext _context;

        public MetricasViewController(LabicArContext context)
        {
            _context = context;
        }

        // GET: MetricaViews
        public async Task<IActionResult> Index(string SortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["NombreSortParm"] = String.IsNullOrEmpty(SortOrder) ? "nombre_desc" : "";
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

            var metricasView = from m in _context.MetricasView select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                metricasView = metricasView.Where(m => m.Documento.Contains(searchString) || m.Nombre.Contains(searchString) || m.Apellido.Contains(searchString) || m.UserName.Contains(searchString));

            }

            switch (SortOrder)
            {
                case "nombre_desc":
                    metricasView = metricasView.OrderByDescending(m => m.Nombre);
                    break;
                case "apellido_desc":
                    metricasView = metricasView.OrderByDescending(m => m.Apellido);
                    break;
                case "apellido_asc":
                    metricasView = metricasView.OrderBy(m => m.Apellido);
                    break;
                case "documento_desc":
                    metricasView = metricasView.OrderByDescending(m => m.Documento);
                    break;
                case "documento_asc":
                    metricasView = metricasView.OrderBy(m => m.Documento);
                    break;
                case "useName_desc":
                    metricasView = metricasView.OrderByDescending(m => m.UserName);
                    break;
                case "useName_asc":
                    metricasView = metricasView.OrderBy(m => m.UserName);
                    break;
                default:
                    metricasView = metricasView.OrderBy(m => m.Nombre).OrderBy(m => m.HoraInicio );
                    break;


            }

            int pageSize = 7;
            return View(await Paginacion<MetricasView>.CreateAsync(metricasView.AsNoTracking(), page ?? 1, pageSize));
            //return View(await _context.MetricasView.ToListAsync());
        }

        // GET: MetricaViews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metricaView = await _context.MetricasView
                .FirstOrDefaultAsync(m => m.MetricsId == id);
            if (metricaView == null)
            {
                return NotFound();
            }

            return View(metricaView);
        }

        // GET: MetricaViews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetricaViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MetricsId,JugadoresId,UserName,Nombre,Apellido,HoraInicio,ObservacionProfesor")] MetricasView metricaView)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metricaView);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metricaView);
        }

        // GET: MetricaViews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metricaView = await _context.MetricasView.FindAsync(id);
            if (metricaView == null)
            {
                return NotFound();
            }
            return View(metricaView);
        }

        // POST: MetricaViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MetricsId,JugadoresId,UserName,Nombre,Apellido,HoraInicio,ObservacionProfesor")] MetricasView metricaView)
        {
            if (id != metricaView.MetricsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metricaView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetricaViewExists(metricaView.MetricsId))
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
            return View(metricaView);
        }

        // GET: MetricaViews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metricaView = await _context.MetricasView
                .FirstOrDefaultAsync(m => m.MetricsId == id);
            if (metricaView == null)
            {
                return NotFound();
            }

            return View(metricaView);
        }

        // POST: MetricaViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metricaView = await _context.MetricasView.FindAsync(id);
            _context.MetricasView.Remove(metricaView);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetricaViewExists(int id)
        {
            return _context.MetricasView.Any(e => e.MetricsId == id);
        }
    }
}
