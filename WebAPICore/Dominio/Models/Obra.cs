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
        public string Autor { get; set; }

        public string Titulo { get; set; }

        public string Ano { get; set; }

        public string Edicao { get; set; }

        public string Local { get; set; }

        public string Editora { get; set; }

        public string Paginas { get; set; }

        public string Isbn { get; set; }

        public string Issn { get; set; }

       //public Instituicao instituicao { get; set; }
    }
}
