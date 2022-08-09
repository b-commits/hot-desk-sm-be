using System;
using HotDesk.API.Models;

namespace HotDesk.API.Services
{
    public class DesksService : IDeskService
    {
        public IEnumerable<Desk> GetDesks()
        {
            return new List<Desk>
            {
                new Desk
                {
                    Id = 1,
                    LocationId = 1
                }
            };
        }
    }
}

