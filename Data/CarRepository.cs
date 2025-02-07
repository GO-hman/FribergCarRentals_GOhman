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

        public void Add(Car car)
        {
            applicationDbContext.Cars.Add(car);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            applicationDbContext.Remove(car);
            applicationDbContext.SaveChanges();

        }

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(c => c.Id);
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            applicationDbContext.Cars.Update(car);
            applicationDbContext.SaveChanges();
        }
    }
}
