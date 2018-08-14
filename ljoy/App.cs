using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ljoy
{
    public partial class App : Application
    {
        public App()
        {
            if (helper.Settings.UsernameSettings != null && !"".Equals(helper.Settings.UsernameSettings)) {
                MainPage = new applicatie.ApplicatieStarter();
            } else {
                MainPage = new NavigationPage(new paginas.Login());
            }
        }

        protected override void OnStart()
        {
            helper.Settings.RemoveUserName();
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
