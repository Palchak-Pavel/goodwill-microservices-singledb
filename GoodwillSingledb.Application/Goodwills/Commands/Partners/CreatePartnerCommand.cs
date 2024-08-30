using GoodwillSingledb.Application.Interfaces;
using GoodwillSingledb.Domain;
using MediatR;


namespace GoodwillSingledb.Application.Goodwills.Commands.Partners
{
    public class CreatePartnerCommand : IRequest<int>
    {
        public int PartenrID { get; set; }
        public int? BusinessID { get; set; }
        public int CuratorID { get; set; }
        public int? ParentPartenrID { get; set; }
        public int FirmID { get; set; }
        public int DeliveryTypeID { get; set; }
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
        public string TransportPhone { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public bool SendOrdersToStore { get; set; }
        public string Comment { get; set; }
    }

    public class PartnerCreateCommandHandler : IRequestHandler<CreatePartnerCommand, int>
    {
        private readonly IGoodwillSingleDbContext _dbContext;
        public async Task<int> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
        {
            var partner = new Partner
            {
                PartenrID = request.PartenrID,
                BusinessID = request.BusinessID,
                CuratorID = request.CuratorID,
                ParentPartenrID =   request.ParentPartenrID,
                FirmID = request.FirmID,
                DeliveryTypeID = request.DeliveryTypeID,
                PriceRangeID = request.PriceRangeID,
                RestExportTypeID = request.RestExportTypeID,
                BlockTypeID = request.BlockTypeID,
                Code1CNew = request.Code1CNew,
                CreationDate = DateTime.Now,
                IsSafeStorage = request.IsSafeStorage,
                IsShown = request.IsShown,
                Margin = request.Margin,
                Name = request.Name,
                LegalName = request.LegalName,
                Inn = request.Inn,
                Kpp = request.Kpp,
                Okpo = request.Okpo,
                Diadoc = request.Diadoc,
                DiadocAuto = request.DiadocAuto,
                DiadocId = request.DiadocId,
                RealizeDocsType = request.RealizeDocsType,
                DiadocIncomeDocsHandle = request.DiadocIncomeDocsHandle,
                Federal = request.Federal,
                ContractNum = request.ContractNum,
                ContractCreatedAt = request.ContractCreatedAt,
                WithNds = request.WithNds,
                TransportAddress = request.TransportAddress,
                TransportName = request.TransportName,
                TransportPhone = request.TransportPhone,
                ReceiverAddress = request.ReceiverAddress,
                ReceiverName = request.ReceiverName,
                ReceiverPhone = request.ReceiverPhone,
                SendOrdersToStore = request.SendOrdersToStore,
                Comment = request.Comment,

            };
            await _dbContext.Partners.AddAsync(partner, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return partner.PartenrID;
        }
    }
}
