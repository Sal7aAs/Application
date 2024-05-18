using Microsoft.Maui.Controls;

namespace FinanceApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGetStartedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InvestmentOptionsPage());
        }

        private void OnVisitWebsiteClicked(object sender, EventArgs e)
        {
            // URL of the website to open
            string websiteUrl = "https://finances.digital/";

            // Open the website in the default system browser
            Launcher.OpenAsync(websiteUrl);
        }
    }
}
