using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Models
{
    [Table("Obra")]
    public class Obra : EntidadeBase
    {
        [Required]
        public string Autor { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Ano { get; set; }

        [Required]
        public string Edicao { get; set; }

        [Required]
        public string Local { get; set; }

        [Required]
        public string Editora { get; set; }

        [Required]
        public string Paginas { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        public string Issn { get; set; }

    }
}
