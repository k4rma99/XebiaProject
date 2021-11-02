using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OId { get; set; }
        public int? UId { get; set; }
        public DateTime? OrDateAndTime { get; set; }
        public int? OrCouponId { get; set; }

        public virtual Coupons OrCoupon { get; set; }
        public virtual Users U { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
