using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoodwillSingledb.Domain
{
    public class Partner : Entity
    {
        // public int PartenrID { get; set; }
        //TODO: должно либо совпадать по названию с полем таблицы, либо должен быть специальный конфиг. В общем внимательней
        public int PartnerID { get; set; }
        public int? BusinessID { get; set; }
        public int CuratorID { get; set; }
        public int? ParentPartnerID { get; set; }
        public int FirmID{ get; set; }
        public int DeliveryTypeID { get; set; }
        public int PriceRangeID { get; set; }
        public int RestExportTypeID { get; set; }
        public int BlockTypeID { get; set; }
        public string Code1CNew { get; set; }
        public DateTime CreationDate{ get; set; }
        public bool IsSafeStorage{ get; set; }
        public bool IsShown { get; set; }
        public decimal Margin { get; set; }
        public string Name { get; set; }
        public string LegalName { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Okpo { get; set; }
        public bool Diadoc{ get; set; }
        public bool DiadocAuto { get; set; }
        public string DiadocId { get; set; }
        public string RealizeDocsType { get; set; }
        public bool DiadocIncomeDocsHandle { get; set; }
        public bool Federal { get; set; }
        public string? ContractNum { get; set; }
        public DateTime? ContractCreatedAt { get; set; }
        
        //TODO: в базе это поле nullable. Не знаю почему так получилось, но проще пока в коде это учесть, чем базу на ходу править
        public bool? WithNds{ get; set; }
        public string TransportAddress { get; set; }
        public string TransportName { get; set; }
        public string TransportPhone { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public bool SendOrdersToStore{ get; set; }
        public string Comment { get; set; }
    }
}
