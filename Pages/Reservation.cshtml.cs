using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ReservationModel : PageModel
{
    private readonly ILogger<ReservationModel> _logger;

    public Reservation? reservation;
    public int? CarId { get; set; }
    public Car? selectedCar { get; set; }
    private IReservationRepository reservationRepository = new ReservationRepositoryJSON();
    private ICarRepository carRepository = new CarRepositoryJSON();
    public List<Car> AvailableCars => carRepository.GetCars();
    public ReservationModel(ILogger<ReservationModel> logger)
    {
        _logger = logger;

    }
    public void OnGet(int? carId)
    {
        if (carId != null)
        {
            CarId = carId;
            TempData["CarId"] = CarId;
            Console.WriteLine("Car ID: {0}", CarId);
            selectedCar = AvailableCars.FirstOrDefault(car => car.CarId == CarId);
        }

    }

    public IActionResult OnPost(Reservation reservation)

    {

        if (reservation.ReservationCarId == null)
        {
            int? carIdFromTempData = TempData["CarId"] as int?;

            reservation.ReservationCarId = carIdFromTempData;
            reservation.ReservationId = reservationRepository.GetReservations().Count + 1;
            Console.WriteLine("reservation.ReservationCarId {0}", reservation.ReservationId);
            Console.WriteLine("reservation.ReservationCarId {0}", reservation.ReservationCarId);
            Console.WriteLine("reservation.ReservationCarId {0}", reservation.ReservationContact);
            Console.WriteLine("reservation.ReservationCarId {0}", reservation.ReservationName);
            Console.WriteLine("reservation.ReservationCarId {0}", reservation.ReservationDateAndTime);
            reservation.ReservationCar = AvailableCars.FirstOrDefault(car => car.CarId! == reservation!.ReservationCarId);
            Console.WriteLine("reservation.ReservationCarId {0}", reservation.ReservationCar!.CarId);
            carRepository.BookCar(reservation.ReservationCarId ?? 0);
            reservationRepository.AddReservation(reservation);
            if (!ModelState.IsValid || reservation.ReservationDateAndTime <= DateTime.Now)

            {
                Console.WriteLine(ModelState.ErrorCount);
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"Error in property '{entry.Key}': {error.ErrorMessage}");
                    }
                }
                return RedirectToPage("Error", reservation);
            }
            else
            {

                reservation.ReservationId = reservationRepository.GetReservations().Count + 1;
                reservation.ReservationCar = AvailableCars.FirstOrDefault(car => car.CarId! == reservation!.ReservationCarId);
                carRepository.BookCar(reservation.ReservationCarId ?? 0);
                reservationRepository.AddReservation(reservation);
                return RedirectToPage("Successful", new { reservationcarId = reservation!.ReservationCarId, reservationId = reservation.ReservationId });
            }

        }


        if (!ModelState.IsValid || reservation.ReservationDateAndTime <= DateTime.Now)
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>");
            return RedirectToPage("Error", reservation);
        }
        else
        {

            reservation.ReservationId = reservationRepository.GetReservations().Count + 1;
            reservation.ReservationCar = AvailableCars.FirstOrDefault(car => car.CarId! == reservation!.ReservationCarId);
            carRepository.BookCar(reservation.ReservationCarId ?? 0);
            reservationRepository.AddReservation(reservation);
            return RedirectToPage("Successful", new { reservationcarId = reservation!.ReservationCarId, reservationId = reservation.ReservationId });
        }

    }
}

