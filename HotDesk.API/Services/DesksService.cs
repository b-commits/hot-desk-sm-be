using System;
using HotDesk.API.Models;
using MongoDB.Driver;

namespace HotDesk.API.Services
{
    public class DesksService : IDeskService
    {
        private readonly IMongoCollection<Desk> _desksCollection;

        public DesksService(IMongoCollection<Desk> desksCollection)
        {
            _desksCollection = desksCollection;
        }

        public async Task<IEnumerable<Desk>> GetDesks() =>
          await _desksCollection.Find(_ => true).ToListAsync();

    }

}

