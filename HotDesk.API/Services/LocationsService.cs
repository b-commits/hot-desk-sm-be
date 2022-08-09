using System;
using HotDesk.API.Models;
using MongoDB.Driver;

namespace HotDesk.API.Services
{
    public class LocationsService : ILocationService
    {
        private readonly IMongoCollection<Location> _locationsSerivce;

        public LocationsService(IMongoCollection<Location> locationsService)
        {
            _locationsSerivce = locationsService;
        }


        public async Task<IEnumerable<Location>> GetLocations() =>
     await _locationsSerivce.Find(_ => true).ToListAsync();
    }
}

