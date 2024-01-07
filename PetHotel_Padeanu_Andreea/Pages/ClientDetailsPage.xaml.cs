using PetHotel_Padeanu_Andreea.Models;
using PetHotel_Padeanu_Andreea.Services;
using Microsoft.Maui.Controls;
using System;

namespace PetHotel_Padeanu_Andreea.Pages
{
    public partial class ClientDetailsPage : ContentPage
    {
        private int _clientId;

        public ClientDetailsPage(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            LoadClientDetails();
        }

        private void LoadClientDetails()
        {
            var client = App.DatabaseManager.GetClientById(_clientId);
            if (client != null)
            {
                nameEntry.Text = client.Name;
                emailEntry.Text = client.Email;
                phoneEntry.Text = client.Phone;
                addressEntry.Text = client.Address;
            }
        }

        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            var client = new Client
            {
                Id = _clientId,
                Name = nameEntry.Text,
                Email = emailEntry.Text,
                Phone = phoneEntry.Text,
                Address = addressEntry.Text
            };

            bool updateSuccessful = App.DatabaseManager.UpdateClient(client);
            if (updateSuccessful)
            {
                await DisplayAlert("Succes", "Datele clientului au fost actualizate.", "OK");
            }
            else
            {
                await DisplayAlert("Eroare", "Actualizarea a eșuat.", "OK");
            }
        }
    }
}
