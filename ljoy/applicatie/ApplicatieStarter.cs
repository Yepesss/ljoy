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
            var lesPagina = new paginas.Lessen();
            lesPagina.Title = "Lessen";

            //Maak de contactpagina aan
            var contactPagina = new paginas.Contact();
            contactPagina.Title = "Contact";

            if (Device.RuntimePlatform == Device.iOS)
            {
                nieuwsPagina.Icon = "nieuws.png";
                lesPagina.Icon = "inschrijven.png";
                contactPagina.Icon = "contact.png";
            }

            this.Children.Add(nieuwsPagina);
            this.Children.Add(lesPagina);
            this.Children.Add(contactPagina);
        }
    }
}

