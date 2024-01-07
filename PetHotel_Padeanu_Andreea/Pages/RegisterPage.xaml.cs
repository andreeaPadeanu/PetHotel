using PetHotel_Padeanu_Andreea.Models;
using PetHotel_Padeanu_Andreea.Services;
using BCrypt.Net;
using Android.Renderscripts;

namespace PetHotel_Padeanu_Andreea.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }
    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(emailEntry.Text) ||
            string.IsNullOrWhiteSpace(passwordEntry.Text) ||
            string.IsNullOrWhiteSpace(nameEntry.Text) ||
            string.IsNullOrWhiteSpace(phoneEntry.Text) ||
            string.IsNullOrWhiteSpace(addressEntry.Text))
        {
            await DisplayAlert("Eroare", "Toate câmpurile sunt obligatorii.", "OK");
            return;
        }

        var client = new Client
        {
            Email = emailEntry.Text,
            Password = HashPassword(passwordEntry.Text),
            Name = nameEntry.Text,
            Phone = phoneEntry.Text,
            Address = addressEntry.Text
        };

        try
        {
            App.DatabaseManager.InsertClient(client);
            await DisplayAlert("Succes", "Cont creat cu succes!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", "Nu s-a putut crea contul. Detalii: " + ex.Message, "OK");
        }
    }
}

