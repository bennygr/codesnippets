using System.Windows.Media;

namespace mvvm.Model
{
    /// <summary>
    ///     An example model class describing a car
    /// </summary>
    class Car
    {
        /// <summary>
        /// Name of the car
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Horsepower of the car
        /// </summary>
        public float HP { get; set; }

        /// <summary>
        /// The color of the car
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// The price of the car
        /// </summary>
        public double Price { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
