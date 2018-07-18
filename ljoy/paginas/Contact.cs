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

            facebookImage = new Image();
            facebookImage.Source = "fb.png";
            facebookImage.WidthRequest = 36;
            facebookImage.HeightRequest = 36;
            facebookImage.HorizontalOptions = LayoutOptions.Center;
            facebookImage.Aspect = Aspect.AspectFit; 
            facebookImage.GestureRecognizers.Add(facebookTapGesture);

            websiteImage = new Image();
            websiteImage.Source = "website.png";
            websiteImage.WidthRequest = 36;
            websiteImage.HeightRequest = 36;
            websiteImage.HorizontalOptions = LayoutOptions.Center;
            websiteImage.Aspect = Aspect.AspectFit;
            websiteImage.GestureRecognizers.Add(websiteTapGesture);

            mailImage = new Image();
            mailImage.Source = "mail.png";
            mailImage.WidthRequest = 36;
            mailImage.HeightRequest = 36;
            mailImage.HorizontalOptions = LayoutOptions.Center;
            mailImage.Aspect = Aspect.AspectFit;
            mailImage.GestureRecognizers.Add(mailTapGesture);

            youtubeImage = new Image();
            youtubeImage.Source = "youtube.png";
            youtubeImage.WidthRequest = 36;
            youtubeImage.HeightRequest = 36;
            youtubeImage.HorizontalOptions = LayoutOptions.Center;
            youtubeImage.Aspect = Aspect.AspectFit;
            youtubeImage.GestureRecognizers.Add(youtubeTapGesture);

            instagramImage = new Image();
            instagramImage.Source = "instagram.png";
            instagramImage.WidthRequest = 36;
            instagramImage.HeightRequest = 36;
            instagramImage.HorizontalOptions = LayoutOptions.Center;
            instagramImage.Aspect = Aspect.AspectFit;
            instagramImage.GestureRecognizers.Add(instagramTapGesture);

            belImage = new Image();
            belImage.Source = "bel.png";
            belImage.WidthRequest = 36;
            belImage.HeightRequest = 36;
            belImage.HorizontalOptions = LayoutOptions.Center;
            belImage.Aspect = Aspect.AspectFit;
            belImage.GestureRecognizers.Add(belTapGesture);

            routeButton = new Button();
            routeButton.Image = "route.png";
            routeButton.Text = "Routebeschrijving";
            routeButton.TextColor = Color.Black;
            routeButton.Margin = 10;
            routeButton.BorderColor = Color.Black;
            routeButton.BorderWidth = 1;
            routeButton.BackgroundColor = Color.LightGray;
            routeButton.FontSize = 20;
            routeButton.Command = new Command(routebeschrijving);

            info = new Label();
            info.Text = "L-Joy Dancefactory" 
                + "\r\n" 
                + "Lage Ham 184" 
                + "\r\n" 
                + "5102 AE Dongen";
            info.HorizontalTextAlignment = TextAlignment.Start;
            info.FontSize = 24;
            info.Margin = 20;

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
                Address = "Lage Ham 184"
            };

            map.Pins.Add(pin);

            var grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            grid.Children.Add(facebookImage, 0, 0);
            grid.Children.Add(mailImage, 1, 0);
            grid.Children.Add(websiteImage, 2, 0);
            grid.Children.Add(youtubeImage, 3, 0);
            grid.Children.Add(instagramImage, 4, 0);
            grid.Children.Add(belImage, 5, 0);

            facebookTapGesture.Tapped += (s, e) => {
                Device.OpenUri(new Uri("fb://page/159903424152451"));
            };

            mailTapGesture.Tapped += (s, e) => {
                Device.OpenUri(new Uri("mailto:info@l-joy.nl"));
            };

            websiteTapGesture.Tapped += (s, e) => {
                Device.OpenUri(new Uri("http://www.l-joy.nl"));
            };

            youtubeTapGesture.Tapped += (s, e) => {
                Device.OpenUri(new Uri("https://www.youtube.com/channel/UCDU4dy3AkU0X4028pyvuqIg"));
            };

            instagramTapGesture.Tapped += (s, e) => {
                Device.OpenUri(new Uri("instagram://user?username=ljoydancefactory"));
            };

            belTapGesture.Tapped += (s, e) => {
                Device.OpenUri(new Uri("tel:0653109856"));
            };

            Content = new StackLayout
            {
                Children = {
                    map,
                    routeButton,
                    info,
                    grid
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
    }
}

