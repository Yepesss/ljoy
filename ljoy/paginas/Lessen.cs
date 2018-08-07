using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ljoy.paginas
{
	public class Lessen : ContentPage
	{

        Button inschrijven;
        Button proefles;


        public class Les
        {
            public Les(ImageSource afbeelding, string naam, string tijd, string omschrijving, string docent)
            {
                this.Afbeelding = afbeelding;
                this.Naam = naam;
                this.Tijd = tijd;
                this.Omschrijving = omschrijving;
                this.Docent = docent;
            }

            public ImageSource Afbeelding { private set; get; }

            public string Naam { private set; get; }

            public string Tijd { private set; get; }

            public string Omschrijving { private set; get; }

            public string Docent { private set; get; }

        };

        public Lessen ()
		{

            //LISTVIEW DATA

            // Define some data.
            List<Les> lessen = new List<Les>
            {
                new Les("test.png", "Future Rebels", "Dinsdag: 17.30", "Hier komt de omschrijving van de les 'Future Rebels' te staan", "Hier komt de docent van de les 'Future Rebels' te staan"),
                new Les("test.png", "Selectie 1", "Dinsdag: 20.30", "Hier komt de omschrijving van de les 'Selectie 1' te staan", "Hier komt de docent van de les 'Selectie 1' te staan")

            };

            // Create the ListView.
            ListView listView = new ListView
            {

                
                SeparatorColor = Color.FromHex("#FF4081"),
                
                RowHeight = 100,
                // Source of data items.
                ItemsSource = lessen,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {

                    // Create views with bindings for displaying each property.
                    Label naamLabel = new Label();
                    naamLabel.SetBinding(Label.TextProperty, "Naam");
                    naamLabel.FontSize = 20;
                    naamLabel.FontAttributes = FontAttributes.Bold;
                    naamLabel.VerticalOptions = LayoutOptions.Center;

                    Label tijdLabel = new Label();
                    tijdLabel.SetBinding(Label.TextProperty, "Tijd");


                    Image afbeelding = new Image();
                    afbeelding.VerticalOptions = LayoutOptions.FillAndExpand;
                    afbeelding.HorizontalOptions = LayoutOptions.FillAndExpand;

                    afbeelding.SetBinding(Image.SourceProperty, "Afbeelding");

                    Grid viewGrid = new Grid();

                    viewGrid.VerticalOptions = LayoutOptions.FillAndExpand;

                    viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(70) });

                    viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                    viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    viewGrid.Children.Add(afbeelding, 0, 0);
                    viewGrid.Children.Add(naamLabel, 1, 0);
                    viewGrid.Children.Add(tijdLabel, 1, 1);

                    Grid.SetRowSpan(afbeelding, 2);






                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Children =
                                {
                                    viewGrid
                                }
                        }
                    };
                })
            };

            listView.ItemSelected += async (sender, e) =>
            {
                var item = (Les)e.SelectedItem;

                if (item == null)
                {
                }
                else
                {
                    await Navigation.PushAsync(new LesInformatie(item));
                }

                listView.SelectedItem = null;
            };



            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            //-LISTVIEW DATA

            inschrijven = new Button();
            inschrijven.BackgroundColor = Color.FromHex("#FF4081");
            inschrijven.Text = "Schrijf je in voor een les!";
            inschrijven.TextColor = Color.White;

            proefles = new Button();
            proefles.BackgroundColor = Color.FromHex("#FF4081");
            proefles.Text = "Gratis proefles!";
            proefles.TextColor = Color.White;


            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
            grid.VerticalOptions = LayoutOptions.FillAndExpand;

            StackLayout hoofdWeergave = new StackLayout();

            StackLayout lesWeergave = new StackLayout();
            lesWeergave.Children.Add(listView);
            StackLayout inschrijfWeergave = new StackLayout();
            inschrijfWeergave.BackgroundColor = Color.Gray;

            Grid inschrijfGrid = new Grid();
            inschrijfGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
            inschrijfGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            inschrijfGrid.Children.Add(inschrijven, 0, 0);
            inschrijfWeergave.Children.Add(inschrijfGrid);


            ScrollView lesWeergaveScrollView = new ScrollView();

            lesWeergaveScrollView.Content = lesWeergave;

            grid.Children.Add(lesWeergaveScrollView, 0, 0);
            grid.Children.Add(inschrijfWeergave, 0, 1);

            hoofdWeergave.Children.Add(grid);

            Content = hoofdWeergave;
        }
    }

}