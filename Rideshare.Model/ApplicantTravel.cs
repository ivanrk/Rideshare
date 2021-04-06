namespace Rideshare.Model
{
    public class ApplicantTravel
    {
        public string ApplicantId { get; set; }

        public User Applicant { get; set; }

        public int TravelId { get; set; }

        public Travel Travel { get; set; }
    }
}
