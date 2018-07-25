using System;

using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace ljoy.paginas
{
    public class Contact : ContentPage
    {
        Image facebookImage;
        Image websiteImage;
        Image mailImage;
        Image youtubeImage;
        Image instagramImage;
        Image belImage;
        Image routeImage;
        Button facebookButton;
        Button websiteButton;
        Button mailButton;
        Button youtubeButton;
        Button instagramButton;
        Button belButton;

        Button routeButton;

        Label info;

        public Contact()
        {
            createButtons();
        }

        private void createButtons()
        {
            var facebookTapGesture = new TapGestureRecognizer();
            var mailTapGesture = new TapGestureRecognizer();
            var websiteTapGesture = new TapGestureRecognizer();
            var youtubeTapGesture = new TapGestureRecognizer();
            var instagramTapGesture = new TapGestureRecognizer();
            var belTapGesture = new TapGestureRecognizer();

            facebookButton = new Button();
            facebookButton.BackgroundColor = Color.FromHex("#FF4081");
            facebookButton.Text = "Facebook";
            facebookButton.TextColor = Color.White;
            facebookButton.Command = new Command(openFacebook);


            websiteButton = new Button();
            websiteButton.BackgroundColor = Color.FromHex("#FF4081");
            websiteButton.Text = "Website";
            websiteButton.TextColor = Color.White;
            websiteButton.Command = new Command(openWebsite);




            mailButton = new Button();
            mailButton.BackgroundColor = Color.FromHex("#FF4081");
            mailButton.Text = "E-mail";
            mailButton.TextColor = Color.White;
            mailButton.Command = new Command(openEmail);




            youtubeButton = new Button();
            youtubeButton.BackgroundColor = Color.FromHex("#FF4081");
            youtubeButton.Text = "Youtube";
            youtubeButton.TextColor = Color.White;
            youtubeButton.Command = new Command(openYoutube);




            instagramButton = new Button();
            instagramButton.BackgroundColor = Color.FromHex("#FF4081");
            instagramButton.Text = "Instagram";
            instagramButton.TextColor = Color.White;
            instagramButton.Command = new Command(openInstagram);




            belButton = new Button();
            belButton.BackgroundColor = Color.FromHex("#FF4081");
            belButton.Text = "Telefoon";
            belButton.TextColor = Color.White;
            belButton.Command = new Command(openTelefoon);



            routeButton = new Button();
            routeButton.BackgroundColor = Color.FromHex("#FF4081");
            routeButton.Text = "Routebeschrijving";
            routeButton.Command = new Command(routebeschrijving);
            routeButton.TextColor = Color.White;





            facebookImage = new Image();
            facebookImage.Source = "fb.png";
            facebookImage.HorizontalOptions = LayoutOptions.Center;
            facebookImage.Aspect = Aspect.AspectFit; 

            websiteImage = new Image();
            websiteImage.Source = "website.png";
            websiteImage.HorizontalOptions = LayoutOptions.Center;
            websiteImage.Aspect = Aspect.AspectFit;

            mailImage = new Image();
            mailImage.Source = "mail.png";
            mailImage.HorizontalOptions = LayoutOptions.Center;
            mailImage.Aspect = Aspect.AspectFit;

            youtubeImage = new Image();
            youtubeImage.Source = "youtube.png";

            youtubeImage.HorizontalOptions = LayoutOptions.Center;
            youtubeImage.Aspect = Aspect.AspectFit;

            instagramImage = new Image();
            instagramImage.Source = "instagram.png";
            instagramImage.HorizontalOptions = LayoutOptions.Center;
            instagramImage.Aspect = Aspect.AspectFit;

            belImage = new Image();
            belImage.Source = "telefoon.png";
            belImage.HorizontalOptions = LayoutOptions.Center;
            belImage.Aspect = Aspect.AspectFit;

            routeImage = new Image();
            routeImage.Source = "route.png";
            routeImage.HorizontalOptions = LayoutOptions.Center;
            routeImage.Aspect = Aspect.AspectFit;

            info = new Label();
            info.Text = "L-Joy Dancefactory, Lage Ham 184" 
                + "\r\n" 
                + "5102 AE Dongen";
            info.HorizontalTextAlignment = TextAlignment.Center;
            info.FontSize = 16;
            info.TextColor = Color.Gray;

            var map = new Map(MapSpan.FromCenterAndRadius(new Position(51.643069, 4.931379), Distance.FromMiles(2)))
            {
                IsShowingUser = true,
                HeightRequest = 250,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
                                               
            };

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(51.643069, 4.931379),
                Label = "L-Joy Dancefactory",
                Address = "Lage Ham 184, 5102 AE Dongen"

            };

            map.Pins.Add(pin);

            var grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });


            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });

            grid.Children.Add(info, 1, 0);

            grid.Children.Add(facebookButton, 1, 1);
            grid.Children.Add(facebookImage, 2, 1);

            grid.Children.Add(mailButton, 1, 2);
            grid.Children.Add(mailImage, 2, 2);


            grid.Children.Add(websiteButton, 1, 3);
            grid.Children.Add(websiteImage, 2, 3);


            grid.Children.Add(youtubeButton, 1, 4);
            grid.Children.Add(youtubeImage, 2, 4);


            grid.Children.Add(instagramButton, 1, 5);
            grid.Children.Add(instagramImage, 2, 5);

            grid.Children.Add(belButton, 1, 6);
            grid.Children.Add(belImage, 2, 6);

            grid.Children.Add(routeButton, 1, 7);
            grid.Children.Add(routeImage, 2, 7);


            Grid.SetColumnSpan(facebookButton, 3);
            Grid.SetColumnSpan(mailButton, 3);
            Grid.SetColumnSpan(websiteButton, 3);
            Grid.SetColumnSpan(youtubeButton, 3);
            Grid.SetColumnSpan(instagramButton, 3);
            Grid.SetColumnSpan(belButton, 3);
            Grid.SetColumnSpan(routeButton, 3);
            Grid.SetColumnSpan(info, 3);


            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                        map,
                        //routeButton,
                        grid
                    }
                }
            };
        }

        private void routebeschrijving()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                Device.OpenUri(new Uri("http://maps.apple.com/?daddr=51.643069,4.931379"));
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                Device.OpenUri(new Uri("http://maps.google.com/?daddr=51.643069,4.931379"));
            }
        }

        private void openFacebook()
        {
            Device.OpenUri(new Uri("fb://page/159903424152451"));

        }

        private void openEmail()
        {
            Device.OpenUri(new Uri("mailto:info@l-joy.nl"));

        }

        private void openWebsite()
        {
            Device.OpenUri(new Uri("http://www.l-joy.nl"));

        }

        private void openYoutube()
        {
            Device.OpenUri(new Uri("https://www.youtube.com/channel/UCDU4dy3AkU0X4028pyvuqIg"));

        }

        private void openInstagram()
        {
            Device.OpenUri(new Uri("instagram://user?username=ljoydancefactory"));

        }

        private void openTelefoon()
        {
            Device.OpenUri(new Uri("tel:0653109856"));

        }
    }
}

