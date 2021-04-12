namespace Rideshare.Service.Models.Users
{
    using System;

    public class UserTravelListingModel
    {
        public int Id { get; set; }

        public string StartingPoint { get; set; }

        public string Destination { get; set; }

        public DateTime TravelTime { get; set; }

        public bool UserIsDriver { get; set; }

        public bool UserIsPassenger { get; set; }

        public int Applicants { get; set; }
    }
}
