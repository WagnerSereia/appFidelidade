using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppFidelidade.Services;
using AppFidelidade.Views;
using AppFidelidade.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppFidelidade
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "https://supera.produquimica.com.br";//"http://localhost:5000";
        public static bool UseMockDataStore = true;
        public static UsuarioViewModel UsuarioVM { get; set; }

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            if (UsuarioVM == null) UsuarioVM = new UsuarioViewModel();

            MainPage = new NavigationPage(new Views.LoginPage() { BindingContext = App.UsuarioVM });
            //MainPage = new NavigationPage(new Views.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
