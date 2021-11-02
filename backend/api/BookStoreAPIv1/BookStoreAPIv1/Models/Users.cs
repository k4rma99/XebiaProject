using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class Users
    {
        public Users()
        {
            Logs = new HashSet<Logs>();
            OrderDetails = new HashSet<OrderDetails>();
            Orders = new HashSet<Orders>();
            UserAddresses = new HashSet<UserAddresses>();
        }

        public int UId { get; set; }
        public string UFname { get; set; }
        public string ULname { get; set; }
        public string UPhone { get; set; }
        public string UMailId { get; set; }
        public string UPassword { get; set; }
        public string UAccountStatus { get; set; }
        public string URole { get; set; }

        public virtual ICollection<Logs> Logs { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }
    }
}
