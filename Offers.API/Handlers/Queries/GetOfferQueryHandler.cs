using MediatR;
using Offers.API.Repositories.Abstractions;
using Offers.Shared.Domain.Dtos;
using Offers.Shared.Queries;

namespace Offers.API.Handlers.Queries
{
    public class GetOfferQueryHandler : IRequestHandler<GetOfferQuery, OfferDto>
    {
        private readonly IOfferRepository _offerRepository;

        public GetOfferQueryHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<OfferDto> Handle(GetOfferQuery request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.GetByIdAsync(request.OfferId); 
            if (offer == null)
            {
                return null; 
            }

            return new OfferDto
            {
                OfferId = offer.Id,
                OfferDate = offer.OfferDate
            };
        }
    }
}
