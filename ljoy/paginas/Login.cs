using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ljoy.paginas
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        XAlign = TextAlignment.Center,
                        Text = "Welcome to Xamarin Forms!"
                    }
                }
            };
        }
    }
}
