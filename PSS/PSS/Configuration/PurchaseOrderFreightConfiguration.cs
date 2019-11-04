using System.Data.Entity.ModelConfiguration;

namespace PSS.Configuration
{
    public sealed class PurchaseOrderFreightConfiguration : EntityTypeConfiguration<Models.PurchaseOrderFreight>
    {
        public PurchaseOrderFreightConfiguration()
        {
            Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("PurchaseOrderFreights");
                });
        }
    }
}