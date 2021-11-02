using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class Coupons
    {
        public Coupons()
        {
            Orders = new HashSet<Orders>();
        }

        public int CoId { get; set; }
        public string CoCode { get; set; }
        public string CoName { get; set; }
        public DateTime? CoExpiryDate { get; set; }
        public double CoDiscount { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
