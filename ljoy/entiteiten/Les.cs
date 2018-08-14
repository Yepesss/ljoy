using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ljoy.entiteiten
{
    public class Les
    {
<<<<<<< HEAD
        public Les(int lesid, string naam, string tijdstip, string docent, string dag, string omschrijving, int inschrijfbaar)
=======
        public Les(){
            
        }
        public Les(int lesid, string naam, string tijdstip, string docent, string dag, string omschrijving)
>>>>>>> jennes
        {
            this.lesid = lesid;
            this.naam = naam;
            this.tijdstip = tijdstip;
            this.docent = docent;
            this.dag = dag;
            this.omschrijving = omschrijving;
            this.inschrijfbaar = inschrijfbaar;

        }

        [JsonProperty(PropertyName = "lesid")]
        public int lesid { set; get; }

        [JsonProperty(PropertyName = "naam")]
        public string naam { set; get; }

        [JsonProperty(PropertyName = "tijdstip")]
        public string tijdstip { set; get; }

        [JsonProperty(PropertyName = "docent")]
        public string docent { set; get; }

        [JsonProperty(PropertyName = "dag")]
        public string dag { set; get; }

        [JsonProperty(PropertyName = "omschrijving")]
        public string omschrijving { set; get; }

        [JsonProperty(PropertyName = "inschrijfbaar")]
        public int inschrijfbaar { set; get; }

    };

    public class groupedLes : ObservableCollection<Les>
    {
        public groupedLes()
        {
        }

        public string dag { set; get; }
    }
}
