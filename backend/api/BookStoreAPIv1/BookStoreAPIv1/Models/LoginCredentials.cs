using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class LoginCredentials
    {
        public string UMailId { get; set; }
        public string UPassword { get; set; }
        public int UId { get; set; }
        public string URole { get; set; }
    }
}
