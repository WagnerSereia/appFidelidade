using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace AppFidelidade.Models
{
    public class Estabelecimento
    {
        public int IdEstabelecimento { get; set; }
        public string Nome { get; set; }
        public string Sobre { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public double Latitude{get;set;}
        public double Longitude { get; set; }
        public string Localizacao { get; set; }
    }    
}
