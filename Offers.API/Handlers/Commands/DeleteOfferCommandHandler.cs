using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Commands;

namespace Offers.API.Handlers.Commands
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand>
    {
        private readonly IOfferRepository _offerRepository;

        public DeleteOfferCommandHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.GetByIdAsync(request.Id);

            if (offer == null)
            {
                throw new KeyNotFoundException($"Offer with ID {request.Id} not found.");
            }

            await _offerRepository.DeleteAsync(request.Id);
        }
    }
}
