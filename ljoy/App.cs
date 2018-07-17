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
<<<<<<< HEAD
            MainPage = new MainPage();
<<<<<<< HEAD

            //comment b

=======
>>>>>>> jimmy
=======
            MainPage = new paginas.Login();
>>>>>>> jimmy
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
