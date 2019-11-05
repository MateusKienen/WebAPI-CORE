using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dados;
using Dominio.Models;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasController : ControllerBase
    {

        Context db = new Context();

        // GET: api/Obras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Obra>>> GetObras()
        {
            return await db.Obras.ToListAsync();
        }

        // GET: api/Obras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Obra>> GetObra(int id)
        {
            var obra = await db.Obras.FindAsync(id);

            if (obra == null)
            {
                return NotFound();
            }

            return obra;
        }

        // PUT: api/Obras/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObra(int id, Obra obra)
        {
            if (id != obra.Id)
            {
                return BadRequest();
            }

            db.Entry(obra).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObraExists(id))
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

        // POST: api/Obras
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult Post([FromBody]Obra obra)
        {
            //db.Obras.Add(obra);
            //db.SaveChangesAsync();
            Obra ob = new Obra();
            ob.Ano = obra.Ano;
            ob.Autor = obra.Autor;
            ob.Edicao = obra.Edicao;
            ob.Editora = obra.Editora;
            ob.Isbn = obra.Isbn;
            ob.Issn = obra.Issn;
            ob.Paginas = obra.Paginas;
            ob.Titulo = obra.Titulo;
            db.Obras.Add(ob);

            return CreatedAtAction(nameof(GetObra), new { id = obra.Id }, obra);
        }



        //public async Task<ActionResult<Obra>> PostObra(Obra obra)
        //{
        //    _context.Obras.Add(obra);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetObra), new { id = obra.Id }, obra);
        //}

        // DELETE: api/Obras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Obra>> DeleteObra(int id)
        {
            var obra = await db.Obras.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }

            db.Obras.Remove(obra);
            await db.SaveChangesAsync();

            return obra;
        }

        private bool ObraExists(int id)
        {
            return db.Obras.Any(e => e.Id == id);
        }
    }
}
