using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ljoy.paginas
{
    public class Inschrijf : ContentPage
    {

        Entry voornaam;
        Entry achternaam;
        Entry straatnaam;
        Entry huisnummer;
        Entry postcode;
        Entry woonplaats;
        Entry telefoonnummer;
        Entry emailadres;
        Entry rekeningnummer;
        Entry rekeninghouder;
        Label geboortedatum;
        Entry geboortedatum_dag;
        Entry geboortedatum_maand;
        Entry geboortedatum_jaar;
        CheckBox machtiging;
        CheckBox algemenevoorwaarden;
        CheckBox nieuwsbrief;
        CheckBox fotofilmmateriaal;
        Button btn1;
        Button algemenevoorwaarden_link = new Button { Text = "Klik hier voor de algemene voorwaarden", BackgroundColor = Color.Transparent, TextColor = Color.Blue, FontAttributes = FontAttributes.Italic, HorizontalOptions = LayoutOptions.Center, FontSize = 12 };


        public Inschrijf(entiteiten.Les les)
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

            rekeningnummer = new Entry();
            rekeningnummer.HorizontalTextAlignment = TextAlignment.Start;
            rekeningnummer.PlaceholderColor = Color.Gray;
            rekeningnummer.TextColor = Color.Black;
            rekeningnummer.Placeholder = "Rekeningnummer (IBAN)";

            rekeninghouder = new Entry();
            rekeninghouder.HorizontalTextAlignment = TextAlignment.Start;
            rekeninghouder.PlaceholderColor = Color.Gray;
            rekeninghouder.TextColor = Color.Black;
            rekeninghouder.Placeholder = "Naam rekeninghouder";

            geboortedatum = new Label();
            geboortedatum.Text = "Geboortedatum";
            geboortedatum.HorizontalOptions = LayoutOptions.Start;
            geboortedatum.TextColor = Color.Black;
            geboortedatum.VerticalOptions = LayoutOptions.Center;
            geboortedatum.TextColor = Color.Gray;
            geboortedatum.FontSize = 17.5;

            controls.CheckBox machtiging_checkbox = new controls.CheckBox();
            machtiging_checkbox.IsChecked = false;
            machtiging_checkbox.CheckedBackgroundImageSource = "checkbox_background";
            machtiging_checkbox.CheckmarkImageSource = "checkbox_check";
            machtiging_checkbox.BorderImageSource = "checkbox_border";
            machtiging_checkbox.Title = "Hiermee machtig ik L-Joy Dancefactory om per kwartaal automatisch de contributie af te laten schrijven.";


            controls.CheckBox algemenevoorwaarden_checkbox = new controls.CheckBox();
            algemenevoorwaarden_checkbox.IsChecked = false;
            algemenevoorwaarden_checkbox.CheckedBackgroundImageSource = "checkbox_background";
            algemenevoorwaarden_checkbox.CheckmarkImageSource = "checkbox_check";
            algemenevoorwaarden_checkbox.BorderImageSource = "checkbox_border";
            algemenevoorwaarden_checkbox.Title = "Hiermee verklaar ik akkoord te gaan met de Algemene Voorwaarden van L-Joy dancefactory. *";

            controls.CheckBox nieuwsbrief_checkbox = new controls.CheckBox();
            nieuwsbrief_checkbox.IsChecked = false;
            nieuwsbrief_checkbox.CheckedBackgroundImageSource = "checkbox_background";
            nieuwsbrief_checkbox.CheckmarkImageSource = "checkbox_check";
            nieuwsbrief_checkbox.BorderImageSource = "checkbox_border";
            nieuwsbrief_checkbox.Title = "Ik wil de nieuwsbrief en info per email ontvangen.                                               ";

            controls.CheckBox fotofilmmateriaal_checkbox = new controls.CheckBox();
            fotofilmmateriaal_checkbox.IsChecked = false;
            fotofilmmateriaal_checkbox.CheckedBackgroundImageSource = "checkbox_background";
            fotofilmmateriaal_checkbox.CheckmarkImageSource = "checkbox_check";
            fotofilmmateriaal_checkbox.BorderImageSource = "checkbox_border";
            fotofilmmateriaal_checkbox.Title = "Ik geef toestemming voor het maken van foto en filmmateriaal.                              ";

            btn1 = new Button { Text = "Schrijf je in", HorizontalOptions = LayoutOptions.FillAndExpand, FontAttributes = FontAttributes.Bold, FontSize = 14, BackgroundColor = Color.FromHex("#FF4081"), TextColor = Color.White };
            btn1.Clicked += (object sender, EventArgs e) =>
            {
                if (voornaam.Text == null || achternaam.Text == null || straatnaam.Text == null || huisnummer.Text == null || geboortedatum_dag.Text == null || geboortedatum_maand.Text == null || geboortedatum_jaar.Text == null || postcode.Text == null || woonplaats.Text == null || telefoonnummer.Text == null ||emailadres.Text == null || rekeningnummer.Text == null || rekeninghouder.Text == null || "".Equals(voornaam.Text) || "".Equals(achternaam.Text) || "".Equals(straatnaam.Text) || "".Equals(huisnummer.Text) || "".Equals(geboortedatum_dag.Text) || "".Equals(geboortedatum_maand.Text) || "".Equals(geboortedatum_jaar.Text) || "".Equals(postcode.Text) || "".Equals(woonplaats.Text) || "".Equals(telefoonnummer.Text) || "".Equals(emailadres.Text) || "".Equals(rekeningnummer.Text) || "".Equals(rekeninghouder.Text))
                {
                    DisplayAlert("Oeps!", "Vul a.u.b. alle velden in.", "Oké");
                }
                else if (!algemenevoorwaarden_checkbox.IsChecked)
                {
                    DisplayAlert("Oeps!", "Om in te schrijven moet u akkoord gaan met de algemene voorwaarden.", "Oké");
                }
                else
                {
                    email.SendMail email = new email.SendMail();
                    //Email naar de gebruiker
                    email.EmailVerzenden("U heeft zich ingeschreven!", 
                                         "U heeft zich succesvol ingeschreven voor " + les.naam + " op " + les.dag + "." + "\r\n" +
                                         "Wij verwachten u om " + les.tijdstip + " in de les." + "\r\n" + "\r\n" +
                                         "Met vriendelijke groet," + "\r\n" +
                                         "L-Joy Dancefactory", 
                                         emailadres.Text, voornaam.Text);

                    //Email naar l-joy
                    email.EmailVerzenden("Inschrijving", 
                                         "Voornaam: " + voornaam.Text + "\r\n" +
                                         "Achternaam: " + achternaam.Text + "\r\n" +
                                         "Straatnaam: " + straatnaam.Text + "\r\n" +
                                         "Huisnummer: " + huisnummer.Text + "\r\n" +
                                         "Geboortedatum: " + geboortedatum_dag.Text + " - " + geboortedatum_maand.Text + " - " + geboortedatum_jaar + "\r\n" +
                                         "Postcode: " + postcode.Text + "\r\n" +
                                         "Woonplaats: " + woonplaats.Text + "\r\n" +
                                         "Telefoonnummer: " + telefoonnummer.Text + "\r\n" +
                                         "Email: " + emailadres.Text + "\r\n" +
                                         "Rekeningnummer: " + rekeningnummer.Text + "\r\n" +
                                         "Rekeninghouder: " + rekeninghouder.Text + "\r\n" +
                                         "Les: " + les.naam + "\r\n" +
                                         "Dag: " + les.dag + "\r\n" +
                                         "Tijdstip: " + les.tijdstip + "\r\n" +
                                         "Docent: " + les.docent);
                }
            };

            algemenevoorwaarden_link.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushPopupAsync(new popups.algemenevoorwaarden());
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
                    new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Bankgegevens", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        rekeningnummer
                                        }
                                    }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        rekeninghouder
                                        }
                                    }, HasShadow = true,
                                }
                            }
                        }, HasShadow = true,
                    },
                    new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.FromHex("#FF4081"), Content = new StackLayout{
                            Children = {
                                new Label { Text = "Toestemmingen", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White, FontSize = 18, FontAttributes = FontAttributes.Bold },
                                new BoxView() { Color = Color.White, HeightRequest = 1  },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children = {
                                        machtiging_checkbox
                                    }
                                }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        algemenevoorwaarden_checkbox
                                        }
                                    }, HasShadow = true,
                                },
                                new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        nieuwsbrief_checkbox
                                        }
                                    }, HasShadow = true,
                                },
                                    new Frame { Padding = 7.5, CornerRadius = 5, BackgroundColor = Color.White, Content = new StackLayout{
                                    Children =  {
                                        fotofilmmateriaal_checkbox
                                        }
                                    }, HasShadow = true,
                                },
                                new Label { Text = "* verplichte velden	", TextColor = Color.White}
                            }
                        }, HasShadow = true,
                    },
                    algemenevoorwaarden_link,
                    btn1,
                    new Frame { Padding = 3.75 }

                    }
                }
            };
        }
    }
}

