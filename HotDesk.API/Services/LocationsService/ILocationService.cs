using HotDesk.API.Entities;

namespace HotDesk.API.Services.LocationsService;

public interface ILocationService
{
    Task<IEnumerable<Location>> GetLocationsAsync();
    Task<Location?> GetLocationBydIdAsync(string locationId);
    Task InsertLocationAsync(Location location);
    Task DeleteLocationAsync(string locationId);
    Task UpdateLocationAsync(string locationId, Location newLocation);
}