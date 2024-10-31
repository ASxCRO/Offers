using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Commands;

namespace Offers.API.Handlers.Commands
{
    public class DeleteOfferItemCommandHandler : IRequestHandler<DeleteOfferItemCommand>
    {
        private readonly IOfferItemRepository _offerItemRepository;

        public DeleteOfferItemCommandHandler(IOfferItemRepository offerItemRepository)
        {
            _offerItemRepository = offerItemRepository;
        }

        public async Task Handle(DeleteOfferItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _offerItemRepository.GetByIdAsync(request.Id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Offer item with ID {request.Id} not found.");
            }

            await _offerItemRepository.DeleteAsync(request.Id);
        }
    }
}
