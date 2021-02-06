using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T25_Models_ER_Ex4;
using T25_Models_ER_Ex4.Model;

namespace T25_Models_ER_Ex4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly APIContext _context;

        public PeliculasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Peliculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            return await _context.Peliculas.ToListAsync();
        }

        // GET: api/Peliculas/5
        [HttpGet("{Codigo}")]
        public async Task<ActionResult<Pelicula>> GetPelicula(int Codigo)
        {
            var pelicula = await _context.Peliculas.FindAsync(Codigo);

            if (pelicula == null)
            {
                return NotFound();
            }

            return pelicula;
        }

        // PUT: api/Peliculas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{Codigo}")]
        public async Task<IActionResult> PutPelicula(int Codigo, Pelicula pelicula)
        {
            if (Codigo != pelicula.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(pelicula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(Codigo))
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

        // POST: api/Peliculas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pelicula>> PostPelicula(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPelicula", new { Codigo = pelicula.Codigo }, pelicula);
        }

        // DELETE: api/Peliculas/5
        [HttpDelete("{Codigo}")]
        public async Task<ActionResult<Pelicula>> DeletePelicula(int Codigo)
        {
            var pelicula = await _context.Peliculas.FindAsync(Codigo);
            if (pelicula == null)
            {
                return NotFound();
            }

            _context.Peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();

            return pelicula;
        }

        private bool PeliculaExists(int Codigo)
        {
            return _context.Peliculas.Any(e => e.Codigo == Codigo);
        }
    }
}
