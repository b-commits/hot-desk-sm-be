namespace HotDesk.API.Entities;

public class Reservation
{
    public string? Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string DeskId { get; set; }
}