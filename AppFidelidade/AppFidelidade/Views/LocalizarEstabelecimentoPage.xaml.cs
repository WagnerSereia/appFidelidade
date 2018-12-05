using AppFidelidade.Models;
using AppFidelidade.Services;
using AppFidelidade.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppFidelidade.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalizarEstabelecimentoPage : ContentPage
    {
        EstabelecimentoViewModel _estabelecimentoVM;
        public LocalizarEstabelecimentoPage()
        {
            if (_estabelecimentoVM == null)
                _estabelecimentoVM = new EstabelecimentoViewModel();

            LoadEstabelecimentosAsync();
            Task.Delay(10);

            BindingContext = _estabelecimentoVM;


            InitializeComponent();            
        }

        private async void LoadEstabelecimentosAsync()
        {
            EstabelecimentoService estabelecimentoService = new EstabelecimentoService();

            _estabelecimentoVM.EstabelecimentosFiltrado = await estabelecimentoService.GetItemsAsync(true);

            meuMapa.Pins.Clear();
            meuMapa.PinCustomizados = new List<PinCustomizado>();
            if (_estabelecimentoVM.EstabelecimentosFiltrado == null)
                return;

            foreach (Estabelecimento item in _estabelecimentoVM.EstabelecimentosFiltrado)
            {
                var pin = new PinCustomizado
                {
                    Type = PinType.Place,
                    Position = new Position(item.Latitude, item.Longitude),
                    Label = item.Nome,
                    Address = item.Localizacao,
                    Id = item.IdEstabelecimento,
                    Localizacao = item.Site,
                    Telefone = item.Telefone
                };
                meuMapa.PinCustomizados = new List<PinCustomizado>() { pin };

                meuMapa.Pins.Add(pin);
            }


            meuMapa.MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                        new Position(-23.573783, -46.623438), Distance.FromMiles(0.1)));

        }
    }
}
