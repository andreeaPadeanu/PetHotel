using SQLite;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace PetHotel_Padeanu_Andreea.Models
{
    public class Facility
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        [ManyToMany(typeof(ReservationFacility))] // Adăugat
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Facility()
        {
            Reservations = new HashSet<Reservation>();
        }
    }

}

