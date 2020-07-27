namespace Rideshare.Data.Models.Forum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Topic
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Published { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int SubforumId { get; set; }

        public Subforum Subforum { get; set; }

        public List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
