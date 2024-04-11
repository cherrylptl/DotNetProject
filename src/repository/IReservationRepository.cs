public interface IReservationRepository
{
    public void AddReservation(Reservation reservation);
    public List<Reservation> GetReservations();
    public Reservation GetReservationByID(int ReservationID);
}