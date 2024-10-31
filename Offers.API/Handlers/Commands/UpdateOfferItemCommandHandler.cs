using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Commands;

namespace Offers.API.Handlers.Commands
{
    public class UpdateOfferItemCommandHandler : IRequestHandler<UpdateOfferItemCommand>
    {
        private readonly IOfferItemRepository _offerItemRepository;

        public UpdateOfferItemCommandHandler(IOfferItemRepository offerItemRepository)
        {
            _offerItemRepository = offerItemRepository;
        }

        public async Task Handle(UpdateOfferItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _offerItemRepository.GetByIdAsync(request.ItemId);

            if (item == null)
            {
                throw new KeyNotFoundException($"Offer item with ID {request.ItemId} not found.");
            }

            if (request.Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0.");
            }

            // Update properties
            item.OfferId = request.OfferId;
            item.ArticleName = request.ArticleName;
            item.UnitPrice = request.UnitPrice;
            item.Quantity = request.Quantity;

            await _offerItemRepository.UpdateAsync(item);
        }
    }
}
