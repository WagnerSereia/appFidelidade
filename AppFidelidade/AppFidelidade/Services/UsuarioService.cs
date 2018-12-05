using AppFidelidade.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppFidelidade.Services
{
    public class UsuarioService
    {
        HttpClient client;
        IEnumerable<Usuario> usuarios;

        public UsuarioService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            usuarios = new List<Usuario>();
        }

        public async Task<bool> IsAutenticarAsync(Usuario usuarioLogar)
        {            
            //Deixamos sem proteção, para realização de teste, porém esse método utilizara autenticação via JWT
            var json = await client.GetStringAsync($"api/Usuarios/list");            

            var retorno = await Task.Run(() => JsonConvert.DeserializeObject<Header>(json));

            usuarios = retorno.data;
            
            return usuarios.Any(user => user.Email == usuarioLogar.Email && user.Senha == usuarioLogar.Senha);
        }
    }
}
