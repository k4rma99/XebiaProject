
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
    
public partial class Order
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Order()
    {

        this.OrderDetails = new HashSet<OrderDetail>();

    }


    public int oId { get; set; }

    public Nullable<int> uId { get; set; }

    public Nullable<System.DateTime> orDateAndTime { get; set; }

    public Nullable<int> orCouponId { get; set; }



    public virtual Coupon Coupon { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    public virtual User User { get; set; }

}

}
