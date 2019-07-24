namespace Rideshare.Web.Models.Reviews
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ReviewFormViewModel
    {
        public int TravelId { get; set; }

        public int SelectedRating { get; set; }

        [Display(Name = "Rating")]
        public List<SelectListItem> Ratings { get; set; }

        public string Comment { get; set; }

        public string SelectedPassenger { get; set; }

        [Display(Name = "Passenger")]
        public List<SelectListItem> Passengers { get; set; }

        public string DriverId { get; set; }

        public bool TravelHasFinished { get; set; }

        public bool ReviewIsAllowed { get; set; }
    }
}
