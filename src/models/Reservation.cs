using System.ComponentModel.DataAnnotations;

public class Reservation
{

    public Reservation(int reservationId, string reservationName, string reservationContact, DateTime reservationDateAndTime, int reservationCarId, Car reservationCar)
    {
        this.ReservationId = reservationCarId;
        this.ReservationName = reservationName;
        this.ReservationContact = reservationContact;
        this.ReservationDateAndTime = reservationDateAndTime;
        this.ReservationCarId = reservationCarId;
        this.ReservationCar = reservationCar;

    }
    public Reservation()
    {
    }

    public required int ReservationId { get; set; }

    [Required(ErrorMessage = "User name is required"), StringLength(50, MinimumLength = 3, ErrorMessage = "User name has to be minimum 3 letters to maximum 20 letters")]

    public required string ReservationName { get; set; }

    [Required(ErrorMessage = "Phone number is required"), RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please provide a valid phone number eg: XXX-XXX-XXXX")]

    public required string ReservationContact { get; set; }

    [Required(ErrorMessage = "Reservation Date & Time is required")]
    public required DateTime? ReservationDateAndTime { get; set; }

    public required int? ReservationCarId { get; set; }

    public required Car? ReservationCar { get; set; }
}
