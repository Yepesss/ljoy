using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ljoy.paginas
{
    public partial class Login : ContentPage
    {
        Entry gebruikersnaam;
        Entry wachtwoord;
        Button login_knop;

        public Login()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            gebruikersnaam = new Entry();
            gebruikersnaam.HorizontalTextAlignment = TextAlignment.Center;
            gebruikersnaam.Placeholder = "Gebruikersnaam";

            wachtwoord = new Entry();
            wachtwoord.HorizontalTextAlignment = TextAlignment.Center;
            wachtwoord.Placeholder = "Wachtwoord";

            login_knop = new Button();
            login_knop.Text = "Log in";
            login_knop.Command = new Command(_Login);

            Content = new StackLayout
            {

                VerticalOptions = LayoutOptions.Center,
                Children = {
                    gebruikersnaam,
                    wachtwoord,
                    login_knop
                }
            };
        }

        public void _Login()
        {
            DisplayAlert("Log in", gebruikersnaam.Text + " " + wachtwoord.Text, "Ok");
            Navigation.PushAsync(new applicatie.ApplicatieStarter());
        }
    }
}
