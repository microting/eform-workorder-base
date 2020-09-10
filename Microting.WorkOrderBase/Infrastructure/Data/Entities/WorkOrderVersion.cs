using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Microting.WorkOrderBase.Infrastructure.Data.Entities
{
    public class WorkOrderVersion : BaseEntity
    {
        public string Description { get; set; }
        public DateTime CorrectedAtLatest { get; set; }
        public DateTime DoneAt { get; set; }
        public int DoneBySiteId { get; set; }
        public string DescriptionOfTaskDone { get; set; }

        [ForeignKey("WorkOrder")]
        public int WorkOrderId { get; set; }
    }
}
