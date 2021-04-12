namespace Rideshare.Service.Models.Cars
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class CarFormModel
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        public int Year { get; set; }

        [Display(Name = "Photo (optional)")]
        public IFormFile Photo { get; set; }

        [Display(Name = "Space for luggage")]
        public bool HasRoomForLuggage { get; set; }

        [Display(Name = "Air Conditioner")]
        public bool HasAirConditioner { get; set; }

        [Display(Name = "Smoking allowed")]
        public bool IsSmokingAllowed { get; set; }

        [Display(Name = "Food allowed")]
        public bool IsFoodAllowed { get; set; }

        [Display(Name = "Drinks allowed")]
        public bool AreDrinksAllowed { get; set; }

        [Display(Name = "Pets allowed")]
        public bool ArePetsAllowed { get; set; }

        public string OwnerId { get; set; }
    }
}
