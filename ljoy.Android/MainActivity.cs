﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.FirebasePushNotification;

namespace ljoy.Droid
{
    [Activity(Label = "L-Joy", Icon = "@drawable/Icon180", Theme = "@style/splashscreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.Window.RequestFeature(WindowFeatures.ActionBar);
            // Name of the MainActivity theme you had there before.
            // Or you can use global::Android.Resource.Style.ThemeHoloLight
            base.SetTheme(Resource.Style.MainTheme);
            base.OnCreate(bundle);
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            if (CheckSelfPermission("android.permission.INTERNET") == Permission.Granted)
            {

            }
            else
            {
                RequestPermissions(new String[] { "android.permission.INTERNET" }, 0);
            }
            if (CheckSelfPermission("android.permission.ACCESS_FINE_LOCATION") == Permission.Granted)
            {

            }
            else
            {
                RequestPermissions(new String[] { "android.permission.ACCESS_FINE_LOCATION" }, 0);
            }
            global::Xamarin.Forms.Forms.Init(this, bundle);

            Firebase.FirebaseApp.InitializeApp(this);
            FirebasePushNotificationManager.ProcessIntent(this, Intent);

            LoadApplication(new App());

        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                // Do something if there are some pages in the `PopupStack`
            }
            else
            {
                // Do something if there are not any pages in the `PopupStack`
            }
        }
    }
}

