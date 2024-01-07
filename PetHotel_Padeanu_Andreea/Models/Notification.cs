using SQLite;
using SQLiteNetExtensions.Attributes;
namespace PetHotel_Padeanu_Andreea.Models

{
    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Message { get; set; }
        public DateTime DateCreated { get; set; }

        public Notification()
        {
            DateCreated = DateTime.Now;
        }
    }
}
