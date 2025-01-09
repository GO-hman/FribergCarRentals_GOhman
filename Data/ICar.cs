using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public interface ICar
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
