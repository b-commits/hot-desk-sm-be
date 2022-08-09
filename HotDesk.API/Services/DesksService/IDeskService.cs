using System;
using HotDesk.API.Models;

namespace HotDesk.API.Services
{
    public interface IDeskService
    {
        Task<IEnumerable<Desk>> GetDesks();
        Task InsertDeskAsync(Desk desk);
        Task DeleteDeskAsync(string deskId);
    }
}

