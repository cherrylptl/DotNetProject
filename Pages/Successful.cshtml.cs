
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SuccessfulModel : PageModel
{
    public Reservation? reservation;
    public Car? car;
    public int reservationID { get; set; }
    public int reservationcarID { get; set; }
    private readonly ILogger<SuccessfulModel> _logger;
    private IReservationRepository reservationRepository = new ReservationRepositoryJSON();
    private ICarRepository carRepository = new CarRepositoryJSON();
    public SuccessfulModel(ILogger<SuccessfulModel> logger)
    {
        _logger = logger;

    }
    public void OnGet(int reservationcarId, int reservationId)
    {
        reservationID = reservationId;
        reservationcarID = reservationcarId;
        car = carRepository.GetCars().FirstOrDefault(car => car.CarId == reservationcarID);
        reservation = reservationRepository.GetReservationByID(reservationId);
    }
}

