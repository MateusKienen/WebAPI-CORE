using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Models
{
    abstract public class EntidadeBase
    {
        [Key]
        public int Id { get; set; }

    }
}
