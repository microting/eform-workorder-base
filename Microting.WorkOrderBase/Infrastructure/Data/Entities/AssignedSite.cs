using Microting.WorkOrderBase.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Microting.WorkOrderBase.Infrastructure.Data.Entities
{
    public class AssignedSite : PnBase
    {
        public int SiteId { get; set; }
    }
}
