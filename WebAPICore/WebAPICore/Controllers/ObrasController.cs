using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dados;
using Dominio.Models;
using Microsoft.AspNetCore.Authorization;
using System;

namespace WebAPICore.Controllers
{


    [Route("RestAPIPesquisa/[controller]")]
    [Authorize]
    [ApiController]
    public class ObrasController : ControllerBase
    {

        Context db = new Context();

        // GET: RestAPIPesquisa//Obras
        [HttpGet]
        public IEnumerable<Obra> GetObras()
        {
            return db.Obras;
        }

        // GET: RestAPIPesquisa//Obras/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Obra> GetObra(int id)
        {
            Obra obra = db.Obras.Find(id);

            if (obra == null) return BadRequest();

            return obra;
        }

        // PUT: RestAPIPesquisa//Obras/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObra(int id, [FromBody] Obra patchObra)
        {
            var obraDB = db.Obras.SingleOrDefault(x => x.Id == id);

            if (obraDB == null) return BadRequest();

            if (patchObra.Autor != null) obraDB.Autor = patchObra.Autor;
            if (patchObra.Ano != null) obraDB.Ano = patchObra.Ano;
            if (patchObra.Editora != null) obraDB.Editora = patchObra.Editora;
            if (patchObra.Edicao != null) obraDB.Edicao = patchObra.Edicao;
            if (patchObra.Isbn != null) obraDB.Isbn = patchObra.Isbn;
            if (patchObra.Issn != null) obraDB.Issn = patchObra.Issn;
            if (patchObra.Local != null) obraDB.Local = patchObra.Local;
            if (patchObra.Paginas != null) obraDB.Paginas = patchObra.Paginas;
            if (patchObra.Titulo != null) obraDB.Titulo = patchObra.Titulo;

            await db.SaveChangesAsync();

            return Ok(obraDB);
        }

        // POST: RestAPIPesquisa/Obras
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult Post([FromBody]Obra obra)
        {
            db.Obras.Add(obra);
            db.SaveChanges();

            return Ok(obra);

        }

        // DELETE: RestAPIPesquisa//Obras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Obra>> DeleteObra(int id)
        {
            var obra = await db.Obras.FindAsync(id);
            if (obra == null) return NotFound();

            db.Obras.Remove(obra);
            await db.SaveChangesAsync();

            return obra;
        }

        // DELETE: 
        [HttpDelete]
        public async Task<ActionResult<Obra>> DeleteObra([FromBody] Obra obraJson)
        {
            var obra = db.Obras.Where(o => o.Titulo == obraJson.Titulo).FirstOrDefault<Obra>();
            if (obra == null) return NotFound("Obra não encontrada");
            db.Remove(obra);
            await db.SaveChangesAsync();
            return Ok("obra removida");

        }
    }
}
