using HotDesk.API.Config;
using HotDesk.API.Entities;
using MongoDB.Driver;

namespace HotDesk.API.Services.DesksService;

public class DesksService : IDeskService
{
    private readonly IMongoCollection<Desk> _desks;

    public DesksService(IDatabaseContext database)
    {
        _desks = database.GetDesksCollection();
    }

    public async Task DeleteDeskAsync(string deskId) =>
        await _desks.DeleteOneAsync(desk => desk.Id == deskId);

    public async Task<Desk?> GetDeskByIdAsync(string deskId) =>
        await _desks.Find(desk => desk.Id == deskId).FirstOrDefaultAsync();

    public async Task<IEnumerable<Desk>> GetDesksAsync() =>
        await _desks.Find(_ => true).ToListAsync();

    public async Task InsertDeskAsync(Desk desk) => await _desks.InsertOneAsync(desk);

    public async Task UpdateDeskAsync(string deskId, Desk newDesk) =>
        await _desks.ReplaceOneAsync(desk => desk.Id == deskId, newDesk);
}