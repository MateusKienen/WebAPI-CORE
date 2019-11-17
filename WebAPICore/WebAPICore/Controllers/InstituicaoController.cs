using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dados;
using Dominio.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAPICore.Controllers
{
    // [Route("RestAPIPesquisa/[controller]")]
    [Route("RestAPIPesquisa/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        Context db = new Context();

        // GET: api/Instituicao/get
        [ActionName("get")]
        [HttpGet]
        public IEnumerable<Instituicao> GetInstituicao()
        {
            return db.Instituicao;
        }

        // GET: api/Instituicao/get/5
        [ActionName("get")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Instituicao>> GetInstituicao(int id)
        {
            var instituicao = await db.Instituicao.FindAsync(id);
            var oo = db.Obras.Where(o => o.InstituicaoId == id).Select(o => o.Id).ToList();
            Obra obra;
            foreach (var item in oo)
            {
                obra = db.Obras.Find(item);
                instituicao.Obras.Append(obra);
            }

            if (instituicao == null) return NotFound();

            return instituicao;
        }

        // PUT: api/Instituicao/put/5
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

        // POST: api/Instituicao/post
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [ActionName("post")]
        [HttpPost]
        public async Task<ActionResult<Instituicao>> PostInstituicao(int id, [FromBody] Instituicao inst)
        {
            if (!(inst.Entidade.Equals(1) || inst.Entidade.Equals(2))) return BadRequest("Obra não inserida - Valor para Entidade não cadastrado");
            db.Instituicao.Add(inst);
            await db.SaveChangesAsync();

            return Ok(inst);
        }

        // DELETE: api/Instituicao/del/5
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

            return Ok("Instituição Removida");
        }
    }
}
