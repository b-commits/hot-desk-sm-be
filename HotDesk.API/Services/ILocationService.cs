using System;
using HotDesk.API.Models;

namespace HotDesk.API.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> SelectLocations();
        Task InsertLocation(Location location);
    }
}

