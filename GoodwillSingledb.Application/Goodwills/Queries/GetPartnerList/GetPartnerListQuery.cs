using MediatR;

namespace GoodwillSingledb.Application.Goodwills.Queries.GetPartnerList
{
    public class GetPartnerListQuery : IRequest<PartnerListVm>
    {
        public int PartenrID { get; set; }
    }
}
