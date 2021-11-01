using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore1.Models
{
    public partial class AuthorTable
    {
        public AuthorTable()
        {
            BookTable = new HashSet<BookTable>();
        }

        public int AId { get; set; }
        public string AFname { get; set; }
        public string ASname { get; set; }
        public string ACountry { get; set; }

        public virtual ICollection<BookTable> BookTable { get; set; }
    }
}
