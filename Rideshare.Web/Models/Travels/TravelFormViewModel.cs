namespace Rideshare.Web.Models.Travels
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Rideshare.Services.Models.Travels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TravelFormViewModel : TravelFormModel
    {
        public int SelectedCar { get; set; }

        [Display(Name = "Car")]
        public IEnumerable<SelectListItem> Cars { get; set; }
    }
}
