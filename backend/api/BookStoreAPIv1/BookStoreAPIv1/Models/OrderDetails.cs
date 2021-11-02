using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class OrderDetails
    {
        public int OrdrId { get; set; }
        public int? OId { get; set; }
        public int? UId { get; set; }
        public int? BId { get; set; }
        public string BIsbn { get; set; }
        public double BPrice { get; set; }
        public int BQuantity { get; set; }
        public double OTotalPrice { get; set; }
        public string OShippingAddress { get; set; }
        public string OBillingAddress { get; set; }
        public string OPaymentMode { get; set; }

        public virtual Books B { get; set; }
        public virtual Orders O { get; set; }
        public virtual Users U { get; set; }
    }
}
