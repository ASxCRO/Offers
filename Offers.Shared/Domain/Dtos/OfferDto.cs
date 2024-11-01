using System.ComponentModel.DataAnnotations;

namespace Offers.Shared.Domain.Dtos
{
    public class OfferDto
    {
        public int OfferId { get; set; }

        [Required(ErrorMessage = "Offer Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Offer Date")]
        public DateTime? OfferDate { get; set; }
    }
}
