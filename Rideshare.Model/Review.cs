namespace Rideshare.Model
{
    public class Review
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
