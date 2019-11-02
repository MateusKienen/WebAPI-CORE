using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Models
{
    [Table("Obras")]
    class Obras : EntidadeBase
    {
        [Required]
        public string Autor { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public DateTime Ano { get; set; }

        [Required]
        public string Edicao { get; set; }

        [Required]
        public string Local { get; set; }

        [Required]
        public string Editora { get; set; }

        [Required]
        public int Paginas { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        public string Issn { get; set; }



        /**
         *{
"id":"2",
"autor":"Antonio de Souza",
"titulo":"Titulo do livro",
"ano":"2017",
"edicao":"5",
"local":"Florianópolis",
"editora":"Editora",
"paginas":"228",
"isbn":"1044-102-500-2",
"issn":"10245-51-2200"

         *
         */
    }
}
