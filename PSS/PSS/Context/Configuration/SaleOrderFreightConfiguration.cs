using System.Data.Entity.ModelConfiguration;

namespace PSS.Context.Configuration
{
    public sealed class SaleOrderFreightConfiguration : EntityTypeConfiguration<Models.SaleOrderFreight>
    {
        public SaleOrderFreightConfiguration()
        {
            Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("PurchaseOrderFreights");
                });
        }
    }
}