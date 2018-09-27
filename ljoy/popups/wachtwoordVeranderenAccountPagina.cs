﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ljoy.popups
{
	public class wachtwoordVeranderenAccountPagina : PopupPage
	{
        public wachtwoordVeranderenAccountPagina ()
		{
            Entry wachtwoordOud = new Entry { Placeholder = "Oud wachtwoord", IsPassword = true };
            Entry wachtwoordNieuw = new Entry { Placeholder = "Nieuw wachtwoord", IsPassword = true };
            Entry wachtwoordOpnieuw = new Entry { Placeholder = "Nieuw wachtwoord (opnieuw)", IsPassword = true };

            Button verzendknop = new Button { Text = "Wachtwoord veranderen", BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White };
            verzendknop.Clicked += async (object sender, EventArgs e) =>
            {
                if (!"".Equals(wachtwoordOud.Text) || wachtwoordOud.Text == null || !"".Equals(wachtwoordNieuw.Text) || wachtwoordNieuw.Text == null || !"".Equals(wachtwoordOpnieuw.Text) || wachtwoordOpnieuw.Text == null)
                {
                    if (wachtwoordNieuw.Text.Equals(wachtwoordOpnieuw.Text))
                    {
                        popups.laadscherm scherm = new popups.laadscherm();
                        await Navigation.PushPopupAsync(scherm);
                        await Task.Run(async () =>    // by putting this Task.Run only the Activity Indicator is shown otherwise its not shown.  So we have added this.
                        {
                            RestService restService = new RestService();
                            var response = await restService.WachtwoordVeranderenAccountPagina(helper.Settings.UsernameSettings, wachtwoordNieuw.Text, wachtwoordOud.Text);
                            if ("0".Equals(response))
                            {
                                await PopupNavigation.Instance.PopAsync();
                            }
                            else if ("1".Equals(response))
                            {
                                await DisplayAlert("Mislukt!", "Uw oude wachtwoord is niet juist.", "Ok");
                            }
                            else
                            {
                                await DisplayAlert("Mislukt!", "Er is iets fout gegaan, probeer het nog eens.", "Ok");
                            }
                        });
                        await Navigation.RemovePopupPageAsync(scherm);
                        await DisplayAlert("Gelukt!", "Je wachtwoord is gewijzigd.", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Mislukt!", "Uw nieuwe wachtwoorden komen niet overeen.", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Mislukt!", "Niet alle velden zijn ingevuld.", "Ok");
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