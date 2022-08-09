using System;
namespace HotDesk.API.Models
{
    public class Reservation
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }
        private int deskId { get; set; }
    }
}

