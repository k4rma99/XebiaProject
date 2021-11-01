using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore1.Models
{
    public partial class Orders
    {
        public int? OrId { get; set; }
        public int UId { get; set; }
        public DateTime? OrDateAndTime { get; set; }
        public string OrCouponId { get; set; }

        public virtual OrderDetailsTable Or { get; set; }
        public virtual CouponTable OrCoupon { get; set; }
    }
}
