using MediatR;

namespace Offers.Shared.Queries
{
    public class GetOffersQuery : IRequest<GetOffersResponse>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 3;
    }
}
