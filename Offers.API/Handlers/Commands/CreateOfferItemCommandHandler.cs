using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Commands;
using Offers.Shared.Domain.Models;

namespace Offers.API.Handlers.Commands
{
    public class CreateOfferItemCommandHandler : IRequestHandler<CreateOfferItemCommand, int>
    {
        private readonly IOfferItemRepository _offerItemRepository;

        public CreateOfferItemCommandHandler(IOfferItemRepository offerItemRepository)
        {
            _offerItemRepository = offerItemRepository;
        }

        public async Task<int> Handle(CreateOfferItemCommand request, CancellationToken cancellationToken)
        {
            var itemId = await _offerItemRepository.AddAsync(new OfferItem
            {
                OfferId = request.OfferId,
                ArticleName = request.ArticleName,
                UnitPrice = request.UnitPrice,
                Quantity = request.Quantity
            });

            return itemId;
        }
    }
}
