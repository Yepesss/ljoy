using System;
using Newtonsoft.Json;

namespace ljoy.entiteiten
{
    public class NieuwsEntiteit
    {
        public NieuwsEntiteit()
        {
        }

        [JsonProperty(PropertyName = "nieuwsid")]
        public int nieuwsid { set; get; }

        [JsonProperty(PropertyName = "titel")]
        public string titel { set; get; }

        [JsonProperty(PropertyName = "datum")]
        public string datum { set; get; }

        [JsonProperty(PropertyName = "tekst")]
        public string tekst { set; get; }
    }
}
