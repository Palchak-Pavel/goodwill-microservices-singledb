using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodwillSingledb.Domain
{
    public class PartnerContact : Entity
    {
        public Guid Id { get; set; }
        public int PartnerId { get; set; }
        public string Fio { get; set; }
        public string Email { get; set; }
        public string RestEmail { get; set; }
        public bool SendNotifications{ get; set; }
        public bool SendRests { get; set; }
    }
}
