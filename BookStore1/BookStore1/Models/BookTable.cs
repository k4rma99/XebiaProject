using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore1.Models
{
    public partial class BookTable
    {
        public BookTable()
        {
            OrderDetailsTable = new HashSet<OrderDetailsTable>();
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

        public virtual AuthorTable A { get; set; }
        public virtual CategoryTable C { get; set; }
        public virtual ICollection<OrderDetailsTable> OrderDetailsTable { get; set; }
        [NotMapped]
        public IFormFile PicFile { get; set; }
    }
}
