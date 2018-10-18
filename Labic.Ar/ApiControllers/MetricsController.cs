using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labic.Ar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labic.Ar.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private readonly LabicArContext _context;

        public MetricsController(LabicArContext context)
        {
            _context = context;
        }
        // GET: api/Metrics
        [HttpGet]
        public IEnumerable<Metrics> GetMetrics()
        {
            return _context.Metrics.Include( e=>e.Eventos);
        }

        // GET: api/Labic/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMetrics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Metrics = await _context.Metrics.FindAsync(id);

            if (Metrics == null)
            {
                return NotFound();
            }

            return Ok(Metrics);
        }

        // PUT: api/Labic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetrics([FromRoute] int id, [FromBody] Metrics Metrics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Metrics.MetricsId)
            {
                return BadRequest();
            }

            _context.Entry(Metrics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetricsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Labic
        [HttpPost]
        public async Task<IActionResult> PostMetrics([FromBody] Metrics Metrics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Metrics.Add(Metrics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetrics", new { id = Metrics.MetricsId }, Metrics);
        }

        // DELETE: api/Labic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetrics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Metrics = await _context.Metrics.FindAsync(id);
            if (Metrics == null)
            {
                return NotFound();
            }

            _context.Metrics.Remove(Metrics);
            await _context.SaveChangesAsync();

            return Ok(Metrics);
        }

        private bool MetricsExists(int id)
        {
            return _context.Metrics.Any(e => e.MetricsId == id);
        }
    }
}
