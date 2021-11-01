using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore1.Models
{
    public partial class LogTable
    {
        public int LId { get; set; }
        public int? UId { get; set; }
        public string LUserType { get; set; }
        public DateTime? LDateAndTime { get; set; }

        public virtual UserTable U { get; set; }
    }
}
