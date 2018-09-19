using ljoy.entiteiten;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
            var uri = new Uri("http://ljoy.dx.am/lessen.php");
            var json = "{\"gebruikerid\":\"" + helper.Settings.IdSettings + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Les>>(result);
        }

        public async Task<string> VerkrijgId(string gebruikersnaam)
        {
            var uri = new Uri("http://ljoy.dx.am/id.php");
            var json = "{\"gebruikersnaam\":\"" + gebruikersnaam + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        public async Task<List<NieuwsEntiteit>> VerkrijgNieuws()
        {
            var response = await client.GetAsync("http://ljoy.dx.am/nieuws.php").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<NieuwsEntiteit>>(content);
        }

        public async Task<string> nieuwsToevoegen(string titel, string tekst)
        {
            var uri = new Uri("http://ljoy.dx.am/nieuwstoevoegen.php");
            var json = "{\"titel\":\"" + titel + "\",\"tekst\":\"" + tekst + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content).ConfigureAwait(false);
            SendNotificationFromFirebaseCloud(titel, tekst);
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

        public async Task<string> WachtwoordVeranderen(string gebruikersnaam_of_email, string wachtwoord)
        {
            var uri = new Uri("http://ljoy.dx.am/wachtwoordveranderen.php");
            var json = "{\"gebruikersnaam_of_email\":\"" + gebruikersnaam_of_email + "\",\"wachtwoord\":\"" + wachtwoord + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        }

        public async Task<string> WachtwoordVeranderenEnActiveren(string gebruikersnaam_of_email, string wachtwoord)
        {
            var uri = new Uri("http://ljoy.dx.am/wachtwoordveranderenenactiveren.php");
            var json = "{\"gebruikersnaam_of_email\":\"" + gebruikersnaam_of_email + "\",\"wachtwoord\":\"" + wachtwoord + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        private String SendNotificationFromFirebaseCloud(string titel, string tekst)
        {
            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("Authorization:key=" + "AAAAqFo8s2s:APA91bGhRox1QT84GzwmaGMKRN736J_Fyi5bdET9jWKlR2-8xFMR5mPOxWegwuHU2T8RKuAEkO-sceGNNE6w0mroN5_4xAcGS9kAOLyud-OnpAx3s7C1SeMgAJi02YBGH5B76x6SpDOF");
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"to\": \"/topics/nieuws\",\"data\": {\"title\":\"" + titel + "\",\"body\":\"" + tekst.Substring(0, 40) + "..." + "\"}}";
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
    }
}
