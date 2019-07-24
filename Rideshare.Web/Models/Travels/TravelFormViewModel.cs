namespace Rideshare.Web.Models.Travels
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Rideshare.Services.Models.Travels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TravelFormViewModel : TravelFormModel, IValidatableObject
    {
        public int SelectedCar { get; set; }

        [Display(Name = "Car")]
        public IEnumerable<SelectListItem> Cars { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.TravelTime < DateTime.UtcNow.ToLocalTime())
            {
                yield return new ValidationResult("Travel time must be in the future.");
            }

            if (this.AvailableSeats < 1)
            {
                yield return new ValidationResult("Seats must be greater than or equal to 1.");
            }
        }
    }
}
