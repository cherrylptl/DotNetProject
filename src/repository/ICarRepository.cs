public interface ICarRepository
{

    public List<Car> GetCars();
    public void BookCar(int? CarId);
}