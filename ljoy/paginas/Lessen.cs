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
            lstView.SeparatorColor = Color.Black;

            switch (Device.RuntimePlatform){
                case Device.iOS:
                lstView.RowHeight = 110;
                break;
                case Device.Android:
                lstView.RowHeight = 40;
                break;
            }

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

            lstView.SeparatorColor = Color.FromHex("#FF4081");

            lstView.ItemTapped += async (o, e) => {
                var myList = (ListView)o;
                var les = (myList.SelectedItem as Les);
                await Navigation.PushAsync(new paginas.LesInformatie(les));
                myList.SelectedItem = null; // de-select the row
            };

            lstView.ItemTemplate = new DataTemplate(() =>
            {
                Label naamLabel = new Label();
                naamLabel.TextColor = Color.Black;
                naamLabel.SetBinding(Label.TextProperty, "naam");
                naamLabel.FontSize = 16;
                naamLabel.FontAttributes = FontAttributes.Bold;
                naamLabel.VerticalOptions = LayoutOptions.Center;

                Label docentLabel = new Label();
                docentLabel.TextColor = Color.Gray;
                docentLabel.SetBinding(Label.TextProperty, "docent");
                docentLabel.FontSize = 12;
                docentLabel.FontAttributes = FontAttributes.Bold;
                docentLabel.VerticalOptions = LayoutOptions.Center;

                Label omschrijvingLabel = new Label();
                omschrijvingLabel.TextColor = Color.Gray;
                omschrijvingLabel.SetBinding(Label.TextProperty, "omschrijving");
                omschrijvingLabel.LineBreakMode = LineBreakMode.TailTruncation;
                omschrijvingLabel.FontSize = 12;
                omschrijvingLabel.FontAttributes = FontAttributes.Italic;
                omschrijvingLabel.VerticalOptions = LayoutOptions.Center;

                Label tijdLabel = new Label();
                tijdLabel.TextColor = Color.Black;
                tijdLabel.SetBinding(Label.TextProperty, "tijdstip");
                tijdLabel.FontSize = 20;
                tijdLabel.FontAttributes = FontAttributes.Bold;
                tijdLabel.VerticalOptions = LayoutOptions.Center;
                tijdLabel.HorizontalOptions = LayoutOptions.End;

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
                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(275) });
                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                viewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });



                viewGrid.Children.Add(naamLabel, 1, 1);
                viewGrid.Children.Add(docentLabel, 1, 2);
                viewGrid.Children.Add(omschrijvingLabel, 1, 3);
                viewGrid.Children.Add(tijdLabel, 1, 1);
                viewGrid.Children.Add(image, 2, 2);

                Grid.SetRowSpan(tijdLabel, 3);



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