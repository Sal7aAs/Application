using System;
using Microsoft.Maui.Controls;

namespace FinanceApp
{
    public partial class GoldPage : ContentPage
    {
        private GoldHolding goldHolding = new GoldHolding();

        public GoldPage()
        {
            InitializeComponent();
        }

        private async void OnBuyGoldClicked(object sender, EventArgs e)
        {
            // Placeholder logic for buying gold
            double pricePerUnit = 1800; // Example price per unit in USD
            double quantityToBuy = 1; // Example quantity to buy

            // Update gold holding
            goldHolding.PricePerUnit = pricePerUnit;
            goldHolding.Quantity += quantityToBuy;

            // Show confirmation message
            await DisplayAlert("Buy Gold", $"You bought {quantityToBuy} units of gold at {pricePerUnit} USD per unit.", "OK");
        }

        private async void OnSellGoldClicked(object sender, EventArgs e)
        {
            // Placeholder logic for selling gold
            double pricePerUnit = 1850; // Example price per unit in USD
            double quantityToSell = 0.5; // Example quantity to sell

            // Check if enough gold is available to sell
            if (goldHolding.Quantity >= quantityToSell)
            {
                // Update gold holding
                goldHolding.PricePerUnit = pricePerUnit;
                goldHolding.Quantity -= quantityToSell;

                // Show confirmation message
                await DisplayAlert("Sell Gold", $"You sold {quantityToSell} units of gold at {pricePerUnit} USD per unit.", "OK");
            }
            else
            {
                await DisplayAlert("Sell Gold", "You don't have enough gold to sell.", "OK");
            }
        }

        private async void OnCompareToDollarsClicked(object sender, EventArgs e)
        {
            // Placeholder logic for comparing gold to dollars
            double currentGoldPrice = goldHolding.PricePerUnit; // Example current price per unit in USD
            double quantityOwned = goldHolding.Quantity; // Example quantity of gold owned
            double valueInDollars = currentGoldPrice * quantityOwned;

            await DisplayAlert("Gold to Dollars", $"You currently own {quantityOwned} units of gold, valued at {valueInDollars} USD.", "OK");
        }
    }
}
