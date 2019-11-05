using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Models
{
    [Table("Instituicao")]
    public class Instituicao : EntidadeBase
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public Entidade Entidade { get; set; }

        public IEnumerable<Obra> InstObras { get; set; }
    }


}
public enum Entidade
{
    governamental = 1,
    naoGovernamental = 2,
}
