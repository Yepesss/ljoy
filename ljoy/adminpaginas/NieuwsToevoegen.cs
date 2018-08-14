using System;
using Xamarin.Forms;

namespace ljoy.adminpaginas
{
    public class NieuwsToevoegen : ContentPage
    {
        Entry titelEntry;
        Entry tekstEntry;

        Label titelLabel;
        Label tekstLabel;

        Button opslaanButton;

        public NieuwsToevoegen()
        {
            titelEntry = new Entry();
            tekstEntry = new Entry();

            titelLabel = new Label();
            tekstLabel = new Label();

            opslaanButton = new Button();

            titelLabel.Text = "Titel nieuws: ";
            tekstLabel.Text = "Omschrijving nieuws: ";

            opslaanButton.Text = "Opslaan nieuws!";

            formulierMaken();
        }

        private void formulierMaken(){

            Content = new StackLayout
            {
                Children = {
                    titelLabel,
                    titelEntry,
                    tekstLabel,
                    tekstEntry,
                    opslaanButton
                }

            };

            opslaanButton.Clicked += async (object sender, EventArgs e) =>
            {
                RestService restService = new RestService();
                var response = await restService.nieuwsToevoegen(titelEntry.Text, tekstEntry.Text);
                await DisplayAlert("Nieuws toevoegen", response, "Ok");
            };
        }
    }
}
