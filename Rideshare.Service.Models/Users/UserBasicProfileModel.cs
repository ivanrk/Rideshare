namespace Rideshare.Service.Models.Users
{
    public class UserBasicProfileModel
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        public decimal AverageRating { get; set; }
    }
}
