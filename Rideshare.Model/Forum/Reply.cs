namespace Rideshare.Model.Forum
{
    using System;

    public class Reply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Published { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}
