using MediatR;

namespace GoodwillSingledb.Application.Goodwills.Queries.GetPartnerDetails
{
    public class GetPartnerDetailsQuery : IRequest<PartnerDetailsVm>
    {
        public int PartenrID { get; set; }
    }
}
