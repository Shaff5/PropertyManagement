//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyManagement.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class HistoryHeader
    {
        public HistoryHeader()
        {
            this.HistoryDetails = new HashSet<HistoryDetail>();
        }
    
        public long HistoryHeaderId { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
    
        public virtual ICollection<HistoryDetail> HistoryDetails { get; set; }
    }
}
