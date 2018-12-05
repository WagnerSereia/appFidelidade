using AppFidelidade.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFidelidade.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                //new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                //new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                //new HomeMenuItem {Id = MenuItemType.Home, Title="Home" },
                new HomeMenuItem {Id = MenuItemType.MinhaConta, Title="Minha Conta" },
                new HomeMenuItem {Id = MenuItemType.MeusPontos, Title="Meus Pontos" },
                new HomeMenuItem {Id = MenuItemType.Estabelecimento, Title="Estabelecimento" },
                new HomeMenuItem {Id = MenuItemType.Favoritos, Title="Favoritos" },
                new HomeMenuItem {Id = MenuItemType.LocalizarEstabelecimento, Title="Localizar Estabelecimento" },
                new HomeMenuItem {Id = MenuItemType.Sair, Title="Sair" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}