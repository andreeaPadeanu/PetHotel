using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using SQLitePCL;
using UIKit;

namespace PetHotel_Padeanu_Andreea
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Batteries.Init(); // Inițializarea SQLitePCL
            var app = MauiProgram.CreateMauiApp();
            MauiApplication.Run(app);
        }
    }
}
