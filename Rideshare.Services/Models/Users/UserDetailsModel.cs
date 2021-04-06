namespace Rideshare.Services.Models.Users
{
    using Rideshare.Model;
    using System.Collections.Generic;

    public class UserDetailsModel : UserProfileModel
    {
        public int TimesAsAPassenger { get; set; }

        public int TimesAsADriver { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
