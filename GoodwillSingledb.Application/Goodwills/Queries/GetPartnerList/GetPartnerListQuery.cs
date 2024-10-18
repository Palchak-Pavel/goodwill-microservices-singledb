using MediatR;

namespace GoodwillSingledb.Application.Goodwills.Queries.GetPartnerList
{
    public class GetPartnerListQuery : IRequest<PartnerListVm>
    {
        public int? CuratorID { get; set; }
    }
}
