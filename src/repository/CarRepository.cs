
using Newtonsoft.Json;

public class CarRepositoryJSON : ICarRepository
{
    public static readonly string JSON = "data/car.json";

    public void BookCar(int? CarId)
    {
        {
            List<Car> cars = GetCars();

            Car? carToBook = cars.Where(car => car.CarId == CarId).FirstOrDefault();

            if (carToBook != null)
            {
                carToBook.CarTotalReservation++;
                string carText = JsonConvert.SerializeObject(cars);
                File.WriteAllText(JSON, carText);
            }
            else
            {
                throw new ArgumentException($"Car with ID {CarId} not found.");
            }
        }
    }

    public List<Car> GetCars()
    {
        if (File.Exists(JSON))
        {
            string carText = File.ReadAllText(JSON);
            if (!String.IsNullOrEmpty(carText))
            {
                List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(carText)!;
                return cars;
            }
        }
        return new List<Car>();
    }

}