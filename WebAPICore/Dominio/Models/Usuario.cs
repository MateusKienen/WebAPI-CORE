using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Usuario : EntidadeBase
    {
        public String Login { get; set; }
        public String Senha { get; set; }

    }
}
