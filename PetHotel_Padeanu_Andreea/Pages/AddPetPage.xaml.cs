using PetHotel_Padeanu_Andreea.Models;
using Microsoft.Maui.Controls;
using System;

namespace PetHotel_Padeanu_Andreea.Pages
{
    public partial class AddPetPage : ContentPage
    {
        private int _clientId;

        public AddPetPage(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var pet = new Pet
            {
                Name = nameEntry.Text,
                Type = typeEntry.Text,
                Color = colorEntry.Text,
                Race = raceEntry.Text,
                Allergies = allergiesEntry.Text,
                ClientId = _clientId
            };

            App.DatabaseManager.InsertPet(pet);

            await Navigation.PopAsync(); 
        }
    }
}
