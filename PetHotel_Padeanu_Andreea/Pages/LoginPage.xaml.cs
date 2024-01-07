using PetHotel_Padeanu_Andreea.Services;
using Microsoft.Maui.Controls;
using System;
using PetHotel_Padeanu_Andreea.Models;

namespace PetHotel_Padeanu_Andreea.Pages
{
    public partial class LoginPage : ContentPage
    {
        private AuthenticationService _authService;

        public LoginPage()
        {
            InitializeComponent();
            _authService = new AuthenticationService(App.DatabaseManager);
        }


        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Eroare", "Te rog să completezi emailul și parola.", "OK");
                return;
            }

            var client = _authService.Login(emailEntry.Text, passwordEntry.Text);
            if (client != null)
            {
                SessionManager.CurrentUserId = client.Id;
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Eroare", "Emailul sau parola sunt incorecte", "OK");
            }
        }




        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
