using SQLite;
using PetHotel_Padeanu_Andreea.Models;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DatabaseManager
{
    private SQLiteConnection db;
    public string DatabasePath { get; private set; }

    public DatabaseManager(string dbPath)
    {
        DatabasePath = dbPath;
        db = new SQLiteConnection(dbPath);
        db.CreateTable<Client>();
        db.CreateTable<Client>();
        db.CreateTable<Pet>();
        db.CreateTable<Facility>();
        db.CreateTable<Reservation>();
        db.CreateTable<ReservationFacility>();
        db.CreateTable<Notification>();
    }
    
    public void InsertClient(Client client)
    {
        db.Insert(client);
    }

    public Client GetClientByEmail(string email)
    {
        return db.Table<Client>().FirstOrDefault(c => c.Email == email);
    }

    public IEnumerable<Client> GetAllClients()
    {
        return db.GetAllWithChildren<Client>();
    }

    public void InsertNotification(Notification notification)
    {
        db.Insert(notification);
    }
    public void InsertReservation(Reservation reservation)
    {
        db.Insert(reservation);
    }
    public List<Facility> GetFacilities()
    {
        return db.Table<Facility>().ToList();
    }

    public void InsertFacilityIfNotExists(Facility facility)
    {
        var existingFacility = db.Table<Facility>().FirstOrDefault(f => f.Name == facility.Name);
        if (existingFacility == null)
        {
            db.Insert(facility);
        }
    }
    public List<Notification> GetAllNotifications()
    {
        return db.Table<Notification>().ToList();
    }
    public Client GetClientById(int clientId)
    {
        return db.Table<Client>().FirstOrDefault(c => c.Id == clientId);
    }
    public bool UpdateClient(Client client)
    {
        var existingClientWithNewEmail = db.Table<Client>().FirstOrDefault(c => c.Email == client.Email && c.Id != client.Id);
        if (existingClientWithNewEmail != null)
        {
            return false;
        }

        try
        {
            db.Update(client);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void InsertPet(Pet pet)
    {
        db.Insert(pet);
    }

    public bool UpdatePet(Pet pet)
    {
        try
        {
            db.Update(pet);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeletePet(int petId)
    {
        try
        {
            var pet = db.Table<Pet>().FirstOrDefault(p => p.Id == petId);
            if (pet != null)
            {
                db.Delete(pet);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<Pet> GetPetsByClientId(int clientId)
    {
        return db.Table<Pet>().Where(p => p.ClientId == clientId).ToList();
    }
    public List<Reservation> GetReservationsForClient(int clientId)
    {
        return db.Table<Reservation>().Where(r => r.ClientId == clientId).ToList();
    }

}
