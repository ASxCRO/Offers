using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Domain.Dtos;
using Offers.Shared.Queries;

namespace Offers.API.Handlers.Queries
{
    public class GetOffersQueryHandler : IRequestHandler<GetOffersQuery, GetOffersResponse>
    {
        private readonly IOfferRepository _offerRepository;

        public GetOffersQueryHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<GetOffersResponse> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            var offers = await _offerRepository.GetAllAsync(request.PageNumber, request.PageSize);
            var totalCount = await _offerRepository.TotalCountAsync(); 

            var offerDtos = offers.Select(o => new OfferDto
            {
                OfferId = o.Id,
                OfferDate = o.OfferDate
            }).ToList();

            return new GetOffersResponse(offerDtos, totalCount);
        }
    }
}
