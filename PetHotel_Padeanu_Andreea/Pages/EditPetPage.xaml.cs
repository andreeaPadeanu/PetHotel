using PetHotel_Padeanu_Andreea.Models;
using Microsoft.Maui.Controls;
using System;

namespace PetHotel_Padeanu_Andreea.Pages
{
    public partial class EditPetPage : ContentPage
    {
        private Pet _pet;

        public EditPetPage(Pet pet)
        {
            InitializeComponent();
            _pet = pet;

            // Popularea câmpurilor cu datele existente ale animalului de companie pentru editare
            nameEntry.Text = _pet.Name;
            typeEntry.Text = _pet.Type;
            colorEntry.Text = _pet.Color;
            raceEntry.Text = _pet.Race;
            allergiesEntry.Text = _pet.Allergies;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _pet.Name = nameEntry.Text;
            _pet.Type = typeEntry.Text;
            _pet.Color = colorEntry.Text;
            _pet.Race = raceEntry.Text;
            _pet.Allergies = allergiesEntry.Text;

            App.DatabaseManager.UpdatePet(_pet);

            await Navigation.PopAsync(); 
        }
    }
}
