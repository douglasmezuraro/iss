using System.Data.Entity.ModelConfiguration;

namespace PSS.Context.Configuration
{
    public sealed class PurchaseOrderConfiguration : EntityTypeConfiguration<Models.PurchaseOrder>
    {
        public PurchaseOrderConfiguration()
        {
            HasRequired(o => o.Freight);
        }
    }
}