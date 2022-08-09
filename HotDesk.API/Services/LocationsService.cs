using System;
using HotDesk.API.Config;
using HotDesk.API.Models;
using MongoDB.Driver;

namespace HotDesk.API.Services
{
    public class LocationsService : ILocationService
    {
        private readonly IMongoCollection<Location> _locations;

        public LocationsService(IDatabaseContext database)
        {
            _locations = database.GetLocationsCollection();
        }


        public async Task<IEnumerable<Location>> SelectLocations() => await _locations.Find(_ => true).ToListAsync();

        public async Task InsertLocation(Location location) => await _locations.InsertOneAsync(location);

    }
}

