using System;
using System.Collections.Generic;
using System.Text;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.WorkOrderBase.Infrastructure.Data.Entities
{
    public class AssignedSiteVersion : BaseEntity
    {
        public int SiteId { get; set; }
    }
}
