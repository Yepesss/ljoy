using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ljoy.popups
{
	public class algemenevoorwaarden : PopupPage
	{
		public algemenevoorwaarden ()
		{

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
                                new Label { Text = "Algemene voorwaarden", TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center, FontSize = 20},
                                new BoxView() { Color = Color.Black, HeightRequest = 1  },
                                new ScrollView
                                {
                                    Content = new StackLayout
                                    {
                                        Children =
                                        {
                                            new Label { Text = "Lidmaatschap", TextColor = Color.Black, FontSize = 15, FontAttributes = FontAttributes.Bold },
                                            new Label { Text = "Het lidmaatschap bestaat uit 4 kwartalen per dansseizoen. In de (basis)schoolvakanties zijn er geen reguliere lessen, deze zijn in het lesgeld verrekend. Het lesgeld wordt betaald via automatisch incasso, per kwartaal vooraf of per factuur. De contributie wordt jaarlijks bepaald en in 4 termijnen geïncasseerd. In uitzonderlijke gevallen is een gedeelte restitutie mogelijk. De beslissing hierover word door L-Joy Dancefactory genomen." + "\r\n" + "\r\n" +
                                            "Wil je niet meer deelnemen aan de lessen, dan kun je per kwartaal opzeggen. Opzeggen dient schriftelijk, of per email te worden gedaan. Voor leerlingen die meer dan 1 lesuur volgen, geldt een korting van 10% over de totale lessen. Een proefles en het 4e lesuur zijn gratis.", TextColor = Color.Black, FontSize = 12 },
                                            new Label { Text = "Huisregels", TextColor = Color.Black, FontSize = 15, FontAttributes = FontAttributes.Bold },
                                            new Label { Text =  "• De leerling word op tijd in de les verwacht." + "\r\n" + "\r\n" +
                                                                "• Hygiëne is belangrijk. Zorg voor een handdoek tijdens de sporturen."  + "\r\n" + "\r\n" +
                                                                "• Geen schoenen die buiten zijn gedragen in de zaal. Zand slijt de dansvloer en er lopen veel leerlingen op blote voeten." + "\r\n" + "\r\n" +
                                                                "• Verzuimde lessen kunnen altijd worden ingehaald binnen 3 maanden." + "\r\n" + "\r\n" +
                                                                "• Het is niet toegestaan om te filmen of fotograferen tijdens de lessen" + "\r\n" + "\r\n" +
                                                                "• Je bent verplicht om passende sportkleding te dragen." + "\r\n" + "\r\n" +
                                                                "• Mobiele telefoon op stil en deze kun je bij de docent in de kast leggen of op de vensterbank." + "\r\n" + "\r\n" +
                                                                "• Roken is binnen en bij de ingang van L-Joy dancefactory niet toegestaan" + "\r\n" + "\r\n" +
                                                                "• Er mogen geen meegebrachte consumpties worden genuttigd m.u.v. water of in overleg met de docent." + "\r\n" + "\r\n" +
                                                                "• Bij L-Joy dancefactory dient een ieder zich respectvol te gedragen.", TextColor = Color.Black, FontSize = 12 },
                                            new Label { Text = "Aansprakelijkheid", TextColor = Color.Black, FontSize = 15, FontAttributes = FontAttributes.Bold },
                                            new Label { Text = "Wij zijn niet aansprakelijk voor persoonlijke ongevallen, opgelopen verwondingen of ander lichamelijk letsel. Tevens ook niet voor diefstal en schade aan goederen van leerlingen en bezoekers (uit de kleedkamer) en het dansen en/of sporten geschiedt op eigen risico. Laat geen sleutels, geld, etc. in de kleedkamer achter, maar neem deze mee in de zaal. ", TextColor = Color.Black, FontSize = 12 },
                                            new Label { Text = "Privacy", TextColor = Color.Black, FontSize = 15, FontAttributes = FontAttributes.Bold },
                                            new Label { Text = "Wij gebruiken uw persoonsgegevens alleen voor eigen gebruik en onze administratie, gaan geen overeenkomsten aan met derden. Tevens worden uw persoonsgegevens nooit vrijgegeven aan derden zonder uw toestemming." + "\r\n" + "\r\n" +
                                            "Op het inschrijfformulier kunt u toestemming geven voor het ontvangen van de nieuws brief en voor het maken van foto- en filmmateriaal voor diverse doeleinden.", TextColor = Color.Black, FontSize = 12 },


                                        }
                                    }
                                },
                                terugknop
                            }
                        }
                    }
				}
			};
		}
	}
}