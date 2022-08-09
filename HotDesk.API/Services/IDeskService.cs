using System;
using HotDesk.API.Models;

namespace HotDesk.API.Services
{
    public interface IDeskService
    {
        IEnumerable<Desk> GetDesks();
    }
}

