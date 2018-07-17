using System;

using Xamarin.Forms;

namespace ljoy.paginas
{
    public class Nieuws : ContentPage
    {
        public Nieuws()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

