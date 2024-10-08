using AutoMapper;
using AutoMapper.QueryableExtensions;
using GoodwillSingledb.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoodwillSingledb.Application.Goodwills.Queries.GetPartnerList
{
    public class GetPartnerListQueryHandler
        : IRequestHandler<GetPartnerListQuery, PartnerListVm>
    {
        private readonly IGoodwillSingleDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetPartnerListQueryHandler(IGoodwillSingleDbContext dbcontext,
            IMapper mapper) =>
            (_dbcontext, _mapper) = (dbcontext, mapper);
        public async Task<PartnerListVm> Handle(GetPartnerListQuery request,
            CancellationToken cancellationToken)
        {
            var partnersQuery = await _dbcontext.Partners
                .Where(partner => partner.PartnerID == request.PartenrID)
                .ProjectTo<PartnerDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new PartnerListVm { PartnerDtos = partnersQuery };
        }

    }
}
