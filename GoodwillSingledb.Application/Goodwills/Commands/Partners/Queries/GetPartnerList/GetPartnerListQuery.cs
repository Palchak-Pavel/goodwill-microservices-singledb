using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodwillSingledb.Application.Goodwills.Commands.Partners.Queries.GetPartnerList
{
    public class GetPartnerListQuery : IRequest<PartnerListVm>
    {
        public int PartenrID { get; set; }
    }
}
