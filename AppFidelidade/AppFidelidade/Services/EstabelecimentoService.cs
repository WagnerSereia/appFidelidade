using AppFidelidade.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppFidelidade.Services
{
    public class EstabelecimentoService
    {
        HttpClient client;
        
        public EstabelecimentoService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
        }

        public async Task<IEnumerable<Estabelecimento>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                var json = await client.GetStringAsync($"api/estabelecimentos/list");
                return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Estabelecimento>>(json));                                
            }
            return null;
        }

        public async Task<Estabelecimento> GetItemAsync(string id)
        {
            if (id != null)
            {
                var json = await client.GetStringAsync($"api/estabelecimento/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Estabelecimento>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Estabelecimento estabelecimento)
        {
            if (estabelecimento == null)
                return false;

            var serializedItem = JsonConvert.SerializeObject(estabelecimento);

            var response = await client.PostAsync($"api/estabelecimento", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Estabelecimento estabelecimento)
        {
            if (estabelecimento == null || estabelecimento.IdEstabelecimento == 0)
                return false;

            var serializedEstabelecimento = JsonConvert.SerializeObject(estabelecimento);
            var buffer = Encoding.UTF8.GetBytes(serializedEstabelecimento);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/estabelecimento/{estabelecimento.IdEstabelecimento}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            var response = await client.DeleteAsync($"api/estabelecimento/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
