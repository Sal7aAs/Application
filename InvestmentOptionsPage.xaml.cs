using Microsoft.Maui.Controls;

namespace FinanceApp
{
    public partial class InvestmentOptionsPage : ContentPage
    {
        public InvestmentOptionsPage()
        {
            InitializeComponent();
        }

        private async void OnCryptoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CryptoPage());
        }

        private async void OnGoldClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GoldPage());
        }

        private async void OnRealEstateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RealEstatePage());
        }
    }
}
