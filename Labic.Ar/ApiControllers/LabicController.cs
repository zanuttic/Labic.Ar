using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labic.Ar.Models;

namespace Labic.Ar.ApiControllers
{
    //[Produces("application")]
    [Route("api/[controller]")]
    [ApiController]
    public class LabicController : ControllerBase
    {
        private readonly LabicArContext _context;

        
        public LabicController(LabicArContext context)
        {
            _context = context;
        }

        // GET: api/Labic
        [HttpGet]
        public IEnumerable<Juegos> GetJuegos()
        {
            return _context.Juegos;
        }

        // GET: api/Labic/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJuegos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var juegos = await _context.Juegos.FindAsync(id);

            if (juegos == null)
            {
                return NotFound();
            }

            return Ok(juegos);
        }

        // PUT: api/Labic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJuegos([FromRoute] int id, [FromBody] Juegos juegos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != juegos.JuegosID)
            {
                return BadRequest();
            }

            _context.Entry(juegos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JuegosExists(id))
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
        public async Task<IActionResult> PostJuegos([FromBody] Juegos juegos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Juegos.Add(juegos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJuegos", new { id = juegos.JuegosID }, juegos);
        }

        // DELETE: api/Labic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJuegos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var juegos = await _context.Juegos.FindAsync(id);
            if (juegos == null)
            {
                return NotFound();
            }

            _context.Juegos.Remove(juegos);
            await _context.SaveChangesAsync();

            return Ok(juegos);
        }

        private bool JuegosExists(int id)
        {
            return _context.Juegos.Any(e => e.JuegosID == id);
        }
    }
}