using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public interface ICar
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();
    }
}
