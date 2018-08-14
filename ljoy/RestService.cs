using ljoy.entiteiten;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ljoy
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<string> Inloggen(string gebruikersnaam, string wachtwoord)
        {
            var uri = new Uri(String.Format("http://ljoy.dx.am/login.php", string.Empty));
            var json = "{\"gebruikersnaam\":\"" + gebruikersnaam + "\",\"wachtwoord\":\"" + wachtwoord + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        }

        public async Task<List<Les>> VerkrijgLessen()
        {
            var response = await client.GetAsync("http://ljoy.dx.am/lessen.php").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<List<Les>>(content);
        }

        public async Task<List<NieuwsEntiteit>> VerkrijgNieuws()
        {
            var response = await client.GetAsync("http://ljoy.dx.am/nieuws.php").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<List<NieuwsEntiteit>>(content);
        }

        public async Task<string> nieuwsToevoegen(string titel, string tekst)
        {
            var uri = new Uri("http://ljoy.dx.am/nieuwstoevoegen.php");
            var json = "{\"titel\":\"" + titel + "\",\"tekst\":\"" + tekst + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        }

        public async Task<string> gebruikerToevoegen(string gebruikersnaam, string email, string wachtwoord)
        {
            var uri = new Uri("http://ljoy.dx.am/gebruikertoevoegen.php");
            var json = "{\"gebruikersnaam\":\"" + gebruikersnaam + "\",\"wachtwoord\":\"" + wachtwoord + "\",\"email\":\"" + email + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        }

        public async Task<string> updateGebruiker(string gebruikersnaam, string wachtwoord)
        {
            var uri = new Uri("http://ljoy.dx.am/gebruikerupdaten.php");
            var json = "{\"gebruikersnaam\":\"" + gebruikersnaam + "\",\"wachtwoord\":\"" + wachtwoord + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        }
    }
}
