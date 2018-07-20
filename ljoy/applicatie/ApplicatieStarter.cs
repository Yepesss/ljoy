using System;
using Xamarin.Forms;

namespace ljoy.applicatie
{
    public class ApplicatieStarter : TabbedPage
    {

        public ApplicatieStarter()
        {
            NavigationPage.SetHasNavigationBar(this, false);


            //Geeft de tabbar een kleur en de tekst en plaatjes erin
            BarBackgroundColor = Color.FromHex("#FF4081");
            BarTextColor = Color.White;

            //Maak de pagina's aan
            maakPaginas();
        }

        private void maakPaginas()
        {

            //Maak de nieuwspagina aan
            var nieuwsPagina = new paginas.Nieuws();
            nieuwsPagina.Title = "Nieuws";

            //Maak de inschrijfpagina aan
            var inschrijfPagina = new paginas.Inschrijf();
            inschrijfPagina.Title = "Inschrijven";

            //Maak de contactpagina aan
            var contactPagina = new paginas.Contact();
            contactPagina.Title = "Contact";

            if (Device.RuntimePlatform == Device.iOS)
            {
                nieuwsPagina.Icon = "nieuws.png";
                inschrijfPagina.Icon = "inschrijven.png";
                contactPagina.Icon = "contact.png";
            }

            this.Children.Add(nieuwsPagina);
            this.Children.Add(inschrijfPagina);
            this.Children.Add(contactPagina);
        }
    }
}

