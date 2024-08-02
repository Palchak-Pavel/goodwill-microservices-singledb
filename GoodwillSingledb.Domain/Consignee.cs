using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodwillSingledb.Domain
{
    public class Consignee : Entity
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public string LegalName { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Okpo { get; set; }
        public string Apartment { get; set; }
        public string Block { get; set; }
        public string Building { get; set; }
        public string City { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string Territory { get; set; }
        public string ZipCode { get; set; }
    }
}
