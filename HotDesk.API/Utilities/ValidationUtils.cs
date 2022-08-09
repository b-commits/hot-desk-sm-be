namespace HotDesk.API.Utilities
{
    public class ValidationUtils
    {
        public static readonly int MAX_RESERVATION_LENGTH = 7;
        public static readonly string RESERVATION_LENGTH_EXCEEDED = String.Format(
            "Reservation can not be longer than {0} days",
            MAX_RESERVATION_LENGTH
        );
        public static readonly string CANNOT_DELETE_DESK = "Cannot delete a Desk if it is under Reservation.";
        public static readonly string CANNOT_DELETE_LOCATION = "Cannot delete a Location if it holds some Desks";
    }
}
