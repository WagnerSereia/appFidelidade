using AppFidelidade.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFidelidade.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstabelecimentoPage : ContentPage
    {
        ViewModelEstabelecimentos _vmEstabelecimento;

        public EstabelecimentoPage()
        {
            if (_vmEstabelecimento == null)
                _vmEstabelecimento = new ViewModelEstabelecimentos();


            BindingContext = _vmEstabelecimento;
            InitializeComponent();
            Task.Delay(10);
            LoadEstabelecimentos();

        }

        private async void LoadEstabelecimentos()
        {
            var httpRequest = new HttpClient();
            var stream = await httpRequest
                .GetStringAsync("https://supera.produquimica.com.br/api/Estabelecimentos/list");

            _vmEstabelecimento.EstabelecimentosFiltrado.Clear();

            var result = JsonConvert.DeserializeObject<List<Estabelecimento>>(stream);

            foreach (var item in result)
            {
                Estabelecimento estabelecimento = new Estabelecimento()
                {
                    IdEstabelecimento = item.IdEstabelecimento,
                    Nome = item.Nome,
                    Sobre = item.Sobre,
                    Telefone = item.Telefone,
                    Site = item.Site,
                    Localizacao = item.Localizacao
                };

                _vmEstabelecimento.EstabelecimentosFiltrado.Add(estabelecimento);
                _vmEstabelecimento.AplicarFiltro();
            }

        }


        private void LstEstabelecimento_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelecionado = e.Item as Estabelecimento;
            DisplayAlert("Estabelecimento Selecionado:",                
                $"\nNome: {itemSelecionado.Nome} \n" +
                $"Telefone: {itemSelecionado.Telefone} \n" +
                $"Site: {itemSelecionado.Site} \n" +
                $"Localização: {itemSelecionado.Localizacao}"
                , "OK");
        }

        private async void OnAtualizar_Refreshing(object sender, EventArgs e)
        {
            var lista = ((ListView)sender);
            try
            {
                await Task.Delay(2000);
                LoadEstabelecimentos();
            }
            catch (Exception)
            {

            }
            finally
            {
                lista.EndRefresh();
            }
        }
    }

    public class ViewModelEstabelecimentos : INotifyPropertyChanged
    {
        private string pesquisaPorNome;

        public List<Estabelecimento> EstabelecimentosFiltrado { get; set; } = new List<Estabelecimento>();
        public ObservableCollection<Estabelecimento> Estabelecimentos { get; set; } = new ObservableCollection<Estabelecimento>();
        public ViewModelEstabelecimentos() { }

        public string PesquisaPorNome
        {
            get { return pesquisaPorNome; }
            set
            {
                if (value == pesquisaPorNome) return;

                pesquisaPorNome = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PesquisaPorNome)));
                AplicarFiltro();
            }
        }


        public void AplicarFiltro()
        {
            if (PesquisaPorNome == null) PesquisaPorNome = "";

            var resultado = EstabelecimentosFiltrado.Where(n => n.Nome.ToLowerInvariant()
                                .Contains(pesquisaPorNome.ToLowerInvariant().Trim())).ToList();

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