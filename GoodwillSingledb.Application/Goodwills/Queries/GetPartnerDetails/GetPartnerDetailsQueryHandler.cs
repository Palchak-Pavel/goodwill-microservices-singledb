using AutoMapper;
using GoodwillSingledb.Application.Common.Exceptions;
using GoodwillSingledb.Application.Interfaces;
using GoodwillSingledb.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static GoodwillSingledb.Application.Goodwills.Queries.GetPartnerDetails.PartnerDetailsVm;

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
                partner.PartnerID == request.PartnerID, cancellationToken);
            if (entity == null || entity.PartnerID != request.PartnerID)
            {
                throw new NotFoundException(nameof(Partner), request.PartnerID);
            }
            var result = _mapper.Map<PartnerDetailsVm>(entity);
            var delivery = _mapper.Map<DeliveryInfo>(entity);
            var pricing = _mapper.Map<Pricing>(entity);
            var legal = _mapper.Map<Legal>(entity);
            var conturDiadoc = _mapper.Map<ConturDiadoc>(entity);
            var safeStorage = _mapper.Map<SafeStorage>(entity); 

            result.GetDeliveryInfos = delivery;
            result.Pricings = pricing;
            result.GetLegal = legal;
            result.ConturDiadocs = conturDiadoc;
            result.SafeStorages = safeStorage;
            return result;
        }
    }
}
