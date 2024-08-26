using MediatR;
using GoodwillSingledb.Domain;
using System.Threading.Tasks;
using System.Xml.Linq;
using GoodwillSingledb.Application.Interfaces;

namespace GoodwillSingledb.Application.Goodwills.Commands.CreateGoodwill
{
    public class CreateGoodwillCommandHandler
        // что-то сделать с Guid
        : IRequestHandler<CreateGoodwillCommand, Guid>
    {
        private readonly IPartenrsDbContext _dbContext;
        public CreateGoodwillCommandHandler(IPartenrsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateGoodwillCommand request,
            CancellationToken cancellationToken)
        {
            
            var partner = new Partner
            {
                PartenrID = request.PartenrID,
                Name = request.Name,
                ContractNum = request.ContractNum,
                CreationDate = DateTime.Now,
             };
            await _dbContext.Partners.AddAsync(partner, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return partner.PartenrID;
        }
    }
}
