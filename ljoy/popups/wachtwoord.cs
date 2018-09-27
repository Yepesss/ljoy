using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ljoy.popups
{
	public class wachtwoord : PopupPage
	{
        private static Random random = new Random();


        public wachtwoord ()
		{
            Entry gebruikersnaam_of_email = new Entry { Placeholder = "Gebruikersnaam of email" };

            Button verzendknop = new Button { Text = "Wachtwoord opvragen", BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White };
            verzendknop.Clicked += async (object sender, EventArgs e) =>
            {
                RestService restService = new RestService();
                string nieuwWachtwoord = genereerWachtwoord();
                var response = await restService.WachtwoordVeranderen(gebruikersnaam_of_email.Text, nieuwWachtwoord);
                if (response.Equals("1"))
                {
                    await DisplayAlert("Mislukt!", "De gebruikersnaam of het email-adres bestaat niet.", "Ok");

                }
                else if (response.Equals("2"))
                {
                    await DisplayAlert("Mislukt!", "Er is iets fout gegaan, probeer het nog eens.", "Ok");
                }
                else
                {
                    email.SendMail mail = new email.SendMail();
                    mail.EmailVerzenden("Nieuw wachtwoord", 
                                        "Wij hebben uw wachtwoord gewijzigd op aanvraag van u." + "\r\n" + "\r\n" + 
                                        "Uw nieuwe wachtwoord is: " + nieuwWachtwoord + "\r\n" + "\r\n" +
                                        "Heeft u dit niet aangevraagd, neem dan contact op met L-Joy Dancefactory. Het telefoonnummer kunt u vinden op de site: www.l-joy.nl" + "\r\n" +
                                        "Wanneer u met uw nieuwe wachtwoord inlogd, wordt u gevraagd het wachtwoord meteen te veranderen." + "\r\n" + "\r\n" +
                                        "Met vriendelijke groet," + "\r\n" +
                                        "L-Joy Dancefactory", response, gebruikersnaam_of_email.Text);
                }
                await DisplayAlert("Gelukt!", "Er is een nieuw wachtwoord naar je email-adres gestuurd.", "Ok");
                await PopupNavigation.Instance.PopAsync();
            };
            Button terugknop = new Button { Text = "Terug", BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White};
            terugknop.Clicked += (object sender, EventArgs e) =>
            {
                PopupNavigation.Instance.PopAsync();
            };

            Content = new StackLayout {
                Margin = new Thickness(10, 10, 10, 10),
                Children = {
                    new Frame { BackgroundColor = Color.White, CornerRadius = 5, HasShadow = true, VerticalOptions = LayoutOptions.CenterAndExpand,
                        Content = new StackLayout
                        {
                            Children =
                            {
                                new Label { Text = "Wachtwoord vergeten", TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center, FontSize = 20},
                                new BoxView() { Color = Color.Black, HeightRequest = 1  },

                                gebruikersnaam_of_email,
                                verzendknop,
                                terugknop
                            }
                        }
                    }
				}
			};
		}

        private string genereerWachtwoord()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}