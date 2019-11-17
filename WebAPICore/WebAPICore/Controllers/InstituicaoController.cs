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
    // [Route("RestAPIPesquisa/[controller]")]
    [Route("RestAPIPesquisa/[controller]/[action]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        Context db = new Context();

        [ActionName("get")]
        // GET: api/Instituicao
        [HttpGet]
        public IEnumerable<Instituicao> GetInstituicao()
        {
            return db.Instituicao;
        }

        // GET: api/Instituicao/5
        [ActionName("get")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Instituicao>> GetInstituicao(int id)
        {
            var instituicao = await db.Instituicao.FindAsync(id);

            if (instituicao == null) return NotFound();

            return instituicao;
        }


        [ActionName("obras")]
        [HttpGet("{id}")]
        public ActionResult<Instituicao> GetObrasInstituicao(int id)
        {
            var inst = db.Instituicao.Find(id);
            db.Database.OpenConnection();
            db.
                //("Select o.id, o.autor, o.Titulo, o.Ano, o.Edicao, o.Local, " +
                //$"o.Editora, o.Paginas, o.Isbn, o.Issn from Obra o where o.InstituicaoId = {id}");

            //FromSqlRaw("Select o.id, o.autor, o.Titulo, o.Ano, o.Edicao, o.Local, " +
            // $"o.Editora, o.Paginas, o.Isbn, o.Issn from Obra o where o.InstituicaoId = {id}").ToList();
            //foreach (var item in sel)
            //{
            //    inst.Obras.Append(item);
            //}
            //return inst;
        }



        // PUT: api/Instituicao/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [ActionName("put")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstituicao(int id, [FromBody] Instituicao instituicao)
        {
            var ins = db.Instituicao.SingleOrDefault(x => x.Id == id);

            if (instituicao.Nome != null) ins.Nome = instituicao.Nome;
            if (instituicao.Entidade != 0) ins.Entidade = instituicao.Entidade;
            if (instituicao.Obras != null) ins.Obras = instituicao.Obras;

            await db.SaveChangesAsync();

            return Ok(ins);
        }

        // POST: api/Instituicao
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [ActionName("post")]
        [HttpPost]
        public async Task<ActionResult<Instituicao>> PostInstituicao(int id, [FromBody] Instituicao inst)
        {
            db.Instituicao.Add(inst);
            await db.SaveChangesAsync();

            return Ok(inst);

        }

        // DELETE: api/Instituicao/5
        [ActionName("del")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instituicao>> DeleteInstituicao(int id)
        {
            var instituicao = await db.Instituicao.FindAsync(id);
            if (instituicao == null)
            {
                return NotFound();
            }

            db.Instituicao.Remove(instituicao);
            await db.SaveChangesAsync();

            return instituicao;
        }
    }
}
