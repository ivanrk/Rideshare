namespace Rideshare.Services.Models.Travels
{
    using Rideshare.Services.Models.Users;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TravelListingModel
    {
        public int Id { get; set; }

        [Required]
        public string StartingPoint { get; set; }

        [Required]
        public string Destination { get; set; }

        public DateTime TravelTime { get; set; }

        public decimal Price { get; set; }

        public int AvailableSeats { get; set; }

        public string AdditionalInfo { get; set; }

        public UserBasicProfileModel Driver { get; set; }

        public string Car { get; set; }

        public int Passengers { get; set; }
    }
}
