using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class Books
    {
        public Books()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int BId { get; set; }
        public string BName { get; set; }
        public int? CId { get; set; }
        public int? AId { get; set; }
        public string BIsbn { get; set; }
        public double BPrice { get; set; }
        public string BDescription { get; set; }
        public int BPosition { get; set; }
        public string BStatus { get; set; }
        public string BImage { get; set; }
        public int BQuantity { get; set; }

        public virtual Authors A { get; set; }
        public virtual Category C { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
