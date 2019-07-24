namespace Rideshare.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        public int Year { get; set; }

        public byte[] Photo { get; set; }

        public bool HasRoomForLuggage { get; set; }

        public bool HasAirConditioner { get; set; }

        public bool IsSmokingAllowed { get; set; }

        public bool IsFoodAllowed { get; set; }

        public bool AreDrinksAllowed { get; set; }

        public bool ArePetsAllowed { get; set; }

        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public List<Travel> Travels { get; set; } = new List<Travel>();
    }
}
