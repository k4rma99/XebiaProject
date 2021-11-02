using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class UserAddresses
    {
        public int Id { get; set; }
        public int? UId { get; set; }
        public string UAddressLineOne { get; set; }
        public string UAddressLineTwo { get; set; }
        public string ULandMark { get; set; }
        public string UCity { get; set; }
        public string UState { get; set; }
        public string UCountry { get; set; }
        public string UPincode { get; set; }

        public virtual Users U { get; set; }
    }
}
