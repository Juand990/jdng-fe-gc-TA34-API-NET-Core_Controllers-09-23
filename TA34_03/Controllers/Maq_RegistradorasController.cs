using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TA34_03.Models;

namespace TA34_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Maq_RegistradorasController : ControllerBase
    {
        private readonly ProCajMaqVeContext _context;

        public Maq_RegistradorasController(ProCajMaqVeContext context)
        {
            _context = context;
        }

        // GET: api/Maq_Registradoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maq_Registradoras>>> GetMaquinas()
        {
          if (_context.Maquinas == null)
          {
              return NotFound();
          }
            return await _context.Maquinas.ToListAsync();
        }

        // GET: api/Maq_Registradoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maq_Registradoras>> GetMaq_Registradoras(int id)
        {
          if (_context.Maquinas == null)
          {
              return NotFound();
          }
            var maq_Registradoras = await _context.Maquinas.FindAsync(id);

            if (maq_Registradoras == null)
            {
                return NotFound();
            }

            return maq_Registradoras;
        }

        // PUT: api/Maq_Registradoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaq_Registradoras(int id, Maq_Registradoras maq_Registradoras)
        {
            if (id != maq_Registradoras.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(maq_Registradoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Maq_RegistradorasExists(id))
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

        // POST: api/Maq_Registradoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maq_Registradoras>> PostMaq_Registradoras(Maq_Registradoras maq_Registradoras)
        {
          if (_context.Maquinas == null)
          {
              return Problem("Entity set 'ProCajMaqVeContext.Maquinas'  is null.");
          }
            _context.Maquinas.Add(maq_Registradoras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaq_Registradoras", new { id = maq_Registradoras.Codigo }, maq_Registradoras);
        }

        // DELETE: api/Maq_Registradoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaq_Registradoras(int id)
        {
            if (_context.Maquinas == null)
            {
                return NotFound();
            }
            var maq_Registradoras = await _context.Maquinas.FindAsync(id);
            if (maq_Registradoras == null)
            {
                return NotFound();
            }

            _context.Maquinas.Remove(maq_Registradoras);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Maq_RegistradorasExists(int id)
        {
            return (_context.Maquinas?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
