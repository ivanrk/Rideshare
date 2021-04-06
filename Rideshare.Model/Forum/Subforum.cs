namespace Rideshare.Model.Forum
{
    using System.Collections.Generic;

    public class Subforum
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Topic> Topics { get; set; }
    }
}
