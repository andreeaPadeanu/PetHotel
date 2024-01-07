using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
namespace PetHotel_Padeanu_Andreea.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public virtual ICollection<Pet> Pets { get; set; }

        public Client()
        {
            Pets = new HashSet<Pet>();
        }
    }
}