using System;
using HotDesk.API.Models;

namespace HotDesk.API.Services
{
    public interface ILocationService
    {
        IEnumerable<Location> GetLocations();
    }
}

