using System;
using System.Collections.Generic;
using System.Text;

namespace AppFidelidade.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Home,
        MinhaConta,
        MeusPontos,
        Estabelecimento,
        Favoritos,
        LocalizarEstabelecimento,
        Sair
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
