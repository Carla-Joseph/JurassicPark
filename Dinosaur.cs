using System;
using System.Linq;

namespace JurassicPark
{
    class Dinosaur
    {
        public string Name { get; set; }

        public string DietType { get; set; }

        public DateTime DateAcquired { get; set; }

        public int Weight { get; set; }

        public int EnclosureNumber { get; set; }


        public string Description()
        {
            var description = $"Name: {Name}. Diet Type: {DietType}. Date Acquired: {DateAcquired}. Weight: {Weight} lbs. Enclosure #: {EnclosureNumber}.";

            return description;
        }
    }
}
