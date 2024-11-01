using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Domain.Dtos;
using Offers.Shared.Queries;

namespace Offers.API.Handlers.Queries
{
    public class GetOfferItemQueryHandler : IRequestHandler<GetOfferItemQuery, OfferItemDto>
    {
        private readonly IOfferItemRepository _offerItemRepository;

        public GetOfferItemQueryHandler(IOfferItemRepository offerItemRepository)
        {
            _offerItemRepository = offerItemRepository;
        }

        public async Task<OfferItemDto> Handle(GetOfferItemQuery request, CancellationToken cancellationToken)
        {
            var item = await _offerItemRepository.GetByIdAsync(request.ItemId); 
            if (item == null)
            {
                return null; 
            }

            return new OfferItemDto
            {
                ItemId = item.Id,
                ArticleName = item.ArticleName,
                UnitPrice = item.UnitPrice,
                Quantity = item.Quantity,
                TotalPrice = item.TotalPrice
            };
        }
    }
}
