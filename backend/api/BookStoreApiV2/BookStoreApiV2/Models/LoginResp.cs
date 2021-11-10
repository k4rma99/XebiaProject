using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApiV2.Models
{
    public class LoginResp
    {
        public string token { get; set; }
        public string role { get; set; }
        public int id { get; set; }
    }
}