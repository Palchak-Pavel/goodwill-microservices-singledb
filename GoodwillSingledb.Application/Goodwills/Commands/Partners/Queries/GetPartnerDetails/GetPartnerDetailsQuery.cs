using MediatR;

namespace GoodwillSingledb.Application.Goodwills.Commands.Partners.Queries.GetPartnerDetails
{
    public class GetPartnerDetailsQuery : IRequest<PartnerDetailsVm>
    {
        public int PartenrID { get; set; }
    }
}
