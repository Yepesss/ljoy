using System;

using Xamarin.Forms;

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
        DatePicker geboortedatum;
        Picker lesdag;
        TimePicker lesuur;
        Button btn1;
        Button btn2;


        public Inschrijf()
        {

            voornaam = new Entry();
            voornaam.HorizontalTextAlignment = TextAlignment.Center;
            voornaam.Placeholder = "Voornaam";

            achternaam = new Entry();
            achternaam.HorizontalTextAlignment = TextAlignment.Center;
            achternaam.Placeholder = "Achternaam";

            straatnaam = new Entry();
            straatnaam.HorizontalTextAlignment = TextAlignment.Center;
            straatnaam.Placeholder = "Straatnaam";

            huisnummer = new Entry();
            huisnummer.HorizontalTextAlignment = TextAlignment.Center;
            huisnummer.Keyboard = Keyboard.Numeric;
            huisnummer.Placeholder = "Huisnummer";

            postcode = new Entry();
            postcode.HorizontalTextAlignment = TextAlignment.Center;
            postcode.Placeholder = "Postcode";

            woonplaats = new Entry();
            woonplaats.HorizontalTextAlignment = TextAlignment.Center;
            woonplaats.Placeholder = "Woonplaats";

            telefoonnummer = new Entry();
            telefoonnummer.HorizontalTextAlignment = TextAlignment.Center;
            telefoonnummer.Placeholder = "Telefoonnummer (optioneel)";

            emailadres = new Entry();
            emailadres.HorizontalTextAlignment = TextAlignment.Center;
            emailadres.Placeholder = "Emailadres";

            geboortedatum = new DatePicker();
            geboortedatum.Format = "D";
            geboortedatum.HorizontalOptions = LayoutOptions.CenterAndExpand;

            lesdag = new Picker();
            lesdag.HorizontalOptions = LayoutOptions.Center;
            lesdag.Title = "Lesdag";
            lesdag.Items.Add("Maandag");
            lesdag.Items.Add("Dinsdag");
            lesdag.Items.Add("Woensdag");
            lesdag.Items.Add("Donderdag");
            lesdag.Items.Add("Vrijdag");
            lesdag.Items.Add("Zaterdag");
            lesdag.Items.Add("Zondag");

            lesuur = new TimePicker();
            lesuur.HorizontalOptions = LayoutOptions.Center;

            btn1 = new Button();
            btn1.Text = "Schrijf in!";
            btn1.HorizontalOptions = LayoutOptions.Center;

            btn2 = new Button();
            btn2.Text = "Meld je aan voor een gratis proefles!";
            btn2.HorizontalOptions = LayoutOptions.Center;

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                    voornaam,
                    achternaam,
                    straatnaam,
                    huisnummer,
                    postcode,
                    woonplaats,
                    telefoonnummer,
                    emailadres,
                    geboortedatum,
                    lesdag,
                    lesuur,
                    btn1,
                    btn2
                    }
                }
            };
        }
    }
}

