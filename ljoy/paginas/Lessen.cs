using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ljoy.entiteiten;

using Xamarin.Forms;

namespace ljoy.paginas
{
	public class Lessen : ContentPage
	{
        List<Les> lessen = new List<Les>();
        ListView lessen_listView = new ListView();
        private ObservableCollection<groupedLes> grouped { get; set; }

        public Lessen()
        {
            //LISTVIEW DATA

            RestService con = new RestService();
            List<Les> result = new List<Les>();
            try
            {
                result = con.VerkrijgLessen().Result;
            }
            catch (AggregateException er)
            {
                DisplayAlert("Gelukt!", er.ToString(), "Ok");
            }
            foreach (Les les in result)
            {
                lessen.Add(les);
            }

            var lstView = new ListView();
            grouped = new ObservableCollection<groupedLes>();
            var maandagGroup = new groupedLes { dag = "Maandag" };
            var dinsdagGroup = new groupedLes { dag = "Dinsdag" };
            var woensdagGroup = new groupedLes { dag = "Woensdag" };
            var donderdagGroup = new groupedLes { dag = "Donderdag" };
            var vrijdagGroup = new groupedLes { dag = "Vrijdag" };
            var zaterdagGroup = new groupedLes { dag = "Zaterdag" };

            foreach(Les les in lessen)
            {
                if(les.dag.Equals("maandag"))
                {
                    maandagGroup.Add(les);
                }
                if (les.dag.Equals("dinsdag"))
                {
                    dinsdagGroup.Add(les);
                }
                if (les.dag.Equals("woensdag"))
                {
                    woensdagGroup.Add(les);
                }
                if (les.dag.Equals("donderdag"))
                {
                    donderdagGroup.Add(les);
                }
                if (les.dag.Equals("vrijdag"))
                {
                    vrijdagGroup.Add(les);
                }
                if (les.dag.Equals("zaterdag"))
                {
                    zaterdagGroup.Add(les);
                }
            }

            grouped.Add(maandagGroup);
            grouped.Add(dinsdagGroup);
            grouped.Add(woensdagGroup);
            grouped.Add(donderdagGroup);
            grouped.Add(vrijdagGroup);
            grouped.Add(zaterdagGroup);


            lstView.ItemsSource = grouped;
            lstView.RowHeight = 40;
            lstView.HasUnevenRows = true;
            lstView.IsGroupingEnabled = true;
            lstView.GroupDisplayBinding = new Binding("dag");
            lstView.GroupHeaderTemplate = new DataTemplate(() =>
            {
                Label label = new Label();
                label.SetBinding(Label.TextProperty, "dag");
                label.HorizontalOptions = LayoutOptions.Center;
                label.VerticalOptions = LayoutOptions.CenterAndExpand;
                label.FontSize = 20;
                label.FontAttributes = FontAttributes.Bold;
                label.TextColor = Color.White;
                return new ViewCell
                {
                    Height = 40,
                    View = new StackLayout
                    {
                        BackgroundColor = Color.FromHex("#FF4081"),
                        Children =
                                {
                                    label
                                }
                    }
                };
            });

            lstView.ItemTemplate = new DataTemplate(() =>
            {
                Label naamLabel = new Label();
                naamLabel.SetBinding(Label.TextProperty, "naam");
                naamLabel.FontSize = 20;
                naamLabel.FontAttributes = FontAttributes.Bold;
                naamLabel.VerticalOptions = LayoutOptions.Center;

                Label tijdLabel = new Label();
                tijdLabel.SetBinding(Label.TextProperty, "tijdstip");

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

            Content = lstView;

        }
    }

}