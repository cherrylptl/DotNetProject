using Microsoft.AspNetCore.Mvc.RazorPages;

public class HomeModel : PageModel
{
    public string StoreName { get; } = "Cherryl Patel's Car Rentals";
    public string StoreAddress { get; } = "547, Belmont Avenue West, Kitchener, CANADA";
    public string StorePhone { get; } = "+1 (519)-760-1111";

    private ICarRepository carRepository = new CarRepositoryJSON();
    public List<Car> AllCarsList => carRepository.GetCars();
    private IReservationRepository reservationRepository = new ReservationRepositoryJSON();

    private readonly ILogger<HomeModel> _logger;
    public List<Reservation> reservations { get; set; } = new List<Reservation>();
    public HomeModel(ILogger<HomeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
