using AutoMapper;
using GoodwillSingledb.Application.Common.Mappings;
using GoodwillSingledb.Application.Goodwills.Commands.Partners;
using GoodwillSingledb.Application.Goodwills.Commands.Partners.Queries.GetPartnerList;

namespace GoodwillSingledb.WebApi.Models
{
    public class UpdatePartnerDto : IMapWith<UpdatePartnerCommand>
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
            profile.CreateMap<UpdatePartnerDto, UpdatePartnerCommand>()
                .ForMember(partnerCommand => partnerCommand.PartenrID,
                opt => opt.MapFrom(partnerDto => partnerDto.PartenrID))
                .ForMember(partnerCommand => partnerCommand.BusinessID,
                opt => opt.MapFrom(partnerDto => partnerDto.BusinessID))
                .ForMember(partnerCommand => partnerCommand.CuratorID,
                opt => opt.MapFrom(partnerDto => partnerDto.CuratorID))
                .ForMember(partnerCommand => partnerCommand.ParentPartenrID,
                opt => opt.MapFrom(partnerDto => partnerDto.ParentPartenrID))
                .ForMember(partnerCommand => partnerCommand.FirmID,
                opt => opt.MapFrom(partnerDto => partnerDto.FirmID))
                .ForMember(partnerCommand => partnerCommand.DeliveryTypeID,
                opt => opt.MapFrom(partnerDto => partnerDto.DeliveryTypeID))
                .ForMember(partnerCommand => partnerCommand.PriceRangeID,
                opt => opt.MapFrom(partnerDto => partnerDto.PriceRangeID))
                .ForMember(partnerCommand => partnerCommand.RestExportTypeID,
                opt => opt.MapFrom(partnerDto => partnerDto.RestExportTypeID))
                .ForMember(partnerCommand => partnerCommand.BlockTypeID,
                opt => opt.MapFrom(partnerDto => partnerDto.BlockTypeID))
                .ForMember(partnerCommand => partnerCommand.Code1CNew,
                opt => opt.MapFrom(partnerDto => partnerDto.Code1CNew))
                .ForMember(partnerCommand => partnerCommand.IsSafeStorage,
                opt => opt.MapFrom(partnerDto => partnerDto.IsSafeStorage))
                .ForMember(partnerCommand => partnerCommand.IsShown,
                opt => opt.MapFrom(partnerDto => partnerDto.IsShown))
                .ForMember(partnerCommand => partnerCommand.Margin,
                opt => opt.MapFrom(partnerDto => partnerDto.Margin))
                .ForMember(partnerCommand => partnerCommand.Name,
                opt => opt.MapFrom(partnerDto => partnerDto.Name))
                .ForMember(partnerCommand => partnerCommand.LegalName,
                opt => opt.MapFrom(partnerDto => partnerDto.LegalName))
                .ForMember(partnerCommand => partnerCommand.Inn,
                opt => opt.MapFrom(partnerDto => partnerDto.Inn))
                .ForMember(partnerCommand => partnerCommand.Kpp,
                opt => opt.MapFrom(partnerDto => partnerDto.Kpp))
                .ForMember(partnerCommand => partnerCommand.Okpo,
                opt => opt.MapFrom(partnerDto => partnerDto.Okpo))
                .ForMember(partnerCommand => partnerCommand.Diadoc,
                opt => opt.MapFrom(partnerDto => partnerDto.Diadoc))
                .ForMember(partnerCommand => partnerCommand.DiadocAuto,
                opt => opt.MapFrom(partnerDto => partnerDto.DiadocAuto))
                .ForMember(partnerCommand => partnerCommand.DiadocId,
                opt => opt.MapFrom(partnerDto => partnerDto.DiadocId))
                .ForMember(partnerCommand => partnerCommand.RealizeDocsType,
                opt => opt.MapFrom(partnerDto => partnerDto.RealizeDocsType))
                .ForMember(partnerCommand => partnerCommand.DiadocIncomeDocsHandle,
                opt => opt.MapFrom(partnerDto => partnerDto.DiadocIncomeDocsHandle))
                .ForMember(partnerCommand => partnerCommand.Federal,
                opt => opt.MapFrom(partnerDto => partnerDto.Federal))
                .ForMember(partnerCommand => partnerCommand.ContractNum,
                opt => opt.MapFrom(partnerDto => partnerDto.ContractNum))
                .ForMember(partnerCommand => partnerCommand.ContractCreatedAt,
                opt => opt.MapFrom(partnerDto => partnerDto.ContractCreatedAt))
                .ForMember(partnerCommand => partnerCommand.WithNds,
                opt => opt.MapFrom(partnerDto => partnerDto.WithNds))
                .ForMember(partnerCommand => partnerCommand.TransportAddress,
                opt => opt.MapFrom(partnerDto => partnerDto.TransportAddress))
                .ForMember(partnerCommand => partnerCommand.TransportName,
                opt => opt.MapFrom(partnerDto => partnerDto.TransportName))
                .ForMember(partnerCommand => partnerCommand.TransportPhone,
                opt => opt.MapFrom(partnerDto => partnerDto.TransportPhone))
                .ForMember(partnerCommand => partnerCommand.ReceiverAddress,
                opt => opt.MapFrom(partnerDto => partnerDto.ReceiverAddress))
                .ForMember(partnerCommand => partnerCommand.ReceiverName,
                opt => opt.MapFrom(partnerDto => partnerDto.ReceiverName))
                .ForMember(partnerCommand => partnerCommand.ReceiverPhone,
                opt => opt.MapFrom(partnerDto => partnerDto.ReceiverPhone))
                .ForMember(partnerCommand => partnerCommand.SendOrdersToStore,
                opt => opt.MapFrom(partnerDto => partnerDto.SendOrdersToStore))
                .ForMember(partnerCommand => partnerCommand.Comment,
                opt => opt.MapFrom(partnerDto => partnerDto.Comment));
        }
    }
}
