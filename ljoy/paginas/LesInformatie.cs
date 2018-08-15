using ljoy.entiteiten;
using System;
using Rg.Plugins.Popup.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ljoy.paginas
{
	public class LesInformatie : ContentPage
	{
        //inschrijfbaar 0 = niet inschrijfbaar
        //inschrijfbaar 1 = wel inschrijfbaar
        //ingeschreven 0 = niet ingeschreven
        //ingeschreven 1 = wel ingeschreven
        //ingelogd 0 = niet ingelogd
        //ingelogd 1 = wel ingelogd
		public LesInformatie (Les les)
		{
            Title = les.naam;

            string wanneer = les.dag + " om " + les.tijdstip;
            wanneer.Substring(0, 1).ToUpper();
            char[] letters = wanneer.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            wanneer = new string(letters);
            int ingeschreven = 1;
            int ingelogd = 1;
            Button afmeld_knop = afmeld_knop = new Button { Text = "Meld af", HorizontalOptions = LayoutOptions.FillAndExpand, FontAttributes = FontAttributes.Bold, FontSize = 14, BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White };
            Button inschrijf_knop = new Button();

            afmeld_knop.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushPopupAsync(new popups.afmelden(les));
            };

            ScrollView scrollView_niet_ingelogd = new ScrollView
            {
                Margin = new Thickness(10, 10, 10, 10),

                Content = new StackLayout
                {
                    Children = {
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wat?", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = les.omschrijving, TextColor = Color.White, FontSize = 14 },
                            }
                        }, HasShadow = true,
                        },
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wanneer?", HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = wanneer, TextColor = Color.White, FontSize = 14,  HorizontalTextAlignment = TextAlignment.Center },
                            }
                        }, HasShadow = true,
                        },
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wie?", HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = les.docent, TextColor = Color.White, FontSize = 14,  HorizontalTextAlignment = TextAlignment.Center },
                            }
                        }, HasShadow = true,
                        },
                        new Label { Text = "", HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 6},
                        new BoxView() { Color = Color.Black, HeightRequest = 1  },
                        new Label { Text = "Log in om in te schrijven.\nGeen account? Neem hiervoor contact op via de contact pagina.", HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 14},

                    }
                }
            };

            ScrollView scrollView_niet_ingeschreven = new ScrollView
            {
                Margin = new Thickness(10, 10, 10, 10),

                Content = new StackLayout
                {
                    Children = {
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wat?", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = les.omschrijving, TextColor = Color.White, FontSize = 14 },
                            }
                        }, HasShadow = true,
                        },
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wanneer?", HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = wanneer, TextColor = Color.White, FontSize = 14,  HorizontalTextAlignment = TextAlignment.Center },
                            }
                        }, HasShadow = true,
                        },
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wie?", HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = les.docent, TextColor = Color.White, FontSize = 14,  HorizontalTextAlignment = TextAlignment.Center },
                            }
                        }, HasShadow = true,
                        },
                        new Label { Text = "", HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 6},
                        new BoxView() { Color = Color.Black, HeightRequest = 1  },
                        new Label { Text = "Benieuwd naar deze les?", HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 14},
                        new Button { Text = "Schrijf u in voor een proefles", HorizontalOptions = LayoutOptions.FillAndExpand, FontAttributes = FontAttributes.Bold, FontSize = 14, BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White},
                        new Label { Text = "Wilt u zich inschrijven?", HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 14},
                        new Button { Text = "Schrijf u in voor deze les", HorizontalOptions = LayoutOptions.FillAndExpand, FontAttributes = FontAttributes.Bold, FontSize = 14, BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White}

                    }
                }
            };

            ScrollView scrollView_niet_inschrijfbaar = new ScrollView
            {
                Margin = new Thickness(10, 10, 10, 10),

                Content = new StackLayout
                {
                    Children = {
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wat?", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = les.omschrijving, TextColor = Color.White, FontSize = 14 },
                            }
                        }, HasShadow = true,
                        },
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wanneer?", HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = wanneer, TextColor = Color.White, FontSize = 14,  HorizontalTextAlignment = TextAlignment.Center },
                            }
                        }, HasShadow = true,
                        },
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wie?", HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = les.docent, TextColor = Color.White, FontSize = 14,  HorizontalTextAlignment = TextAlignment.Center },
                            }
                        }, HasShadow = true,
                        },
                        new Label { Text = "", HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 6},
                        new BoxView() { Color = Color.Black, HeightRequest = 1  },
                        new Label { Text = "U kunt zich voor deze les niet inschrijven via deze app.\nNeem hiervoor contact op via de contact pagina.", HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 14},
                    }
                }
            };

            ScrollView scrollView_wel_ingeschreven = new ScrollView
            {
                Margin = new Thickness(10, 10, 10, 10),

                Content = new StackLayout
                {
                    Children = {
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wat?", BackgroundColor = Color.FromHex("#FF4081"), HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = les.omschrijving, TextColor = Color.White, FontSize = 14 },
                            }
                        }, HasShadow = true,
                        },
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wanneer?", BackgroundColor = Color.FromHex("#FF4081"), HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = wanneer, TextColor = Color.White, FontSize = 14,  HorizontalTextAlignment = TextAlignment.Center },
                            }
                        }, HasShadow = true,
                        },
                        new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Wie?", BackgroundColor = Color.FromHex("#FF4081"), HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = les.docent, TextColor = Color.White, FontSize = 14,  HorizontalTextAlignment = TextAlignment.Center },
                            }
                        }, HasShadow = true,
                        },
                        new Label { Text = "", HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 6},
                        new BoxView() { Color = Color.Black, HeightRequest = 1  },
                        new Label { Text = "Bent u verhinderd?", HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 14},
                        afmeld_knop
                    }
                }
            };
            if (les.inschrijfbaar == 0)
            {
                Content = scrollView_niet_inschrijfbaar;
            }
            else if (ingelogd == 0)
            {
                Content = scrollView_niet_ingelogd;
            }
            else if (ingeschreven == 0)
            {
                Content = scrollView_niet_ingeschreven;
            }
            else
            {
                Content = scrollView_wel_ingeschreven;
            }
		}
	}
}