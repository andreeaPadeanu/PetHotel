using SQLite;
using SQLiteNetExtensions.Attributes;
namespace PetHotel_Padeanu_Andreea.Models
{
    public class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Race { get; set; }
        public string Allergies { get; set; }

        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }
        [ManyToOne]
        public virtual Client Client { get; set; }
    }
}

