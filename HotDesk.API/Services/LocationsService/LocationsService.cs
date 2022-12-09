using HotDesk.API.Config;
using HotDesk.API.Entities;
using MongoDB.Driver;

namespace HotDesk.API.Services.LocationsService;

public class LocationsService : ILocationService
{
    private readonly IMongoCollection<Location> _locations;

    public LocationsService(IDatabaseContext database)
    {
        _locations = database.GetLocationsCollection();
    }

    public async Task<IEnumerable<Location>> GetLocationsAsync() =>
        await _locations.Find(_ => true).ToListAsync();

    public async Task InsertLocationAsync(Location location) =>
        await _locations.InsertOneAsync(location);

    public async Task DeleteLocationAsync(string locationId) =>
        await _locations.DeleteOneAsync(location => location.Id == locationId);

    public async Task<Location?> GetLocationBydIdAsync(string locationId) =>
        await _locations.Find(location => location.Id == locationId).FirstOrDefaultAsync();

    public async Task UpdateLocationAsync(string locationId, Location newLocation) =>
        await _locations.ReplaceOneAsync(location => location.Id == locationId, newLocation);
}