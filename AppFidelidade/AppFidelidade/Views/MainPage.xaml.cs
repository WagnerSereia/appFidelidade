using AppFidelidade.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFidelidade.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Home, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {                    
                    case (int)MenuItemType.MinhaConta:
                        MenuPages.Add(id, new NavigationPage(new MinhaContaPage()));
                        break;
                    case (int)MenuItemType.MeusPontos:
                        MenuPages.Add(id, new NavigationPage(new MeusPontosPage()));
                        break;
                    case (int)MenuItemType.Estabelecimento:
                        MenuPages.Add(id, new NavigationPage(new EstabelecimentoPage()));
                        break;
                    case (int)MenuItemType.Favoritos:
                        MenuPages.Add(id, new NavigationPage(new FavoritosPage()));
                        break;
                    case (int)MenuItemType.LocalizarEstabelecimento:
                        MenuPages.Add(id, new NavigationPage(new LocalizarEstabelecimentoPage()));
                        break;
                    case (int)MenuItemType.Sair:                        
                        MenuPages.Add(id, new NavigationPage(new Views.LoginPage() { BindingContext = App.UsuarioVM }));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(10);

                IsPresented = false;
            }
        }
    }
}