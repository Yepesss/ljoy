using System;
using System.Linq;
using Xamarin.Forms;

namespace ljoy.adminpaginas
{
    public class GebruikerToevoegen : ContentPage
    {
        private static Random random = new Random();

        private Entry gebruikersnaamEntry;
        private Entry emailEntry;

        private Label gebruikersnaamLabel;
        private Label emailLabel;

        private Button opslaanButton;

        public GebruikerToevoegen()
        {
            gebruikersnaamEntry = new Entry();
            emailEntry = new Entry();

            gebruikersnaamLabel = new Label();
            gebruikersnaamLabel.Text = "Gebruikersnaam: ";

            emailLabel = new Label();
            emailLabel.Text = "Email: ";

            opslaanButton = new Button();
            opslaanButton.Text = "Gebruiker opslaan!";

            formulierMaken();
        }

        private void formulierMaken()
        {

            Content = new StackLayout
            {
                Children = {
                    gebruikersnaamLabel,
                    gebruikersnaamEntry,
                    emailLabel,
                    emailEntry,
                    opslaanButton
                }

            };

            opslaanButton.Clicked += async (object sender, EventArgs e) =>
            {
                RestService restService = new RestService();
                var response = await restService.gebruikerToevoegen(gebruikersnaamEntry.Text, emailEntry.Text, genereerWachtwoord());
                await DisplayAlert("Gebruiker toevoegen", response, "Ok");
            };
        }

        private string genereerWachtwoord(){
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
