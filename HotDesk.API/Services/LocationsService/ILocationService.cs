using System;
using HotDesk.API.Models;

namespace HotDesk.API.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> SelectLocationsAsync();
        Task InsertLocationAsync(Location location);
        Task DeleteLocationAsync(string locationId);
    }
}

