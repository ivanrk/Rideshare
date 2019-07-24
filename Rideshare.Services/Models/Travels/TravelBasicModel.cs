namespace Rideshare.Services.Models.Travels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TravelBasicModel
    {
        public int Id { get; set; }

        [Required]
        public string StartingPoint { get; set; }

        [Required]
        public string Destination { get; set; }

        public DateTime TravelTime { get; set; }
    }
}
