using System;
using Xamarin.Forms;

namespace ljoy.paginas
{
    public class MijnAccount : ContentPage
    {
        public MijnAccount()
        {
            Label gebruikerLabel = new Label();
            gebruikerLabel.Text = helper.Settings.UsernameSettings;
            gebruikerLabel.TextColor = Color.Black;
            gebruikerLabel.VerticalOptions = LayoutOptions.Center;

            Button logoutButton = new Button();
            logoutButton.Text = "Uitloggen";
            logoutButton.TextColor = Color.White;
            logoutButton.BackgroundColor = Color.FromHex("#FF4081");
            logoutButton.VerticalOptions = LayoutOptions.Center;
            logoutButton.Clicked += async (object sender, EventArgs e) =>
            {
                helper.Settings.RemoveUserName();
                await UitloggenAsync();
            };

            Content = new StackLayout
            {
                Children = {
                    gebruikerLabel,
                    logoutButton
                }
            };
        }

        private async System.Threading.Tasks.Task UitloggenAsync(){
            await Navigation.PushModalAsync(new NavigationPage(new Login()));
        }
    }
}
