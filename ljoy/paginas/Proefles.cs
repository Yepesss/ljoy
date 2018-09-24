using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ljoy.paginas
{
    public class Proefles : ContentPage
    {

        Entry voornaam;
        Entry achternaam;
        Entry straatnaam;
        Entry huisnummer;
        Entry postcode;
        Entry woonplaats;
        Entry telefoonnummer;
        Entry emailadres;
        Label geboortedatum;
        Entry geboortedatum_dag;
        Entry geboortedatum_maand;
        Entry geboortedatum_jaar;
        Button btn1;


        public Proefles(entiteiten.Les les)
        {
            Title = les.naam;

            voornaam = new Entry();
            voornaam.HorizontalTextAlignment = TextAlignment.Start;
            voornaam.PlaceholderColor = Color.Gray;
            voornaam.TextColor = Color.Black;
            voornaam.Placeholder = "Voornaam";

            achternaam = new Entry();
            achternaam.HorizontalTextAlignment = TextAlignment.Start;
            achternaam.PlaceholderColor = Color.Gray;
            achternaam.TextColor = Color.Black;
            achternaam.Placeholder = "Achternaam";

            straatnaam = new Entry();
            straatnaam.HorizontalTextAlignment = TextAlignment.Start;
            straatnaam.PlaceholderColor = Color.Gray;
            straatnaam.TextColor = Color.Black;
            straatnaam.Placeholder = "Straatnaam";

            huisnummer = new Entry();
            huisnummer.HorizontalTextAlignment = TextAlignment.Start;
            huisnummer.PlaceholderColor = Color.Gray;
            huisnummer.TextColor = Color.Black;
            huisnummer.Keyboard = Keyboard.Numeric;
            huisnummer.Placeholder = "Huisnr";

            geboortedatum_dag = new Entry();
            geboortedatum_dag.HorizontalTextAlignment = TextAlignment.Center;
            geboortedatum_dag.PlaceholderColor = Color.Gray;
            geboortedatum_dag.TextColor = Color.Black;
            geboortedatum_dag.Keyboard = Keyboard.Numeric;
            geboortedatum_dag.Placeholder = "DD";

            geboortedatum_maand = new Entry();
            geboortedatum_maand.HorizontalTextAlignment = TextAlignment.Center;
            geboortedatum_maand.PlaceholderColor = Color.Gray;
            geboortedatum_maand.TextColor = Color.Black;
            geboortedatum_maand.Keyboard = Keyboard.Numeric;
            geboortedatum_maand.Placeholder = "MM";

            geboortedatum_jaar = new Entry();
            geboortedatum_jaar.HorizontalTextAlignment = TextAlignment.Center;
            geboortedatum_jaar.PlaceholderColor = Color.Gray;
            geboortedatum_jaar.TextColor = Color.Black;
            geboortedatum_jaar.Keyboard = Keyboard.Numeric;
            geboortedatum_jaar.Placeholder = "JJJJ";




            postcode = new Entry();
            postcode.HorizontalTextAlignment = TextAlignment.Start;
            postcode.PlaceholderColor = Color.Gray;
            postcode.TextColor = Color.Black;
            postcode.Placeholder = "Postcode";

            woonplaats = new Entry();
            woonplaats.HorizontalTextAlignment = TextAlignment.Start;
            woonplaats.PlaceholderColor = Color.Gray;
            woonplaats.TextColor = Color.Black;
            woonplaats.Placeholder = "Woonplaats";

            telefoonnummer = new Entry();
            telefoonnummer.HorizontalTextAlignment = TextAlignment.Start;
            telefoonnummer.PlaceholderColor = Color.Gray;
            telefoonnummer.TextColor = Color.Black;
            telefoonnummer.Placeholder = "Telefoonnummer (optioneel)";

            emailadres = new Entry();
            emailadres.HorizontalTextAlignment = TextAlignment.Start;
            emailadres.PlaceholderColor = Color.Gray;
            emailadres.TextColor = Color.Black;
            emailadres.Placeholder = "Emailadres";

            geboortedatum = new Label();
            geboortedatum.Text = "Geboortedatum";
            geboortedatum.HorizontalOptions = LayoutOptions.Start;
            geboortedatum.TextColor = Color.Black;
            geboortedatum.VerticalOptions = LayoutOptions.Center;
            geboortedatum.TextColor = Color.Gray;
            geboortedatum.FontSize = 17.5;

            btn1 = new Button { Text = "Meld je aan", HorizontalOptions = LayoutOptions.FillAndExpand, FontAttributes = FontAttributes.Bold, FontSize = 14, BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White };
            btn1.Clicked += (object sender, EventArgs e) =>
            {
                if (voornaam.Text == null || achternaam.Text == null || straatnaam.Text == null || huisnummer.Text == null || geboortedatum_dag.Text == null || geboortedatum_maand.Text == null || geboortedatum_jaar.Text == null || postcode.Text == null || woonplaats.Text == null || telefoonnummer.Text == null ||emailadres.Text == null || "".Equals(voornaam.Text) || "".Equals(achternaam.Text) || "".Equals(straatnaam.Text) || "".Equals(huisnummer.Text) || "".Equals(geboortedatum_dag.Text) || "".Equals(geboortedatum_maand.Text) || "".Equals(geboortedatum_jaar.Text) || "".Equals(postcode.Text) || "".Equals(woonplaats.Text) || "".Equals(telefoonnummer.Text) || "".Equals(emailadres.Text))
                {
                    DisplayAlert("Oeps!", "Vul a.u.b. alle velden in.", "Oké");
                }
                else
                {
                    email.SendMail email = new email.SendMail();
                    //Email naar de gebruiker
                    email.EmailVerzenden("U heeft zich aangemeld voor een proefles!",
                                         "U heeft zich succesvol aangemeld voor een proefles " + les.naam + " op " + les.dag + "." + "\r\n" +
                                         "Wij verwachten u om " + les.tijdstip + " in de les." + "\r\n" + "\r\n" +
                                         "Met vriendelijke groet," + "\r\n" +
                                         "L-Joy Dancefactory",
                                         emailadres.Text, voornaam.Text);

                    //Email naar l-joy
                    email.EmailVerzenden("Aanmelding proefles",
                                         "Voornaam: " + voornaam.Text + "\r\n" +
                                         "Achternaam: " + achternaam.Text + "\r\n" +
                                         "Straatnaam: " + straatnaam.Text + "\r\n" +
                                         "Huisnummer: " + huisnummer.Text + "\r\n" +
                                         "Geboortedatum: " + geboortedatum_dag.Text + "-" + geboortedatum_maand.Text + "-" + geboortedatum_jaar.Text + "\r\n" +
                                         "Postcode: " + postcode.Text + "\r\n" +
                                         "Woonplaats: " + woonplaats.Text + "\r\n" +
                                         "Telefoonnummer: " + telefoonnummer.Text + "\r\n" +
                                         "Email: " + emailadres.Text + "\r\n" +
                                         "Les: " + les.naam + "\r\n" +
                                         "Dag: " + les.dag + "\r\n" +
                                         "Tijdstip: " + les.tijdstip + "\r\n" +
                                         "Docent: " + les.docent);
                }
            };

            Grid sGrid = new Grid();
            sGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(240) });
            sGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            sGrid.Children.Add(straatnaam, 0, 0);
            sGrid.Children.Add(huisnummer, 1, 0);

            Grid gGrid = new Grid();
            gGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150) });
            gGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            gGrid.Children.Add(geboortedatum, 0, 0);
            gGrid.Children.Add(geboortedatum_dag, 1, 0);
            gGrid.Children.Add(geboortedatum_maand, 2, 0);
            gGrid.Children.Add(geboortedatum_jaar, 3, 0);





            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(10, 10, 10, 10),
                    Children = {
                    new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Persoonlijke gegevens", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        voornaam
                                        }
                                    }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        achternaam
                                        }
                                    }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        sGrid
                                        }
                                    }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        postcode
                                        }
                                    }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        woonplaats
                                        }
                                    }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        telefoonnummer
                                        }
                                    }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        emailadres
                                        }
                                    }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        gGrid
                                        }
                                    }, HasShadow = true,
                                }
                            }
                        }, HasShadow = true,
                    },
                    btn1,
                    new Frame { Padding = 5 }

                    }
                }
            };
        }
    }
}

