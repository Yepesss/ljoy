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
                    await DisplayAlert("Oeps..", "Gebruikersnaam of email bestaat niet..", "Ok");

                }
                else if (response.Equals("2"))
                {
                    await DisplayAlert("Oeps..", "Er is iets fout gegaan, probeer het opnieuw.", "Ok");

                }
                else
                {
                    email.SendMail mail = new email.SendMail();
                    mail.EmailVerzenden("Nieuw wachtwoord", "Uw nieuwe wachtwoord is " + nieuwWachtwoord, response, "Skijndelaar");
                }
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