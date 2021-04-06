namespace Rideshare.Model
{
    using System;
    using System.Collections.Generic;

    public class Travel
    {
        public int Id { get; set; }

        public string StartingPoint { get; set; }

        public string Destination { get; set; }

        public DateTime TravelTime { get; set; }

        public decimal Price { get; set; }

        public int AvailableSeats { get; set; }

        public string AdditionalInfo { get; set; }

        public User Driver { get; set; }

        public string DriverId { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }

        public List<PassengerTravel> Passengers { get; set; } = new List<PassengerTravel>();

        public List<ApplicantTravel> Applicants { get; set; } = new List<ApplicantTravel>();
    }
}
