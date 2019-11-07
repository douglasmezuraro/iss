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
                    m.ToTable(nameof(SGCO.Context.DBContext.PurchaseOrderFreights));
                });
        }
    }
}