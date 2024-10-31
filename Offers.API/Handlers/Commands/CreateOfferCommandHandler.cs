using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Commands;
using Offers.Shared.Domain.Models;

namespace Offers.API.Handlers.Commands
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, int>
    {
        private readonly IOfferRepository _offerRepository;

        public CreateOfferCommandHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<int> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            var offerId = await _offerRepository.AddAsync(new Offer
            {
                OfferDate = request.OfferDate
            });

            return offerId;
        }
    }
}
