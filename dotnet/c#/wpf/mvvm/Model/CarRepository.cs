using System.Collections.Generic;
using System.Windows.Media;

namespace mvvm.Model
{
    /// <summary>
    ///     A simple class simulating a repository to load the cars from
    /// </summary>
    static class CarRepository
    {
        private static readonly List<Car> cars =
            new List<Car>
            {
                new Car
                {
                    Name = "Seat Ibiza",
                    HP = 84,
                    Color = Colors.LightGray,
                    Price = 9000,
                },
                new Car
                {
                    Name = "Fort Focus ",
                    HP = 100,
                    Color = Colors.Red,
                    Price = 11000,
                },
                new Car
                {
                    Name = "Toyota Corolla",
                    HP = 130,
                    Color = Colors.DarkBlue,
                    Price = 85000,
                }
            };
        
        /// <summary>
        /// Retrieves all known cars
        /// </summary>
        /// <returns>A list of known cars</returns>
        public static IList<Car> GetAllCars()
        {
            return cars;
        }

        /// <summary>
        /// Adds a car to the repository
        /// </summary>
        /// <param name="car">The car to add</param>
        public static void AddCar(Car car)
        {
            cars.Add(car);
        }

        /// <summary>
        /// Removes a car from the repository
        /// </summary>
        /// <param name="car">The car to remove</param>
        /// <returns>True, if the car has been removed, false otherwise</returns>
        public static bool RemoveCar(Car car)
        {
            return cars.Remove(car);
        }
    }
}
