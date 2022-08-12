namespace HotDesk.API.Utilities
{
    public class ValidationUtils
    {
        public static readonly int MAX_RESERVATION_LENGTH = 7;
        public static readonly string RESERVATION_LENGTH_EXCEEDED = String.Format(
            "Reservation can not be longer than {0} days",
            MAX_RESERVATION_LENGTH
        );
        public static readonly string CANNOT_DELETE_DESK =
            "Cannot delete a Desk if it is under Reservation.";
        public static readonly string CANNOT_DELETE_LOCATION =
            "Cannot delete a Location if it holds some Desks";
        public static readonly string DESK_DOES_NOT_EXIST =
            "A Desk with a provided ID does not exist";

        public static bool doesDateOverlap(
            DateTime existingDateStart,
            DateTime existingDateEnd,
            DateTime newDateStart,
            DateTime newDateEnd
        )
        {
            if (existingDateEnd < existingDateStart)
                throw new ArgumentException("Interal error");

            if (newDateEnd < newDateStart)
                throw new ArgumentException("Date start can not be after its end.");

            return (
                (newDateStart <= existingDateEnd && newDateStart >= existingDateEnd)
                || (newDateEnd <= existingDateEnd && newDateEnd >= existingDateStart)
            );
        }
    }
}
