using System.ComponentModel.DataAnnotations;

namespace Offers.Shared.Domain.Dtos
{
    public class OfferItemDto
    {
        public int ItemId { get; set; }
        public int OfferId { get; set; }

        [Required(ErrorMessage = "Article name is required.")]
        public string? ArticleName { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
        public decimal UnitPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
