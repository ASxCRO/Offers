using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.API.Repositories.Implementations;
using Offers.Shared.Domain.Dtos;
using Offers.Shared.Queries;

namespace Offers.API.Handlers.Queries
{
    public class GetOfferItemsQueryHandler : IRequestHandler<GetOfferItemsQuery, GetOfferItemsResponse>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IOfferItemRepository _offerItemRepository;

        public GetOfferItemsQueryHandler(IOfferRepository offerRepository, IOfferItemRepository offerItemRepository)
        {
            _offerRepository = offerRepository;
            _offerItemRepository = offerItemRepository;
        }

        public async Task<GetOfferItemsResponse> Handle(GetOfferItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _offerItemRepository.GetItemsByOfferIdAsync(request.OfferId, request.PageNumber, request.PageSize); 
            var count = await _offerItemRepository.CountItemsByOfferIdAsync(request.OfferId); 
            var totalPrice = await _offerRepository.GetTotalOfferPrice(request.OfferId);

            var offerItemDtos = items.Select(i => new OfferItemDto
            {
                ItemId = i.Id,
                ArticleName = i.ArticleName,
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity,
                TotalPrice = i.TotalPrice
            }).ToList();

            return new GetOfferItemsResponse(offerItemDtos, count, totalPrice);
        }
    }
}
