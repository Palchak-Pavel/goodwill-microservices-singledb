using MediatR;

namespace GoodwillSingledb.Application.Goodwills.Commands.CreateGoodwill
{
    public class CreateGoodwillCommand : IRequest<Guid>
    {
        // Заменить на актуальные поля
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
