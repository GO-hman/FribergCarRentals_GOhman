using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext) 
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(c => c.Id);
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(c => c.Id == id);
        }
    }
}
