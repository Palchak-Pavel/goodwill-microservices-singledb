using AutoMapper;
using GoodwillSingledb.Application.Common.Mappings;
using GoodwillSingledb.Domain;

namespace GoodwillSingledb.Application.Goodwills.Commands.Partners.Queries.GetPartnerList
{
    public class PartnerDto : IMapWith<Partner>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Partner, PartnerDto>()
                .ForMember(partnerVm => partnerVm.BusinessID,
                opt => opt.MapFrom(partner => partner.BusinessID))
                .ForMember(partnerVm => partnerVm.CuratorID,
                opt => opt.MapFrom(partner => partner.CuratorID))
                .ForMember(partnerVm => partnerVm.ParentPartenrID,
                opt => opt.MapFrom(partner => partner.ParentPartenrID))
                .ForMember(partnerVm => partnerVm.FirmID,
                opt => opt.MapFrom(partner => partner.FirmID))
                .ForMember(partnerVm => partnerVm.DeliveryTypeID,
                opt => opt.MapFrom(partner => partner.DeliveryTypeID))
                .ForMember(partnerVm => partnerVm.PriceRangeID,
                opt => opt.MapFrom(partner => partner.PriceRangeID))
                .ForMember(partnerVm => partnerVm.RestExportTypeID,
                opt => opt.MapFrom(partner => partner.RestExportTypeID))
                .ForMember(partnerVm => partnerVm.BlockTypeID,
                opt => opt.MapFrom(partner => partner.BlockTypeID))
                .ForMember(partnerVm => partnerVm.Code1CNew,
                opt => opt.MapFrom(partner => partner.Code1CNew))
                .ForMember(partnerVm => partnerVm.IsSafeStorage,
                opt => opt.MapFrom(partner => partner.IsSafeStorage))
                .ForMember(partnerVm => partnerVm.IsShown,
                opt => opt.MapFrom(partner => partner.IsShown))
                .ForMember(partnerVm => partnerVm.Margin,
                opt => opt.MapFrom(partner => partner.Margin))
                .ForMember(partnerVm => partnerVm.Name,
                opt => opt.MapFrom(partner => partner.Name))
                .ForMember(partnerVm => partnerVm.LegalName,
                opt => opt.MapFrom(partner => partner.LegalName))
                .ForMember(partnerVm => partnerVm.Inn,
                opt => opt.MapFrom(partner => partner.Inn))
                .ForMember(partnerVm => partnerVm.Kpp,
                opt => opt.MapFrom(partner => partner.Kpp))
                .ForMember(partnerVm => partnerVm.Okpo,
                opt => opt.MapFrom(partner => partner.Okpo))
                .ForMember(partnerVm => partnerVm.Diadoc,
                opt => opt.MapFrom(partner => partner.Diadoc))
                .ForMember(partnerVm => partnerVm.DiadocAuto,
                opt => opt.MapFrom(partner => partner.DiadocAuto))
                .ForMember(partnerVm => partnerVm.DiadocId,
                opt => opt.MapFrom(partner => partner.DiadocId))
                .ForMember(partnerVm => partnerVm.RealizeDocsType,
                opt => opt.MapFrom(partner => partner.RealizeDocsType))
                .ForMember(partnerVm => partnerVm.DiadocIncomeDocsHandle,
                opt => opt.MapFrom(partner => partner.DiadocIncomeDocsHandle))
                .ForMember(partnerVm => partnerVm.Federal,
                opt => opt.MapFrom(partner => partner.Federal))
                .ForMember(partnerVm => partnerVm.ContractNum,
                opt => opt.MapFrom(partner => partner.ContractNum))
                .ForMember(partnerVm => partnerVm.ContractCreatedAt,
                opt => opt.MapFrom(partner => partner.ContractCreatedAt))
                .ForMember(partnerVm => partnerVm.WithNds,
                opt => opt.MapFrom(partner => partner.WithNds))
                .ForMember(partnerVm => partnerVm.TransportAddress,
                opt => opt.MapFrom(partner => partner.TransportAddress))
                .ForMember(partnerVm => partnerVm.TransportName,
                opt => opt.MapFrom(partner => partner.TransportName))
                .ForMember(partnerVm => partnerVm.TransportPhone,
                opt => opt.MapFrom(partner => partner.TransportPhone))
                .ForMember(partnerVm => partnerVm.ReceiverAddress,
                opt => opt.MapFrom(partner => partner.ReceiverAddress))
                .ForMember(partnerVm => partnerVm.ReceiverName,
                opt => opt.MapFrom(partner => partner.ReceiverName))
                .ForMember(partnerVm => partnerVm.ReceiverPhone,
                opt => opt.MapFrom(partner => partner.ReceiverPhone))
                .ForMember(partnerVm => partnerVm.SendOrdersToStore,
                opt => opt.MapFrom(partner => partner.SendOrdersToStore))
                .ForMember(partnerVm => partnerVm.Comment,
                opt => opt.MapFrom(partner => partner.Comment));
        }
    }
}
