using System;
using System.Collections.Generic;
using System.Text;

namespace ljoy.entiteiten
{
    public class Gebruiker
    {
        public Gebruiker () {
            
        }

        public int id { set; get; }

        public string gebruikersnaam { set; get; }

        public string wachtwoord { set; get; }
    }
}
