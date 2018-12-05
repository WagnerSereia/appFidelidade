using AppFidelidade.Models;
using AppFidelidade.Services;
using AppFidelidade.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace AppFidelidade.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        #region Propriedade
        public Usuario UsuarioModel { get; set; }
       
        private bool isloading;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnAtualizarPropriedade([CallerMemberName] string propriedade = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
        }

        public bool IsLoading
        {
            get { return isloading; }
            set
            {
                isloading = value;
                OnAtualizarPropriedade();
            }
        }


        // UI Events
        public IsAutenticarCMD IsAutenticarCMD { get; }
        #endregion

        public UsuarioViewModel()
        {
            UsuarioModel = new Usuario();
            IsAutenticarCMD = new IsAutenticarCMD(this);            
        }       
    }

    public class IsAutenticarCMD : ICommand
    {
        private UsuarioViewModel usuarioVM;         
        public IsAutenticarCMD(UsuarioViewModel paramVM)
        {
            usuarioVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public async void Execute(object parameter)
        {            
            UsuarioService usuarioService = new UsuarioService();
            var usuario = parameter as Usuario;
            if (usuario.Email != "" && usuario.Senha != "")
            {
                var validado = await usuarioService.IsAutenticarAsync(usuario);
                if(validado)
                    App.Current.MainPage = new Views.MainPage();
                else
                    App.Current.MainPage.DisplayAlert("Atenção", "Usuário ou senha incorreto", "Ok");
            }
            else
                App.Current.MainPage.DisplayAlert("Atenção", "Preencha os campos para autenticar", "Ok");
        }
    }
}
