using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PetHotel_Padeanu_Andreea.Models
{
    public class ReservationFacility
    {
        [ForeignKey(typeof(Reservation))]
        public int ReservationId { get; set; }

        [ForeignKey(typeof(Facility))]
        public int FacilityId { get; set; }
    }
}
