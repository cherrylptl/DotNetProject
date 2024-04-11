using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ErrorModel : PageModel
{
    public List<String> errors { get; set; } = new List<String>();
    public Reservation? reservation;

    private readonly ILogger<ErrorModel> _logger;

    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }


    public void OnGet(Reservation _reservation)

    {
        reservation = _reservation;

        if (reservation.ReservationName != null && reservation.ReservationName.Length < 3)
        {
            errors.Add("User name has to be minimum 3 letters to maximum 20 letters");
        }

        if (reservation.ReservationContact != null && !Regex.IsMatch(reservation.ReservationContact, @"^\d{3}-\d{3}-\d{4}$"))
        {
            errors.Add("Please provide a valid phone number in the format XXX-XXX-XXXX");
        }

        if (reservation.ReservationDateAndTime <= DateTime.Now)
        {
            errors.Add("Reservation date & time should be greater than the current date & time.");
        }
    }
}

