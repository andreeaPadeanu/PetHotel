using Microsoft.Maui.Controls;
using PetHotel_Padeanu_Andreea.Services;

namespace PetHotel_Padeanu_Andreea.Pages
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnMakeReservationClicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new ReservationPage());
        }

        private async void OnMyAccountClicked(object sender, EventArgs e)
        {
        }

        private async void OnReservationsClicked(object sender, EventArgs e)
        {
        }

        private async void OnNotificationsClicked(object sender, EventArgs e)
        {
        }
        
        private void LoadNotifications()
        {
            var notifications = App.DatabaseManager.GetAllNotifications();
            notificationsListView.ItemsSource = notifications;
        }
        private async void OnViewUpdateClientClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientDetailsPage(SessionManager.CurrentUserId));
        }

        private async void OnManagePetsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PetsManagementPage(SessionManager.CurrentUserId));
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (this.CurrentPage.Title == "Rezervări")
            {
                LoadReservations();
            }
            else if (this.CurrentPage.Title == "Alerte")
            {
                LoadNotifications();
            }
        }


        private void LoadReservations()
        {
            var reservations = App.DatabaseManager.GetReservationsForClient(SessionManager.CurrentUserId);
            reservationsListView.ItemsSource = reservations;
        }


    }
}
