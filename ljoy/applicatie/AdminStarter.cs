using System;
using Xamarin.Forms;

namespace ljoy.applicatie
{
    public class AdminStarter : ContentPage
    {
        Button nieuwsToevoegen;
        Button gebruikerToevoegen;

        public AdminStarter()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            nieuwsToevoegen = new Button();
            gebruikerToevoegen = new Button();

            nieuwsToevoegen.Text = "Nieuws toevoegen";
            gebruikerToevoegen.Text = "Gebruiker toevoegen";

            navigatieNaarPaginas();

            Content = new StackLayout
            {
                Children = {
                    nieuwsToevoegen,
                    gebruikerToevoegen
                }
            };
        }

        private void navigatieNaarPaginas()
        {
            nieuwsToevoegen.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushAsync(new adminpaginas.NieuwsToevoegen());
            };

            gebruikerToevoegen.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushAsync(new adminpaginas.GebruikerToevoegen());
            };
        }
    }
}
