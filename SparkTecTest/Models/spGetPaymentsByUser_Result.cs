//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SparkTecTest.Models
{
    using System;
    
    public partial class spGetPaymentsByUser_Result
    {
        public int paymentId { get; set; }
        public string description { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<decimal> ammount { get; set; }
        public int owner { get; set; }
        public Nullable<bool> isSettled { get; set; }
    }
}
