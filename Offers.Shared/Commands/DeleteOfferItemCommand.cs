using MediatR;

namespace Offers.Shared.Commands
{
    public class DeleteOfferItemCommand : IRequest
    {
        public int Id { get; set; }
    }
}
