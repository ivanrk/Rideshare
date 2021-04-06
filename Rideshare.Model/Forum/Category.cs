namespace Rideshare.Model.Forum
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Subforum> Subforums { get; set; } = new List<Subforum>();
    }
}
