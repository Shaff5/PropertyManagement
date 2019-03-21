using System;
using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public partial class HistoryHeader
    {
        public HistoryHeader()
        {
            HistoryDetail = new HashSet<HistoryDetail>();
        }

        public long HistoryHeaderId { get; set; }
        public string TableName { get; set; }
        public int RecordId { get; set; }
        public string Action { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<HistoryDetail> HistoryDetail { get; set; }
    }
}
