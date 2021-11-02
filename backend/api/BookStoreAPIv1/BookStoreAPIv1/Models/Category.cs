using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Books>();
        }

        public int CId { get; set; }
        public string CName { get; set; }
        public string CDescription { get; set; }
        public string CImage { get; set; }
        public string CStatus { get; set; }
        public int CPosition { get; set; }
        public DateTime? CCreatedAt { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
