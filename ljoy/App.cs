using Plugin.FirebasePushNotification;
using System;
using Xamarin.Forms;

namespace ljoy
{
    public partial class App : Application
    {
        public App()
        {

            CrossFirebasePushNotification.Current.Subscribe("nieuws");

            if (helper.Settings.UsernameSettings != null && !"".Equals(helper.Settings.UsernameSettings)) {
                MainPage = new applicatie.ApplicatieStarter();
            } else {
                MainPage = new NavigationPage(new paginas.Login());
            }

            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
            };

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Received");
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }
            };
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
