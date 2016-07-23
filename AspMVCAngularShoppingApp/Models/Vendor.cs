using System;
using System.Linq.Expressions;

namespace AngularDemo.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string VendorEmail { get; set; }
        public string VendorUrl { get; set; }
        public string VendorPhone { get; set; }
    }

    public class VendorVm : Vendor
    {
        public static readonly Expression<Func<Vendor, VendorVm>> Select =
            x => new VendorVm
            {
                VendorId = x.VendorId,
                VendorName = x.VendorName,
                VendorAddress = x.VendorAddress,
                VendorEmail = x.VendorEmail,
                VendorUrl = x.VendorUrl,
                VendorPhone = x.VendorPhone
            };
    }
}