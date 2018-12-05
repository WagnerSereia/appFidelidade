using AppFidelidade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFidelidade.ViewModels
{
    public class EstabelecimentoViewModel : INotifyPropertyChanged
    {
        private string pesquisaPorDescricao;
        public string PesquisaPorDescricao
        {
            get { return pesquisaPorDescricao; }
            set
            {
                if (value == pesquisaPorDescricao) return;

                pesquisaPorDescricao = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PesquisaPorDescricao)));
                AplicarFiltro();
            }
        }

        public IEnumerable<Estabelecimento> EstabelecimentosFiltrado { get; set; } = new List<Estabelecimento>();
        public ObservableCollection<Estabelecimento> Estabelecimentos { get; set; } = new ObservableCollection<Estabelecimento>();

        public EstabelecimentoViewModel() { }

        public void AplicarFiltro()
        {
            if (PesquisaPorDescricao == null) PesquisaPorDescricao = "";

            var resultado = EstabelecimentosFiltrado.Where(n => n.Nome.ToLowerInvariant()
                                .Contains(pesquisaPorDescricao.ToLowerInvariant().Trim())).ToList();

            var removerDaLista = Estabelecimentos.Except(resultado).ToList();
            foreach (var item in removerDaLista)
            {
                Estabelecimentos.Remove(item);
            }

            for (int index = 0; index < resultado.Count; index++)
            {
                var item = resultado[index];
                if (index + 1 > Estabelecimentos.Count || !Estabelecimentos[index].Equals(item))
                    Estabelecimentos.Insert(index, item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}