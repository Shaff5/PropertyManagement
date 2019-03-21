using System;
using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public partial class HistoryDetail
    {
        public long HistoryDetailId { get; set; }
        public long HistoryHeaderId { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public virtual HistoryHeader HistoryHeader { get; set; }
    }
}
