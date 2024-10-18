using GoodwillSingledb.Application.Common.Exceptions;
using GoodwillSingledb.Application.Interfaces;
using GoodwillSingledb.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace GoodwillSingledb.Application.Goodwills.Commands.Partners
{
    public class UpdatePartnerCommand : IRequest
    {
        public int PartnerID { get; set; }
        public int? BusinessID { get; set; }
        public int CuratorID { get; set; }
        public int? ParentPartnerID { get; set; }
        public int FirmID { get; set; }
        public DeliveryTypes DeliveryTypeID { get; set; }
        public int PriceRangeID { get; set; }
        public int RestExportTypeID { get; set; }
        public int BlockTypeID { get; set; }
        public string Code1CNew { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsSafeStorage { get; set; }
        public bool IsShown { get; set; }
        public decimal Margin { get; set; }
        public string Name { get; set; }
        public string LegalName { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Okpo { get; set; }
        public bool Diadoc { get; set; }
        public bool DiadocAuto { get; set; }
        public string DiadocId { get; set; }
        public string RealizeDocsType { get; set; }
        public bool DiadocIncomeDocsHandle { get; set; }
        public bool Federal { get; set; }
        public string ContractNum { get; set; }
        public DateTime? ContractCreatedAt { get; set; }
        public bool WithNds { get; set; }
        public string TransportAddress { get; set; }
        public string TransportName { get; set; }
        public string TransportPhone { get; set; } = null!;
        public string ReceiverAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public bool SendOrdersToStore { get; set; }
        public string Comment { get; set; }
    }

    public class PartnerUpdateCommandHandler
    {
        private readonly IGoodwillSingleDbContext _dbContext;
       // public PartnerUpdateCommandHandler(IGoodwillSingleDbContext dbContext) =>
        //   _dbContext = dbContext;
        public async Task<Unit> Handle(UpdatePartnerCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Partners.FirstOrDefaultAsync(partner =>
            partner.PartnerID == request.PartnerID, cancellationToken);
            if (entity == null || entity.PartnerID != request.PartnerID)
            {
                throw new NotFoundException(nameof(Partner), request.PartnerID);
            }

            //TODO: идентификаторы нельзя обновлять ни в коем случае.
            //Во-первых, он не обновится на уровне бд, т.к. там стоит запрет на обновление первичных ключей
            //Во-вторых, как искать сущность, если у нее каждый раз разрный Id??? 
            //Идентификатор фиксируется один раз в момент создания сущности, затем больше никогда не меняется
            //entity.PartnerID = request.PartnerID;
            entity.BusinessID = request.BusinessID;
            entity.CuratorID = request.CuratorID;
            entity.ParentPartnerID = request.ParentPartnerID;
            entity.FirmID = request.FirmID;
            entity.DeliveryTypeID = request.DeliveryTypeID;
            entity.PriceRangeID = request.PriceRangeID;
            entity.RestExportTypeID = request.RestExportTypeID;
            entity.BlockTypeID = request.BlockTypeID;
            entity.Code1CNew = request.Code1CNew;
            entity.CreationDate = DateTime.Now;
            entity.IsSafeStorage = request.IsSafeStorage;
            entity.IsShown = request.IsShown;
            entity.Margin = request.Margin;
            entity.Name = request.Name;
            entity.LegalName = request.LegalName;
            entity.Inn = request.Inn;
            entity.Kpp = request.Kpp;
            entity.Okpo = request.Okpo;
            entity.Diadoc = request.Diadoc;
            entity.DiadocAuto = request.DiadocAuto;
            entity.DiadocId = request.DiadocId;
            entity.RealizeDocsType = request.RealizeDocsType;
            entity.DiadocIncomeDocsHandle = request.DiadocIncomeDocsHandle;
            entity.Federal = request.Federal;
            entity.ContractNum = request.ContractNum;
            entity.ContractCreatedAt = request.ContractCreatedAt;
            entity.WithNds = request.WithNds;
            entity.TransportAddress = request.TransportAddress;
            entity.TransportName = request.TransportName;
            entity.TransportPhone = request.TransportPhone;
            entity.ReceiverAddress = request.ReceiverAddress;
            entity.ReceiverName = request.ReceiverName;
            entity.ReceiverPhone = request.ReceiverPhone;
            entity.SendOrdersToStore = request.SendOrdersToStore;
            entity.Comment = request.Comment;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
