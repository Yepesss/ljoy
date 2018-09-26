using Rg.Plugins.Popup.Extensions;
using System;
using System.Threading.Tasks;
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

        Label wachtwoordVergeten;
        string result;

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
            gebruikersnaam.HorizontalOptions = LayoutOptions.FillAndExpand;
            gebruikersnaam.VerticalOptions = LayoutOptions.Center;
            gebruikersnaam.Placeholder = "Gebruikersnaam";


            wachtwoord = new Entry();
            wachtwoord.HorizontalTextAlignment = TextAlignment.Start;
            wachtwoord.IsPassword = true;
            wachtwoord.HorizontalOptions = LayoutOptions.FillAndExpand;

            wachtwoord.VerticalOptions = LayoutOptions.Center;

            wachtwoord.Placeholder = "Wachtwoord";

            login_knop = new Button();
            login_knop.Text = "Log in";
            login_knop.TextColor = Color.White;
            login_knop.BackgroundColor = Color.FromHex("#FF4081");
            login_knop.VerticalOptions = LayoutOptions.Center;
            login_knop.Clicked += async (object sender, EventArgs e) =>
            {
                try
                {
                    if (!gebruikersnaam.Text.Equals("") || !wachtwoord.Text.Equals(""))
                    {
                        popups.laadscherm scherm = new popups.laadscherm();
                        await Navigation.PushPopupAsync(scherm);

                        await Task.Run(() =>    // by putting this Task.Run only the Activity Indicator is shown otherwise its not shown.  So we have added this.
                        {
                        //0 = gebruikersnaam niet gevonden
                        //1 = goed
                        //2 = wachtwoord fout
                        //3 = goed maar eerste keer ingelogd
                        RestService con = new RestService();
                            result = con.Inloggen(gebruikersnaam.Text, wachtwoord.Text).Result;
                        });

                        if ("0".Equals(result))
                        {

                            await Navigation.RemovePopupPageAsync(scherm);
                            await DisplayAlert("Oeps..", "Gebruikersnaam bestaat niet..", "Ok");
                        }
                        else if ("1".Equals(result))
                        {
                            if ("admin".Equals(gebruikersnaam.Text.ToLower()))
                            {
                                await Navigation.PushModalAsync(new NavigationPage(new applicatie.AdminStarter()));
                                await Navigation.RemovePopupPageAsync(scherm);
                            }
                            else
                            {
                                helper.Settings.UsernameSettings = gebruikersnaam.Text;
                                await Navigation.PushAsync(new applicatie.ApplicatieStarter());
                                RestService con = new RestService();
                                helper.Settings.IdSettings = await con.VerkrijgId(gebruikersnaam.Text);
                                await Navigation.RemovePopupPageAsync(scherm);
                            }
                        }
                        else if ("2".Equals(result))
                        {
                            await DisplayAlert("Oeps..", "Wachtwoord is fout..", "Ok");
                            await Navigation.RemovePopupPageAsync(scherm);
                        }
                        else if ("3".Equals(result))
                        {
                            popups.wachtwoordVeranderen wachtwoordVeranderen = new popups.wachtwoordVeranderen(gebruikersnaam.Text);
                            await Navigation.PushPopupAsync(wachtwoordVeranderen);
                        }
                    }
                    else
                    {
                        await DisplayAlert("Oeps..", "Gebruikersnaam of wachtwoord is niet ingevuld.", "Ok");
                    }
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Oeps..", ex.ToString(), "Ok");

                }



            };

            of = new Label();
            of.HorizontalTextAlignment = TextAlignment.Center;
            of.Text = "OF";
            of.FontAttributes = FontAttributes.Bold;
            of.VerticalTextAlignment = TextAlignment.Center;

            wachtwoordVergeten = new Label();
            wachtwoordVergeten.Text = "Wachtwoord vergeten?";
            wachtwoordVergeten.FontAttributes = FontAttributes.Italic;
            wachtwoordVergeten.HorizontalTextAlignment = TextAlignment.Center;
            wachtwoordVergeten.BackgroundColor = Color.Transparent;
            wachtwoordVergeten.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLabelClicked()),
            });



            gast_knop = new Button();
            gast_knop.Text = "Ga door als gast";
            gast_knop.TextColor = Color.White;
            gast_knop.BackgroundColor = Color.FromHex("#FF4081");
            gast_knop.VerticalOptions = LayoutOptions.Center;
            gast_knop.Clicked += async (object sender, EventArgs e) =>
            {
                popups.laadscherm scherm = new popups.laadscherm();
                await Navigation.PushPopupAsync(scherm);
                await Navigation.PushAsync(new applicatie.ApplicatieStarter());
                await Navigation.RemovePopupPageAsync(scherm);



            };

            Content = new StackLayout
            {
                Margin = new Thickness(20, 20, 20, 20),
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, VerticalOptions = LayoutOptions.Center, Opacity = 0.9f,
                        Content = new StackLayout {
                        Children =
                            {
                                new StackLayout{
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        accountIcon,
                                        gebruikersnaam
                                    }
                                },
                                new StackLayout{
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        passwordIcon,
                                        wachtwoord
                                    }
                                },
                                login_knop,
                                wachtwoordVergeten,
                                new BoxView() { Color = Color.Black, HeightRequest = 1  },
                                gast_knop

                            }
                        }
                    }
                }
            };
        }

        private void OnLabelClicked()
        {
            Navigation.PushPopupAsync(new popups.wachtwoord());
        }
    }
}
