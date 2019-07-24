namespace Rideshare.Services.Models.Travels
{
    using Rideshare.Services.Models.Users;
    using System;
    using System.Collections.Generic;

    public class TravelRateModel
    {
        public string DriverId { get; set; }

        public List<UserProfileModel> Passengers { get; set; }

        public DateTime TravelTime { get; set; }
    }
}
