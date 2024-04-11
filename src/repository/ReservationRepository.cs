using Newtonsoft.Json;

public class ReservationRepositoryJSON : IReservationRepository
{
    public static readonly string JSON = "data/reservation.json";
    public void AddReservation(Reservation reservation)
    {
        List<Reservation> reservations = GetReservations();
        reservations.Add(reservation);

        string userText = JsonConvert.SerializeObject(reservations);
        File.WriteAllText(JSON, userText);
    }

    public List<Reservation> GetReservations()
    {
        if (File.Exists(JSON))
        {
            string reservationsText = File.ReadAllText(JSON);
            if (!String.IsNullOrEmpty(reservationsText))
            {
                List<Reservation> reservations = JsonConvert.DeserializeObject<List<Reservation>>(reservationsText)!;
                return reservations;
            }
        }
        return new List<Reservation>();
    }

    public Reservation GetReservationByID(int ReservationID)
    {
        List<Reservation> reservations = GetReservations();
        foreach (var reservation in reservations)
        {
            if (ReservationID == reservation.ReservationId)
            {
                return reservation;
            }
        }
        throw new InvalidDataException();
    }
}