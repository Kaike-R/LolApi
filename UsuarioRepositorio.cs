using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LolTeste2
{   
    class UsuarioRepositorio
    {
        HttpClient client = new HttpClient();

        string key = "coloque a key aqui";

        public UsuarioRepositorio(){
            client.BaseAddress = new Uri("https://br1.api.riotgames.com");
            client.DefaultRequestHeaders.Add("X-Riot-Token",key);

            client.DefaultRequestHeaders.Accept.Add(

                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Usuario> GetUsuariosAsync(){
            HttpResponseMessage response = await client.GetAsync("/lol/summoner/v4/summoners/by-name/Wolf%20and%20Sheep");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usuario>(dados);
            }
            return new Usuario();
        }

        
    }
}