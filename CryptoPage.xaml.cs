using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace FinanceApp
{
    public partial class CryptoPage : ContentPage
    {
        // Dictionary to store balances for each cryptocurrency type
        private Dictionary<string, double> cryptoBalances = new Dictionary<string, double>
        {
            { "Bitcoin", 0 },
            { "Ethereum", 0 },
            { "Litecoin", 0 },
            { "Ripple", 0 }
        };

        public CryptoPage()
        {
            InitializeComponent();
        }

        private async void OnBuyCryptoClicked(object sender, EventArgs e)
        {
            // Show selection dialog for cryptocurrency type
            string selectedCrypto = await DisplayActionSheet("Select Cryptocurrency", "Cancel", null, "Bitcoin", "Ethereum", "Litecoin", "Ripple");

            if (selectedCrypto != "Cancel")
            {
                double rate = await GetExchangeRate(selectedCrypto);
                if (rate > 0)
                {
                    double amount = await GetTransactionAmount("Buy", selectedCrypto);
                    if (amount > 0)
                    {
                        double totalCost = amount * rate;
                        cryptoBalances[selectedCrypto] += amount;
                        await DisplayAlert("Transaction Complete", $"You bought {amount} units of {selectedCrypto} at {rate} USD per unit. Total cost: {totalCost} USD", "OK");
                    }
                }
            }
        }

        private async void OnSellCryptoClicked(object sender, EventArgs e)
        {
            // Show selection dialog for cryptocurrency type
            string selectedCrypto = await DisplayActionSheet("Select Cryptocurrency", "Cancel", null, "Bitcoin", "Ethereum", "Litecoin", "Ripple");

            if (selectedCrypto != "Cancel")
            {
                double rate = await GetExchangeRate(selectedCrypto);
                if (rate > 0)
                {
                    double amount = await GetTransactionAmount("Sell", selectedCrypto);
                    if (amount > 0)
                    {
                        double totalValue = amount * rate;
                        if (cryptoBalances[selectedCrypto] >= amount)
                        {
                            cryptoBalances[selectedCrypto] -= amount;
                            await DisplayAlert("Transaction Complete", $"You sold {amount} units of {selectedCrypto} at {rate} USD per unit. Total value: {totalValue} USD", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Insufficient Balance", $"You don't have enough {selectedCrypto} to sell.", "OK");
                        }
                    }
                }
            }
        }

        private async void OnViewWalletClicked(object sender, EventArgs e)
        {
            string walletInfo = "Crypto Wallet:\n";

            foreach (var balance in cryptoBalances)
            {
                double rate = await GetExchangeRate(balance.Key);
                if (rate > 0)
                {
                    double valueInDollars = balance.Value * rate;
                    walletInfo += $"{balance.Key}: {balance.Value} units, {valueInDollars} USD per unit\n";
                }
            }

            await DisplayAlert("View Wallet", walletInfo, "OK");
        }

        private async Task<double> GetExchangeRate(string cryptoSymbol)
        {
            // Assume you have a method to fetch exchange rate from an external API
            // Example:
            // double rate = await exchangeRateService.GetExchangeRate(cryptoSymbol);
            // Replace this with actual implementation
            await Task.Delay(100); // Placeholder delay
            return 50000; // Placeholder exchange rate
        }

        private async Task<double> GetTransactionAmount(string action, string crypto)
        {
            double amount = 0;

            string userInput = await DisplayPromptAsync($"{action} {crypto}", $"Enter the amount of {crypto} to {action.ToLower()}:");

            if (!string.IsNullOrEmpty(userInput) && double.TryParse(userInput, out amount))
            {
                return amount;
            }

            return 0;
        }
    }
}
