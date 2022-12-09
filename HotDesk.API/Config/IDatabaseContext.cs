using HotDesk.API.Entities;
using MongoDB.Driver;

namespace HotDesk.API.Config;

public interface IDatabaseContext
{
    IMongoCollection<Desk> GetDesksCollection();
    IMongoCollection<Reservation> GetReservationsCollection();
    IMongoCollection<Location> GetLocationsCollection();
}