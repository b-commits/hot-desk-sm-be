using HotDesk.API.Entities;

namespace HotDesk.API.Services;

public interface IDeskService
{
    Task<IEnumerable<Desk>> GetDesksAsync();
    Task<Desk?> GetDeskByIdAsync(string deskId);
    Task InsertDeskAsync(Desk desk);
    Task DeleteDeskAsync(string deskId);
    Task UpdateDeskAsync(string deskId, Desk newDesk);
}