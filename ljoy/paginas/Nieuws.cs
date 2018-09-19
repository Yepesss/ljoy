using System;
using System.Collections.Generic;
using ljoy.entiteiten;
using Xamarin.Forms;

namespace ljoy.paginas
{
    public class Nieuws : ContentPage
    {
        ListView nieuwsListView = new ListView();
        List<NieuwsEntiteit> result;
        List<NieuwsEntiteit> nieuws = new List<NieuwsEntiteit>();

        public Nieuws()
        {
            result = getNieuws();

            foreach (NieuwsEntiteit nieuwsEntiteit in result){
                nieuws.Add(nieuwsEntiteit);
            }

            nieuwsListView.ItemsSource = nieuws;
            nieuwsListView.SeparatorColor = Color.FromHex("#FF4081");

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    nieuwsListView.RowHeight = 110;
                    break;
                case Device.Android:
                    nieuwsListView.RowHeight = 40;
                    break;
            }
            nieuwsListView.HasUnevenRows = true;


            nieuwsListView.ItemTapped += async (o, e) => {
                var myList = (ListView)o;
                var nieuwsSelectedItem = (myList.SelectedItem as NieuwsEntiteit);
                await Navigation.PushAsync(new NieuwsInformatie(nieuwsSelectedItem));
                myList.SelectedItem = null; // de-select the row
            };

            nieuwsListView.ItemTemplate = new DataTemplate(() =>
            {
                Label titelLabel = new Label();
                titelLabel.TextColor = Color.Black;
                titelLabel.SetBinding(Label.TextProperty, "titel");
                titelLabel.FontSize = 16;
                titelLabel.FontAttributes = FontAttributes.Bold;
                titelLabel.VerticalOptions = LayoutOptions.Center;

                Label tekstLabel = new Label();
                tekstLabel.TextColor = Color.Gray;
                tekstLabel.SetBinding(Label.TextProperty, "tekst");
                tekstLabel.LineBreakMode = LineBreakMode.TailTruncation;
                tekstLabel.FontSize = 12;
                tekstLabel.FontAttributes = FontAttributes.Bold;
                tekstLabel.VerticalOptions = LayoutOptions.Center;

                Label datumLabel = new Label();
                datumLabel.TextColor = Color.Gray;
                datumLabel.SetBinding(Label.TextProperty, "datum");
                datumLabel.FontSize = 12;
                datumLabel.FontAttributes = FontAttributes.Italic;
                datumLabel.VerticalOptions = LayoutOptions.Center;

                Label leesVerderLabel = new Label();
                leesVerderLabel.TextColor = Color.Black;
                leesVerderLabel.Text = "Lees verder";
                leesVerderLabel.FontSize = 14;
                leesVerderLabel.FontAttributes = FontAttributes.Bold;
                leesVerderLabel.VerticalOptions = LayoutOptions.Center;
                leesVerderLabel.HorizontalOptions = LayoutOptions.End;

                Image image = new Image();
                image.Source = "right_arrow.png";
                image.VerticalOptions = LayoutOptions.Center;
                image.HorizontalOptions = LayoutOptions.Center;



                Grid viewGrid = new Grid();
                viewGrid.VerticalOptions = LayoutOptions.CenterAndExpand;
                viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10) });
                viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
                viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
                viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
                viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10) });


                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(175) });
                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });



                viewGrid.Children.Add(titelLabel, 1, 1);
                viewGrid.Children.Add(tekstLabel, 1, 2);
                viewGrid.Children.Add(datumLabel, 1, 3);
                viewGrid.Children.Add(leesVerderLabel, 1, 1);
                viewGrid.Children.Add(image, 3, 2);

                Grid.SetRowSpan(leesVerderLabel, 3);
                Grid.SetColumnSpan(titelLabel, 2);
                Grid.SetColumnSpan(leesVerderLabel, 2);





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
            });

            Content = nieuwsListView;
        }

        private List<NieuwsEntiteit> getNieuws(){
            RestService con = new RestService();
            return con.VerkrijgNieuws().Result;
        }
            
    }
}

