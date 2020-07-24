﻿namespace Rideshare.Data.Models.Forum
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Subforum
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Topic> Topics { get; set; }
    }
}
