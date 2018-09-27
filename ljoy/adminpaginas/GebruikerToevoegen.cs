using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private async void formulierMaken()
        {
            List<entiteiten.Les> lessen = new List<entiteiten.Les>();
            List<controls.CheckBox> checkboxes = new List<controls.CheckBox>();
            popups.laadscherm scherm = new popups.laadscherm();
            await Navigation.PushPopupAsync(scherm);
            await Task.Run(async () =>
            {
                RestService con = new RestService();
                lessen = await con.VerkrijgLessen();
            });
            await Navigation.RemovePopupPageAsync(scherm);


            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });

            for (int i = 0; i < lessen.Count; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                Label label = new Label { Text = lessen[i].naam + " " + lessen[i].dag + " " + lessen[i].tijdstip, VerticalOptions = LayoutOptions.Center };
                controls.CheckBox checkbox = new controls.CheckBox();
                checkbox.IsChecked = false;
                checkbox.CheckedBackgroundImageSource = "checkbox_background";
                checkbox.CheckmarkImageSource = "checkbox_check";
                checkbox.BorderImageSource = "checkbox_border";
                checkbox.Title = "";
                checkboxes.Add(checkbox);
                grid.Children.Add(checkbox, 1, i);
                grid.Children.Add(label, 0, i);
            }



            Content = new StackLayout
            {
                Children = {
                    new ScrollView
                    {
                        Content = new StackLayout
                        {
                            Children = {
                                gebruikersnaamLabel,
                                gebruikersnaamEntry,
                                emailLabel,
                                emailEntry,
                                grid,
                                opslaanButton
                            }
                        }
                    }
                }

            };

            opslaanButton.Clicked += async (object sender, EventArgs e) =>
            {
                if (!gebruikersnaamEntry.Text.Equals("") || !emailEntry.Text.Equals(""))
                {
                    scherm = new popups.laadscherm();
                    await Navigation.PushPopupAsync(scherm);
                    await Task.Run(async () =>
                    {
                        RestService restService = new RestService();
                        var wachtwoord = genereerWachtwoord();
                        var response = await restService.gebruikerToevoegen(gebruikersnaamEntry.Text, emailEntry.Text, wachtwoord);
                        var id = await restService.VerkrijgId(gebruikersnaamEntry.Text);
                        for (int i = 0; i < lessen.Count; i++)
                        {
                            if (checkboxes[i].IsChecked)
                            {
                                await restService.lesToevoegen(id, lessen[i].lesid);
                            }
                        }
                        if ("Gelukt!".Equals(response))
                        {
                            email.SendMail email = new email.SendMail();
                            email.EmailVerzenden("Uw L-Joy account is aangemaakt",
                                                     "Bedankt voor het aanmelden bij de app van L-Joy Dancefactory! " + "\r\n" +
                                                     "Wij hebben een account voor u aangemaakt:" + "\r\n" + "\r\n" +
                                                     "Gebruikersnaam: " + gebruikersnaamEntry.Text + "\r\n" +
                                                     "Wachtwoord: " + wachtwoord + "\r\n" + "\r\n" +
                                                     "Wij adviseren om meteen in te loggen met uw wachtwoord. U wordt meteen gevraagd om uw wachtwoord aan te passen." + "\r\n" + "\r\n" +
                                                     "Met vriendelijke groet," + "\r\n" +
                                                     "L-Joy Dancefactory", emailEntry.Text, gebruikersnaamEntry.Text);
                        }
                    });
                    await Navigation.RemovePopupPageAsync(scherm);
                    await DisplayAlert("Gelukt!", "Gebruiker aangemaakt!", "Oké");
                }
                else
                {
                    await DisplayAlert("Gebruiker toevoegen", "Gebruikersnaam of email is niet ingevuld", "Ok");
                }
            };
        }

        private string genereerWachtwoord(){
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
