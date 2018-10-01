using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ljoy.entiteiten;

namespace ljoy.paginas
{
    public class MijnAccount : ContentPage
    {
        public MijnAccount()
        {
            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            List<LesAccountPagina> ingeschrevenlessen = new List<LesAccountPagina>();
            RestService con = new RestService();
            ingeschrevenlessen = con.VerkrijgLessenAccountPagina().Result;

            List<Label> labelList = new List<Label>();

            foreach(LesAccountPagina ingeschrevenles in ingeschrevenlessen)
            {
                Label naamLabel = new Label();
                naamLabel.TextColor = Color.White;
                naamLabel.Text = ingeschrevenles.naam;
                naamLabel.FontSize = 15;
                naamLabel.FontAttributes = FontAttributes.Bold;
                naamLabel.VerticalOptions = LayoutOptions.Center;
                labelList.Add(naamLabel);
            }

            Grid grid = new Grid();

            for (int i = 0; i < labelList.Count; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                grid.Children.Add(labelList[i], 0, i);
            }


            Button veranderwachtwoord_knop = new Button();
            veranderwachtwoord_knop.Text = "Verander wachtwoord";
            veranderwachtwoord_knop.TextColor = Color.White;
            veranderwachtwoord_knop.BackgroundColor = Color.FromHex("#FF4081");
            veranderwachtwoord_knop.VerticalOptions = LayoutOptions.Center;
            veranderwachtwoord_knop.Clicked += async (object sender, EventArgs e) =>
            {
                popups.wachtwoordVeranderenAccountPagina wachtwoordVeranderen = new popups.wachtwoordVeranderenAccountPagina();
                await Navigation.PushPopupAsync(wachtwoordVeranderen);
            };

            Button uitlog_knop = new Button();
            uitlog_knop.Text = "Uitloggen";
            uitlog_knop.TextColor = Color.White;
            uitlog_knop.BackgroundColor = Color.FromHex("#FF4081");
            uitlog_knop.VerticalOptions = LayoutOptions.Center;
            uitlog_knop.Clicked += (object sender, EventArgs e) =>
            {
                helper.Settings.RemoveUserName();
                helper.Settings.RemoveId();
                Uitloggen();
            };

            if (ingeschrevenlessen.Count == 0)
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(10, 10, 10, 10),
                    Children = {
                    new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), VerticalOptions = LayoutOptions.Start, Content = new StackLayout{
                            Children = {
                                new Label { Text = "Je bent nergens voor ingeschreven", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 15, FontAttributes = FontAttributes.Bold },
                                grid
                            }
                        }, HasShadow = true,
                    },
                    veranderwachtwoord_knop,
                    uitlog_knop
                }
                };
            }
            else
            {
                Content = new ScrollView
                {
                    Content = new StackLayout
                    {
                        Margin = new Thickness(10, 10, 10, 10),
                        Children = {
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), VerticalOptions = LayoutOptions.Start, Content = new StackLayout{
                                Children = {
                                    new Label { Text = "Je bent ingeschreven voor de volgende lessen", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 15, FontAttributes = FontAttributes.Bold },
                                    new BoxView() { Color = Color.White, HeightRequest = 1  },
                                    grid
                                }
                            }, HasShadow = true,
                        },
                        veranderwachtwoord_knop,
                        uitlog_knop,
                        new Label { Text = "V1.6 - Negnod", HorizontalOptions = LayoutOptions.Center, FontSize = 10, TextColor = Color.LightGray}
                        }
                    }
                };
            }
        }

        private void Uitloggen(){
            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
}
