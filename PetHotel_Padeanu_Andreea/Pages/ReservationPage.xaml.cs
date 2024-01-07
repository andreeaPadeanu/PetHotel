using PetHotel_Padeanu_Andreea.Models;
using PetHotel_Padeanu_Andreea.Services;
using Microsoft.Maui.Controls;
using System;

namespace PetHotel_Padeanu_Andreea.Pages
{
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();
            LoadFacilities();
        }

        private void LoadFacilities()
        {
            var facilities = App.DatabaseManager.GetFacilities();
            facilitiesPicker.ItemsSource = facilities;
        }


        private async void OnSaveReservationClicked(object sender, EventArgs e)
        {
            var selectedFacility = facilitiesPicker.SelectedItem as Facility;
            if (selectedFacility == null)
            {
                await DisplayAlert("Eroare", "Selectați o facilitate.", "OK");
                return;
            }

            var reservation = new Reservation
            {
                StartDate = startDatePicker.Date,
                EndDate = endDatePicker.Date,
                ClientId = SessionManager.CurrentUserId,
                Facilities = new List<Facility> { selectedFacility }
            };

            try
            {
                App.DatabaseManager.InsertReservation(reservation);

                var notification = new Notification
                {
                    Message = $"Rezervarea dumneavoastră din {reservation.StartDate.ToShortDateString()} a fost realizată cu succes."
                };
                App.DatabaseManager.InsertNotification(notification);

                await DisplayAlert("Succes", "Rezervarea a fost salvată.", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Eroare", "Nu s-a putut salva rezervarea: " + ex.Message, "OK");
            }

        }
    }
}
