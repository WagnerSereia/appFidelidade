using AppFidelidade.MobileAppService.Interfaces;
using AppFidelidade.MobileAppService.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFidelidade.MobileAppService.Repository
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private static ConcurrentDictionary<string, Estabelecimento> estabelecimentos =
           new ConcurrentDictionary<string, Estabelecimento>();

        public EstabelecimentoRepository()
        {
            Add(new Estabelecimento { EstabelecimentoId = Guid.NewGuid(), Nome = "Estabelecimento 1", Sobre = "Texto que fala sobre o estabelecimento1.",Telefone="+5511981715528",Latitude=-23.573782,Longitude=-46.623438,site="https://www.fiap.com.br/",Localizacao="Av. Lins de Vasconcelos, 1222 - São Paulo" });
            Add(new Estabelecimento { EstabelecimentoId = Guid.NewGuid(), Nome = "Estabelecimento 2", Sobre = "Texto que fala sobre o estabelecimento2.",Telefone="+5511981715529",Latitude=-23.573782,Longitude=-46.623439,site="https://www.fiap.com.br/",Localizacao="Av. Lins de Vasconcelos, 1230 - São Paulo" });
            Add(new Estabelecimento { EstabelecimentoId = Guid.NewGuid(), Nome = "Estabelecimento 3", Sobre = "Texto que fala sobre o estabelecimento3.",Telefone="+5511981715530",Latitude=-23.573782,Longitude=-46.623440,site="https://www.fiap.com.br", Localizacao="Av. Lins de Vasconcelos, 1235 - São Paulo" });       
        }

        public Estabelecimento Get(string id)
        {
            return estabelecimentos[id];
        }

        public IEnumerable<Estabelecimento> GetAll()
        {
            return estabelecimentos.Values;
        }

        public void Add(Estabelecimento estabelecimento)
        {
            estabelecimento.EstabelecimentoId = Guid.NewGuid();
            estabelecimentos[estabelecimento.EstabelecimentoId.ToString()] = estabelecimento;
        }

        public Estabelecimento Find(string id)
        {
            Estabelecimento estabelecimento;
            estabelecimentos.TryGetValue(id, out estabelecimento);

            return estabelecimento;
        }

        public Estabelecimento Remove(string id)
        {
            Estabelecimento estabelecimento;
            estabelecimentos.TryRemove(id, out estabelecimento);

            return estabelecimento;
        }

        public void Update(Estabelecimento estabelecimento)
        {
            estabelecimentos[estabelecimento.EstabelecimentoId.ToString()] = estabelecimento;
        }
    }
}
