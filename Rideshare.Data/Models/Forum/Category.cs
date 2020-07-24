namespace Rideshare.Data.Models.Forum
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Subforum> Subforums { get; set; } = new List<Subforum>();
    }
}
