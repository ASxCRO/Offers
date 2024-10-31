namespace Offers.Shared.Domain.Dtos
{
    public class OfferItemDto
    {
        public int ItemId { get; set; }
        public string? ArticleName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
