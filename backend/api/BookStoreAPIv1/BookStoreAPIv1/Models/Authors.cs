using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class Authors
    {
        public Authors()
        {
            Books = new HashSet<Books>();
        }

        public int AId { get; set; }
        public string AFname { get; set; }
        public string ALname { get; set; }
        public string ACountry { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
