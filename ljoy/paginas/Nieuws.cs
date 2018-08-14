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
            nieuwsListView.RowHeight = 40;

            nieuwsListView.ItemTapped += async (o, e) => {
                var myList = (ListView)o;
                var nieuwsSelectedItem = (myList.SelectedItem as NieuwsEntiteit);
                await Navigation.PushAsync(new paginas.NieuwsInformatie(nieuwsSelectedItem));
                myList.SelectedItem = null; // de-select the row
            };

            nieuwsListView.ItemTemplate = new DataTemplate(() =>
            {
                Label naamLabel = new Label();
                naamLabel.SetBinding(Label.TextProperty, "titel");
                naamLabel.FontSize = 20;
                naamLabel.FontAttributes = FontAttributes.Bold;
                naamLabel.VerticalOptions = LayoutOptions.Center;

                Label tijdLabel = new Label();
                tijdLabel.SetBinding(Label.TextProperty, "datum");

                Grid viewGrid = new Grid();
                viewGrid.VerticalOptions = LayoutOptions.FillAndExpand;
                viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                viewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                viewGrid.Children.Add(naamLabel, 0, 0);
                viewGrid.Children.Add(tijdLabel, 0, 1);



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

