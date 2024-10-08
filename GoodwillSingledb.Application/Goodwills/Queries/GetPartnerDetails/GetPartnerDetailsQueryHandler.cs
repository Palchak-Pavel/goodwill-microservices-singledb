using AutoMapper;
using GoodwillSingledb.Application.Common.Exceptions;
using GoodwillSingledb.Application.Interfaces;
using GoodwillSingledb.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoodwillSingledb.Application.Goodwills.Queries.GetPartnerDetails
{
    public class GetPartnerDetailsQueryHandler
        : IRequestHandler<GetPartnerDetailsQuery, PartnerDetailsVm>
    {
        private readonly IGoodwillSingleDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPartnerDetailsQueryHandler(IGoodwillSingleDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

       public async Task<PartnerDetailsVm> Handle(GetPartnerDetailsQuery request,
           CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Partners
                .FirstOrDefaultAsync(partner =>
                partner.PartnerID == request.PartenrID, cancellationToken);
            if (entity == null || entity.PartnerID != request.PartenrID)
            {
                throw new NotFoundException(nameof(Partner), request.PartenrID);
            }
            return _mapper.Map<PartnerDetailsVm>(entity);
        }
    }
}
