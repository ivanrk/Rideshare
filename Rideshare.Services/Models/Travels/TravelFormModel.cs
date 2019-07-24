namespace Rideshare.Services.Models.Travels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TravelFormModel
    {
        [Required]
        [Display(Name = "From")]
        public string StartingPoint { get; set; }

        [Required]
        [Display(Name = "To")]
        public string Destination { get; set; }

        [Display(Name = "When")]
        public DateTime TravelTime { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Number of available seats")]
        public int AvailableSeats { get; set; }

        [Display(Name = "Additional information")]
        public string AdditionalInfo { get; set; }

        public string DriverId { get; set; }
    }
}
