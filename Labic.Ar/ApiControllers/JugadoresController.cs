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
    public class JugadoresController : ControllerBase
    {
        private readonly LabicArContext _context;

        public JugadoresController(LabicArContext context)
        {
            _context = context;
        }
        // GET: api/Jugadores
        [HttpGet]
        public IEnumerable<Jugadores> GetJugadores()
        {
            return _context.Jugadores.Include(p => p.Personas);
        }

        // GET: api/Labic/5
        [HttpGet("{Documento}")]
        public async Task<IActionResult> GetJugadores([FromRoute] string documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var Jugadores = await _context.Jugadores.FindAsync(id);
            try
            {
                var Jugadores = await _context.Jugadores.Include(p => p.Personas).FirstAsync(p => p.Personas.Documento == documento);

                if (Jugadores == null)
                {
                    return Ok(new Jugadores() { UserName = "NotFound", Personas = new Personas() { } });
                }

                return Ok(Jugadores);
            }
            catch (Exception e)
            {
                return Ok(new Jugadores() { UserName = "NotFound", Personas = new Personas() { } });

            }

            
        }

        // PUT: api/Labic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJugadores([FromRoute] int id, [FromBody] Jugadores Jugadores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Jugadores.JugadoresId)
            {
                return BadRequest();
            }

            _context.Entry(Jugadores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JugadoresExists(id))
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
        public async Task<IActionResult> PostJugadores([FromBody] Jugadores Jugadores)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Jugadores.Add(Jugadores);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetJugadores", new { id = Jugadores.JugadoresId }, Jugadores);
            }
            catch(Exception ex)
            {
                return CreatedAtAction("GetJugadores", new { id = Jugadores.JugadoresId }, Jugadores);
                
            }
        }

        // DELETE: api/Labic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJugadores([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Jugadores = await _context.Jugadores.FindAsync(id);
            if (Jugadores == null)
            {
                return NotFound();
            }

            _context.Jugadores.Remove(Jugadores);
            await _context.SaveChangesAsync();

            return Ok(Jugadores);
        }

        private bool JugadoresExists(int id)
        {
            return _context.Jugadores.Any(e => e.JugadoresId == id);
        }
    }
}
