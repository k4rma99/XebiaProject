
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace BookStoreApiV2.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;

    public partial class Book
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Book()
    {

        this.OrderDetails = new HashSet<OrderDetail>();

    }


    public int bId { get; set; }

    public string bName { get; set; }

    public Nullable<int> cId { get; set; }

    public Nullable<int> aId { get; set; }

    public string bISBN { get; set; }

    public double bPrice { get; set; }

    public string bDescription { get; set; }

    public int bPosition { get; set; }

    public string bStatus { get; set; }

        [DisplayName("Upload Image")]
        public string bImage { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public int bQuantity { get; set; }
        



        public virtual Author Author { get; set; }

    public virtual Category Category { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }

}

}
