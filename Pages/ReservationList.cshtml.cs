using Microsoft.AspNetCore.Mvc.RazorPages;

public class ReservationListModel : PageModel
{
    private readonly ILogger<ReservationListModel> _logger;

    private IReservationRepository reservationRepository = new ReservationRepositoryJSON();
    public List<Reservation> Reservations = new List<Reservation>();

    public ReservationListModel(ILogger<ReservationListModel> logger)
    {
        _logger = logger;

    }
    public void OnGet()
    {
        Reservations = reservationRepository.GetReservations();
    }
}

