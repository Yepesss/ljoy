using ljoy.entiteiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ljoy.paginas
{
	public class NieuwsInformatie : ContentPage
	{
        public NieuwsInformatie (NieuwsEntiteit nieuws)
		{
            Title = nieuws.titel;
            Content = new ScrollView { Content = new StackLayout {
                Margin = new Thickness(10, 10, 10, 10),
                Children = {
                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), BorderColor= Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = nieuws.tekst, TextColor = Color.White, FontSize = 14 },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Label { Text = nieuws.datum, TextColor = Color.White, FontSize = 14, FontAttributes = FontAttributes.Italic, HorizontalTextAlignment = TextAlignment.End},

                            }
                        }, HasShadow = true,
                    },
                }
            } }; 
		}
	}
}