using Microting.WorkOrderBase.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microting.WorkOrderBase.Infrastructure.Data.Entities
{
    public class WorkOrder : PnBase
    {
        public string Description { get; set; }
        public DateTime CorrectedAtLatest { get; set; }
        public DateTime DoneAt { get; set; }
        public int DoneBySiteId { get; set; }
        public string DescriptionOfTaskDone { get; set; }
    }
}
