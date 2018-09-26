using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ljoy.popups
{
	public class wachtwoordVeranderenAccountPagina : PopupPage
	{
        public wachtwoordVeranderenAccountPagina ()
		{
            Entry wachtwoordOud = new Entry { Placeholder = "Oud wachtwoord" };
            Entry wachtwoordNieuw = new Entry { Placeholder = "Nieuw wachtwoord" };
            Entry wachtwoordOpnieuw = new Entry { Placeholder = "Nieuw wachtwoord (opnieuw)" };

            Button verzendknop = new Button { Text = "Wachtwoord veranderen", BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White };
            verzendknop.Clicked += async (object sender, EventArgs e) =>
            {
                if (wachtwoordNieuw.Text.Equals(wachtwoordOpnieuw.Text))
                {
                    RestService restService = new RestService();
                    var response = await restService.WachtwoordVeranderenAccountPagina(helper.Settings.UsernameSettings, wachtwoordNieuw.Text, wachtwoordOud.Text);
                    if ("0".Equals(response))
                    {
                        await DisplayAlert("Gelukt", "Uw wachtwoord is veranderd!", "Ok");
                        await PopupNavigation.Instance.PopAsync();
                    }else if ("1".Equals(response))
                    {
                        await DisplayAlert("Oeps..", "Uw oude wachtwoord is niet juist.", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Oeps..", response, "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Oeps..", "Uw nieuwe wachtwoorden komen niet overeen", "Ok");
                }
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
                                new Label { Text = "Wachtwoord veranderen", TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center, FontSize = 20},
                                new BoxView() { Color = Color.Black, HeightRequest = 1  },
                                wachtwoordOud,
                                wachtwoordNieuw,
                                wachtwoordOpnieuw,
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