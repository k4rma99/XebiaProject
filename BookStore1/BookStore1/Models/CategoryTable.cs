using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore1.Models
{
    public partial class CategoryTable
    {
        public CategoryTable()
        {
            BookTable = new HashSet<BookTable>();
        }

        public int CId { get; set; }
        public string CName { get; set; }
        public string CDescription { get; set; }
        public string CImage { get; set; }
        public string CStatus { get; set; }
        public int CPosition { get; set; }
        public DateTime? CCreatedAt { get; set; }

        public virtual ICollection<BookTable> BookTable { get; set; }
        [NotMapped]
        public IFormFile PicFile { get; set; }
    }
}
