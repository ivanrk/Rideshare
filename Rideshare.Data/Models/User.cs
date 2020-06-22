namespace Rideshare.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public byte[] ProfilePicture { get; set; }

        public List<PassengerTravel> Travels { get; set; } = new List<PassengerTravel>();

        public List<ApplicantTravel> Applications { get; set; } = new List<ApplicantTravel>();

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<Car> Cars { get; set; } = new List<Car>();

        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
