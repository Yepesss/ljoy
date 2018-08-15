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
            ActivityIndicator laden = new ActivityIndicator { IsVisible = true, IsRunning = true, VerticalOptions = LayoutOptions.Center};

            Content = laden;

        }
    }
}