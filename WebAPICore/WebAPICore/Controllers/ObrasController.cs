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
        public IEnumerable<Obra> GetObras()
        {
            return db.Obras;
        }

        // GET: api/Obras/5
        [HttpGet("{id}")]
        public ActionResult<Obra> GetObra(int id)
        {
            Obra obra = db.Obras.Find(id);

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
        public ActionResult<Obra> PutObra(int id, [FromBody] Obra obra)
        {
            if (id != obra.Id)
            {
                return BadRequest();
            }

            db.Entry(obra).State = EntityState.Modified;

            try
            {
                db.SaveChangesAsync();
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

            return obra;
        }

        // POST: api/Obras
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult Post([FromBody]Obra obra)
        {
            db.Obras.Add(obra);
            db.SaveChanges();

            return Ok(obra);

        }



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
