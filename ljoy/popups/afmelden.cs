using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ljoy.popups
{
	public class afmelden : PopupPage
	{
		public afmelden (entiteiten.Les les)
		{
            Entry reden = new Entry { Placeholder = "Reden (optioneel)" };

            Button verzendknop = new Button { Text = "Meld af", BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White };
            string gebruikersnaam = helper.Settings.UsernameSettings;
            verzendknop.Clicked += (object sender, EventArgs e) =>
            {
                email.SendMail mail = new email.SendMail();
                mail.EmailVerzenden("Afmelding", 
                                    "Afmelding van: " + gebruikersnaam + "\r\n" + 
                                    "Voor de les: " + les.naam + " van " + les.dag + "\r\n" +
                                    "Reden: " + reden.Text);
                DisplayAlert("Gelukt!", "U heeft u afgemeld!", "Oké");
                PopupNavigation.Instance.PopAsync();

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
                                new Label { Text = "Afmelden", TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center, FontSize = 20},
                                new BoxView() { Color = Color.Black, HeightRequest = 1  },

                                reden,
                                verzendknop,
                                terugknop
                            }
                        }
                    }
				}
			};
		}
	}
}