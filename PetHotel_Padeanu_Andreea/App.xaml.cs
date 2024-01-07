// App.xaml.cs
using System;
using System.IO;
using Microsoft.Maui.Controls;
using PetHotel_Padeanu_Andreea.Pages;
using PetHotel_Padeanu_Andreea.Services;
using PetHotel_Padeanu_Andreea.Models; 

namespace PetHotel_Padeanu_Andreea
{
    public partial class App : Application
    {
        public static DatabaseManager DatabaseManager { get; private set; }

        public App()
        {
            InitializeComponent();
            SQLitePCL.Batteries_V2.Init();

            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "pet_hotel.db");
            DatabaseManager = new DatabaseManager(databasePath);

            InitializeFacilities();

            MainPage = new NavigationPage(new LoginPage());
        }
        private void InitializeFacilities()
        {
            var facilities = new List<Facility>
        {
            new Facility { Name = "Standard", Description = "Cazare și mese - 50 lei/zi", Price = 50 },
            new Facility { Name = "Pachet Plus", Description = "Cazare, mese și grooming - 75 lei/zi", Price = 75 },
            new Facility { Name = "VIP", Description = "Cazare, mese, joacă, grooming, spa - 100 lei/zi", Price = 100 }
        };

            foreach (var facility in facilities)
            {
                App.DatabaseManager.InsertFacilityIfNotExists(facility);
            }
        }
    }
}
