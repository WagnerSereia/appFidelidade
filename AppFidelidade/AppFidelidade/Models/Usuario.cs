using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFidelidade.Models
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        public string nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string dataNascimento { get; set; }
        public string sexo { get; set; }        
    }

    public class Header
    {
        public string previousClass { get; set; }
        public string previous { get; set; }
        public string nextClass { get; set; }
        public string next { get; set; }
        public string pageCount { get; set; }
        public string pageNow { get; set; }
        public List<Usuario> data { get; set; }
    }    
}
