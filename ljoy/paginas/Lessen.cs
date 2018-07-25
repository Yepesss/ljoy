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


        class Person
        {
            public Person(string name, DateTime birthday, Color favoriteColor)
            {
                this.Name = name;
                this.Birthday = birthday;
                this.FavoriteColor = favoriteColor;
            }

            public string Name { private set; get; }

            public DateTime Birthday { private set; get; }

            public Color FavoriteColor { private set; get; }
        };

        public Lessen ()
		{

            //LISTVIEW DATA
            Label header = new Label
            {
                Text = "ListView",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            // Define some data.
            List<Person> people = new List<Person>
            {
                new Person("Abigail", new DateTime(1975, 1, 15), Color.Aqua),
                new Person("Bob", new DateTime(1976, 2, 20), Color.Black),
                // ...etc.,...
                new Person("Yvonne", new DateTime(1987, 1, 10), Color.Purple),
                new Person("Zachary", new DateTime(1988, 2, 5), Color.Red)
            };

            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = people,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");

                    Label birthdayLabel = new Label();
                    birthdayLabel.SetBinding(Label.TextProperty,
                        new Binding("Birthday", BindingMode.OneWay,
                            null, null, "Born {0:d}"));

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                        }
                                }
                        }
                    };
                })
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