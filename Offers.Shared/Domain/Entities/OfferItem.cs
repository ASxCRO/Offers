namespace Offers.Shared.Domain.Models
{
    public class OfferItem : BaseEntity<int>
    {
        public int OfferId { get; set; }
        public string ArticleName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
