//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoeStore.Models
{
    using System;
    
    public partial class GetCartOfUser_Result
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ProductCategory { get; set; }
        public Nullable<double> ProductPrice { get; set; }
        public string CategoryName { get; set; }
        public Nullable<double> SizeValue { get; set; }
        public string ColorName { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageExtension { get; set; }
        public Nullable<int> Quantity { get; set; }
    }
}