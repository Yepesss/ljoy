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
        Label of;
        Button gast_knop;
        Image accountIcon;
        Image passwordIcon;


        public Login()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            BackgroundImage = "loginbackground.png";

            accountIcon = new Image();
            accountIcon.Source = "account_icon.png";
            accountIcon.HorizontalOptions = LayoutOptions.Center;
            accountIcon.VerticalOptions = LayoutOptions.Center;
            accountIcon.Aspect = Aspect.AspectFit;

            passwordIcon = new Image();
            passwordIcon.Source = "password_icon.png";
            passwordIcon.HorizontalOptions = LayoutOptions.Center;
            passwordIcon.VerticalOptions = LayoutOptions.Center;
            accountIcon.Aspect = Aspect.AspectFit;



            gebruikersnaam = new Entry();
            gebruikersnaam.HorizontalTextAlignment = TextAlignment.Start;
            gebruikersnaam.VerticalOptions = LayoutOptions.Center;
            gebruikersnaam.Placeholder = "Gebruikersnaam";
            gebruikersnaam.VerticalOptions = LayoutOptions.Center;


            wachtwoord = new Entry();
            wachtwoord.HorizontalTextAlignment = TextAlignment.Start;
            wachtwoord.IsPassword = true;
            wachtwoord.VerticalOptions = LayoutOptions.Center;

            wachtwoord.Placeholder = "Wachtwoord";



            login_knop = new Button();
            login_knop.Text = "Log in";
            login_knop.Command = new Command(_Login);
            login_knop.TextColor = Color.White;
            login_knop.BackgroundColor = Color.FromHex("#FF4081");
            login_knop.VerticalOptions = LayoutOptions.Center;




            of = new Label();
            of.HorizontalTextAlignment = TextAlignment.Center;
            of.Text = "OF";
            of.FontAttributes = FontAttributes.Bold;
            of.VerticalTextAlignment = TextAlignment.Center;



            gast_knop = new Button();
            gast_knop.Text = "Ga door als gast";
            gast_knop.Command = new Command(_Login);
            gast_knop.TextColor = Color.White;
            gast_knop.BackgroundColor = Color.FromHex("#FF4081");
            gast_knop.VerticalOptions = LayoutOptions.Center;



            var grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(190) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(190) });

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });

            grid.Children.Add(accountIcon, 1, 1);
            grid.Children.Add(passwordIcon, 1, 2);
            grid.Children.Add(gebruikersnaam, 2, 1);
            grid.Children.Add(wachtwoord, 2, 2);
            grid.Children.Add(login_knop, 1, 3);
            grid.Children.Add(of, 1, 4);
            grid.Children.Add(gast_knop, 1, 5);         

            Grid.SetColumnSpan(login_knop, 2);
            Grid.SetColumnSpan(of, 2);
            Grid.SetColumnSpan(gast_knop, 2);






            Content = new StackLayout
            {
                Children = {
                    grid
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
