using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApiV2.Models
{
    public class ExtendedClasses
    {
    }

    public partial class Book
    {
        public HttpPostedFileBase ImageFile { get; set; }
    }

    public partial class Category
    {
        public HttpPostedFileBase ImageFile { get; set; }
    }
}