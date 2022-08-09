using System;
using HotDesk.API.Config;
using HotDesk.API.Models;
using MongoDB.Driver;

namespace HotDesk.API.Services
{
    public class DesksService : IDeskService
    {
        private readonly IMongoCollection<Desk> _desks;

        public DesksService(IDatabaseContext database)
        {
            _desks = database.GetDesksCollection();
        }

        public async Task<IEnumerable<Desk>> GetDesks() =>
          await _desks.Find(_ => true).ToListAsync();

    }

}

