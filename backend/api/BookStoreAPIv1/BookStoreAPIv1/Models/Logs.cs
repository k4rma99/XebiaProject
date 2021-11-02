using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class Logs
    {
        public int LId { get; set; }
        public int? UId { get; set; }
        public string LLogType { get; set; }
        public string LUserType { get; set; }
        public DateTime? LDateAndTime { get; set; }

        public virtual Users U { get; set; }
    }
}
