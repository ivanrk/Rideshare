namespace Rideshare.Data.Models
{
    public class PassengerTravel
    {
        public string PassengerId { get; set; }

        public User Passenger { get; set; }

        public int TravelId { get; set; }

        public Travel Travel { get; set; }
    }
}
