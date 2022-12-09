using HotDesk.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HotDesk.API.Config;

public class DatabaseContext : IDatabaseContext
{
    private readonly IMongoCollection<Reservation> _reservations;
    private readonly IMongoCollection<Location> _locations;
    private readonly IMongoCollection<Desk> _desks;

    public DatabaseContext(IOptions<DatabaseConfig> databaseConfig)
    {
        var client = new MongoClient(databaseConfig.Value.ConnectionString);
        var database = client.GetDatabase(databaseConfig.Value.DatabaseName);

        _reservations = database.GetCollection<Reservation>(
            databaseConfig.Value.ReservationsCollectionName
        );
        _locations = database.GetCollection<Location>(
            databaseConfig.Value.LocationsCollectionName
        );
        _desks = database.GetCollection<Desk>(databaseConfig.Value.DesksCollectionName);
    }

    public IMongoCollection<Desk> GetDesksCollection() => _desks;

    public IMongoCollection<Location> GetLocationsCollection() => _locations;

    public IMongoCollection<Reservation> GetReservationsCollection() => _reservations;
}