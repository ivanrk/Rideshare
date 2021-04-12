namespace Rideshare.Service.Models.Travels
{
    using Rideshare.Service.Models.Cars;
    using Rideshare.Service.Models.Users;
    using System.Collections.Generic;

    public class TravelDetailsModel
    {
        public TravelListingModel Travel { get; set; }

        public bool UserIsInTravel { get; set; }

        public bool UserIsTheDriver { get; set; }

        public bool UserHasApplied { get; set; }

        public CarDetailsModel Car { get; set; }

        public UserProfileModel Driver { get; set; }

        public List<UserProfileModel> Passengers { get; set; }

        public List<UserProfileModel> Applicants { get; set; }
    }
}
