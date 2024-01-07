using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
namespace PetHotel_Padeanu_Andreea.Models
{
    public class Reservation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }

        [ManyToOne]
        public virtual Client Client { get; set; }

        // Această linie poate cauza probleme
        [ManyToMany(typeof(ReservationFacility))] // Adăugat
        public virtual ICollection<Facility> Facilities { get; set; }

        public Reservation()
        {
            Facilities = new HashSet<Facility>();
        }
    }

}
