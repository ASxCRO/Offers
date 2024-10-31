using MediatR;

namespace Offers.Shared.Commands
{
    public class DeleteOfferCommand : IRequest
    {
        public int Id { get; set; }
    }
}
