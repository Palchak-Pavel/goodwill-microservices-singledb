using MediatR;

namespace GoodwillSingledb.Application.Goodwills.Commands.CreateGoodwill
{
    public class CreateGoodwillCommand : IRequest<Guid>
    {
        // Заменить на актуальные поля
        public int PartenrID { get; set; }
        public string Name { get; set; }
        public string ContractNum { get; set; }
    }
}
