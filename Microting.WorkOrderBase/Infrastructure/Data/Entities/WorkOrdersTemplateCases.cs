using Microting.WorkOrderBase.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microting.WorkOrderBase.Infrastructure.Data.Entities
{
    public class WorkOrdersTemplateCases : PnBase
    {
        public int MicrotingId { get; set; }
        public int WorkOrderId { get; set; }
        public int CaseId { get; set; }
    }
}
