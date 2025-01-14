using FribergCarRentals_GOhman.Models;

namespace FribergCarRentals_GOhman.Data
{
    public class MockData
    {
        private readonly ICar carRepo;
        private readonly IUser userRepo;

        public MockData()
        {
            
        }
        public MockData(ICar carRepo, IUser userRepo)
        {
            this.carRepo = carRepo;
            this.userRepo = userRepo;
        }
        public void MockCars()
        {
            List<Car> cars = new List<Car>()
            {
                new Car()
                {
                    Model = "Saab 92",
                    ModelYear = "1955",
                    Color = "Mörkröd",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/1955saab92b.jpg/1920px-1955saab92b.jpg",
                    PricePerDay = 10000
                },
                new Car()
                {
                    Model = "Volvo 245",
                    ModelYear = "1983",
                    Color = "Röd",
                    ImgURL = "https://www.bilsport.se/api/images/0-d0018726591760299626-1-d99812734082397/1980x1320/3b2307d2-d05f-5353-bbdd-3a07c1b5f27f.jpg",
                    PricePerDay = 100
                },
                new Car()
                {
                    ModelYear = "1960",
                    Color = "Röd",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/a/a8/1972_Saab_96_V4_1.5.jpg",
                    PricePerDay = 20000
                },
                new Car()
                {
                    Model = "Saab 9-3 Aero",
                    ModelYear = "2002",
                    Color = "Svart",
                    ImgURL = "https://www.saabplanet.com/wp-content/uploads/saab-9-3-aero-burout.jpg",
                    PricePerDay = 200
                },
                new Car()
                {
                    Model = "Saab 99",
                    ModelYear = "1970",
                    Color = "Vit",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/0/0e/SAAB_99_1970.jpg",
                    PricePerDay = 15999
                },
                new Car()
                {
                    Model = "Saab Ursaab",
                    ModelYear = "1947",
                    Color = "Svart",
                    ImgURL = "https://www.netcarshow.com/Saab-UrSaab-1947-wallpaper.jpg",
                    PricePerDay = 17326
                },
                new Car()
                {
                    Model = "Saab Sonett",
                    ModelYear = "1971",
                    Color = "Gul",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/1971_Saab_Sonnett_III_V4_photo-12.JPG/1280px-1971_Saab_Sonnett_III_V4_photo-12.JPG",
                    PricePerDay = 17325
                },
                new Car()
                {
                    Model = "Saab 600",
                    ModelYear = "1985",
                    Color = "Brun",
                    ImgURL = "https://dagensps.fra1.cdn.digitaloceanspaces.com/uploads/2023/04/Saab-Lancia-600-7.jpg",
                    PricePerDay = 12360
                },
                new Car()
                {
                    Model = "Saab 900",
                    ModelYear = "1993",
                    Color = "Blå",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/0/07/1993_Saab_900_SE_Turbo_2.0_Front.jpg",
                    PricePerDay = 19372
                },
                new Car()
                {
                    Model = "Saab 9-2X",
                    ModelYear = "2005",
                    Color = "Svart",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/0/0e/Saab9-2x-ai.jpg",
                    PricePerDay = 63213
                }
            };
            foreach (var car in cars)
            {
                carRepo.Add(car);
            }
        }

        public void MockUsers()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    FirstName = "Marcus",
                    LastName = "Friberg",
                    Email = "bossMan@friMail.org",
                    Password = "passw0rd",
                    IsAdmin = true
                },
                new User()
                {
                    FirstName = "User1",
                    LastName = "Name1",
                    Email = "FirstLast1@mail.com",
                    Password = "password",
                    IsAdmin = false
                },
                new User()
                {
                    FirstName = "User2",
                    LastName = "Name2",
                    Email = "FirstLast2@mail.com",
                    Password = "password",
                    IsAdmin = false
                },
                new User()
                {
                    FirstName = "User3",
                    LastName = "Name3",
                    Email = "FirstLast3@mail.com",
                    Password = "password",
                    IsAdmin = false
                }
            };
            foreach (var user in users)
            {
                userRepo.Add(user);
            }
        }
    }
}
