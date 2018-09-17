using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ljoy.popups
{
    public class laadscherm : PopupPage
    {
        public laadscherm()
        {
            ActivityIndicator laden = new ActivityIndicator { IsRunning = true, VerticalOptions = LayoutOptions.Center, IsVisible = true};

            Content = laden;

        }
    }
}