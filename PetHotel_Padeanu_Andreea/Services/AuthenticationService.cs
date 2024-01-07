using PetHotel_Padeanu_Andreea.Models;
using SQLite;
using System.Linq;

namespace PetHotel_Padeanu_Andreea.Services
{
    public class AuthenticationService
    {
        private DatabaseManager _databaseManager;

        public AuthenticationService(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public Client Login(string email, string password)
        {
            var client = _databaseManager.GetClientByEmail(email);
            if (client != null && !string.IsNullOrWhiteSpace(client.Password) && BCrypt.Net.BCrypt.Verify(password, client.Password))
            {
                return client;
            }
            return null;
        }
    }
}
