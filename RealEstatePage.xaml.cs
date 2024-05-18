using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace FinanceApp
{
    public partial class RealEstatePage : ContentPage
    {
        public RealEstatePage()
        {
            InitializeComponent();
        }

        private async void OnBuyPropertyClicked(object sender, EventArgs e)
        {
            // Show options for different types of properties, locations, and sizes
            string propertyType = await DisplayActionSheet("Select Property Type", "Cancel", null, "House", "Apartment", "Commercial");

            if (propertyType != "Cancel")
            {
                // Check minimum amount per property type
                double minAmount = GetMinimumAmountForPropertyType(propertyType);
                if (minAmount > 0)
                {
                    // Proceed with purchase logic for the selected property type
                    await DisplayAlert("Buy Property", $"You selected {propertyType}. Minimum amount required: {minAmount}.", "OK");
                }
                else
                {
                    await DisplayAlert("Error", $"Invalid property type selected.", "OK");
                }
            }
        }

        private async void OnSellPropertyClicked(object sender, EventArgs e)
        {
            // Assume user already owns properties, retrieve owned properties from storage or database
            string[] ownedProperties = { "House in Suburb A", "Apartment in Downtown", "Commercial Building in Business District" };

            // Show owned properties for selection
            string selectedProperty = await DisplayActionSheet("Select Property to Sell", "Cancel", null, ownedProperties);

            if (selectedProperty != "Cancel")
            {
                // Check minimum amount for selling
                double minAmount = GetMinimumAmountForPropertyType(selectedProperty);
                if (minAmount > 0)
                {
                    // Proceed with selling logic for the selected property
                    await DisplayAlert("Sell Property", $"You selected {selectedProperty} to sell. Minimum amount required: {minAmount}.", "OK");
                }
                else
                {
                    await DisplayAlert("Error", $"Invalid property selected for selling.", "OK");
                }
            }
        }

        private async void OnInvestInPropertyClicked(object sender, EventArgs e)
        {
            // Display real estate agencies and prices for investment
            string selectedAgency = await DisplayActionSheet("Select Real Estate Agency", "Cancel", null, "Agency A", "Agency B", "Agency C");

            if (selectedAgency != "Cancel")
            {
                // Check minimum investment amount
                double minInvestment = GetMinimumInvestmentAmount();
                if (minInvestment > 0)
                {
                    // Proceed with investment logic for the selected agency
                    double investmentAmount = await GetInvestmentAmount();
                    if (investmentAmount >= minInvestment)
                    {
                        await DisplayAlert("Invest in Property", $"You invested {investmentAmount} in {selectedAgency}.", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Error", $"Minimum investment amount required: {minInvestment}.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", $"Invalid investment selected.", "OK");
                }
            }
        }

        private double GetMinimumAmountForPropertyType(string propertyType)
        {
            // Define minimum amounts per property type
            Dictionary<string, double> minAmounts = new Dictionary<string, double>
            {
                { "House", 100000 },
                { "Apartment", 50000 },
                { "Commercial", 200000 }
            };

            // Lookup and return minimum amount for the specified property type
            if (minAmounts.ContainsKey(propertyType))
            {
                return minAmounts[propertyType];
            }
            else
            {
                return 0; // Return 0 for invalid property type
            }
        }

        private double GetMinimumInvestmentAmount()
        {
            // Define minimum investment amount
            return 10000;
        }

        private async Task<double> GetInvestmentAmount()
        {
            double amount = 0;

            string userInput = await DisplayPromptAsync("Investment Amount", "Enter the amount to invest:");

            if (!string.IsNullOrEmpty(userInput) && double.TryParse(userInput, out amount))
            {
                return amount;
            }

            return 0;
        }
    }
}
