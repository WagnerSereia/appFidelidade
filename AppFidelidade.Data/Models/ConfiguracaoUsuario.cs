using System;
using System.Collections.Generic;

namespace AppFidelidade.Data.Models
{
    public partial class ConfiguracaoUsuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}
