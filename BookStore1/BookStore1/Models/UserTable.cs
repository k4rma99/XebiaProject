using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore1.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            LogTable = new HashSet<LogTable>();
            OrderDetailsTable = new HashSet<OrderDetailsTable>();
        }

        public int UId { get; set; }
        public string UFname { get; set; }
        public string USname { get; set; }
        public string UPhone { get; set; }
        public string UMailId { get; set; }
        public string UAccountStatus { get; set; }
        public string URole { get; set; }

        public virtual ICollection<LogTable> LogTable { get; set; }
        public virtual ICollection<OrderDetailsTable> OrderDetailsTable { get; set; }
    }
}
