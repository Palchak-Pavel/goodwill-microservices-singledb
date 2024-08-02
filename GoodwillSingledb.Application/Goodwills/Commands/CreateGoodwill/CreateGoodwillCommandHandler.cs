using MediatR;
using GoodwillSingledb.Domain;
using System.Threading.Tasks;
using System.Xml.Linq;
using GoodwillSingledb.Application.Interfaces;

namespace GoodwillSingledb.Application.Goodwills.Commands.CreateGoodwill
{
    public class CreateGoodwillCommandHandler
        :IRequestHandler<CreateGoodwillCommandHandler, Guid>
    {
        private readonly IPartnerDbContext _dbContext;
        public CreateGoodwillCommandHandler(IPartnerDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateGoodwillCommandHandler request,
            CancellationToken cancellationToken)
        {
            //fghfghffh
            var entry = new Entry
            {
                Id = Guid.NewGuid(),
                PartenrID = request.PartenrID,
                Code1CNew = request.Code1CNew,
                CreationDate = DateTime.Now,
                Name = request.Name;
            };
            await _dbContext.Entry.AddAsync(entry, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entry.Id;
        }
    }
}
