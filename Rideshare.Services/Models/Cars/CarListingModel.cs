namespace Rideshare.Services.Models.Cars
{
    using System.ComponentModel.DataAnnotations;

    public class CarListingModel
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        public int Year { get; set; }

        public string Photo { get; set; }
    }
}
