namespace Offers.Shared.Domain.Models
{
    public class Offer : BaseEntity<int>
    {
        public DateTime OfferDate { get; set; }
    }
}
