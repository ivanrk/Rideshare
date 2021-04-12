namespace Rideshare.Service.Models.Users
{
    public class UserProfileModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        public decimal AverageRating { get; set; }

        public int TotalVotes { get; set; }

        public string PhoneNumber { get; set; }
    }
}
