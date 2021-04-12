namespace Rideshare.Model
{
    using Microsoft.AspNetCore.Identity;
    using Rideshare.Model.Forum;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public byte[] ProfilePicture { get; set; }

        public List<PassengerTravel> Travels { get; set; } = new List<PassengerTravel>();

        public List<ApplicantTravel> Applications { get; set; } = new List<ApplicantTravel>();

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<Car> Cars { get; set; } = new List<Car>();

        public List<Message> Messages { get; set; } = new List<Message>();

        public List<Topic> ForumTopics { get; set; } = new List<Topic>();

        public List<Reply> ForumReplies { get; set; } = new List<Reply>();
    }
}
