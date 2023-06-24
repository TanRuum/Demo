using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo1.Models
{
    public class DonHang
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public List<MayTinh> MayTinhDatMua = new List<MayTinh>();
    }
}