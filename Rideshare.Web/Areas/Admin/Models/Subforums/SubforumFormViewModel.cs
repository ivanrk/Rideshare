namespace Rideshare.Web.Areas.Admin.Models.Subforums
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SubforumFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SelectedCategory { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public int CurrentCategoryId { get; set; }
    }
}
