using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ljoy.entiteiten
{
    public class LesAccountPagina
    {
        public LesAccountPagina()
        {

        }

        public LesAccountPagina(string naam)
        {
            this.naam = naam;
        }

        [JsonProperty(PropertyName = "naam")]
        public string naam { set; get; }
    };
}
