using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Commands;

namespace Offers.API.Handlers.Commands
{
    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand>
    {
        private readonly IOfferRepository _offerRepository;

        public UpdateOfferCommandHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.GetByIdAsync(request.OfferId);

            if (offer == null)
            {
                throw new KeyNotFoundException($"Offer with ID {request.OfferId} not found.");
            }

            offer.OfferDate = request.OfferDate;

            await _offerRepository.UpdateAsync(offer);
        }
    }
}
