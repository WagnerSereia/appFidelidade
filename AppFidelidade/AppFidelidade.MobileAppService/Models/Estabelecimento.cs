using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFidelidade.MobileAppService.Models
{
    public class Estabelecimento
    {
        public Guid EstabelecimentoId;
        public string Nome { get; set; }
        public string Sobre { get; set; }
        public string Telefone { get; set; }
        public string site { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Localizacao { get; set; }
    }
}
