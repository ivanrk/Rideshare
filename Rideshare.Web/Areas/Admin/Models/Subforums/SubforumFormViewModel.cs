namespace Rideshare.Web.Areas.Admin.Models.Subforums
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SubforumFormViewModel
    {
        [Required]
        public string Name { get; set; }

        public int SelectedCategory { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
