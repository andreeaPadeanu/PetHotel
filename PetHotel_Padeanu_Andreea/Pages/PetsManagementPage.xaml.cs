using PetHotel_Padeanu_Andreea.Models;
using PetHotel_Padeanu_Andreea.Services;
using Microsoft.Maui.Controls;
using System;

namespace PetHotel_Padeanu_Andreea.Pages
{
    public partial class PetsManagementPage : ContentPage
    {
        private int _clientId;

        public PetsManagementPage(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            LoadPets();
        }

        private void LoadPets()
        {
            var pets = App.DatabaseManager.GetPetsByClientId(_clientId);
            petsListView.ItemsSource = pets;
        }


        private async void OnAddPetClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPetPage(_clientId));
        }

        private async void OnEditPetClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var pet = (Pet)button.BindingContext; 

            await Navigation.PushAsync(new EditPetPage(pet));
        }


        private async void OnDeletePetClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var pet = (Pet)button.BindingContext; 

            bool deleteSuccessful = App.DatabaseManager.DeletePet(pet.Id);

            if (deleteSuccessful)
            {
                await DisplayAlert("Succes", "Animalul de companie a fost șters.", "OK");
                LoadPets(); 
            }
            else
            {
                await DisplayAlert("Eroare", "Ștergerea a eșuat.", "OK");
            }
        }

    }
}
