using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.WorkOrderBase.Infrastructure.Data.Entities
{
    public class WorkOrdersTemplateCaseVersion : BaseEntity
    {
        public int CaseId { get; set; }
        public int CaseMicrotingUid { get; set; }
        public int CheckId { get; set; }
        public int CheckMicrotingUid { get; set; }
        public int WorkOrderId { get; set; }
        public int SdkSiteMicrotingUid { get; set; }

    }
}