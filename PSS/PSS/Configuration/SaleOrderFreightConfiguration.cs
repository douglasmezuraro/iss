using System.Data.Entity.ModelConfiguration;

namespace PSS.Configuration
{
    public sealed class SaleOrderFreightConfiguration : EntityTypeConfiguration<Models.SaleOrderFreight>
    {
        public SaleOrderFreightConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable(nameof(SGCO.Context.DBContext.SaleOrderFreights));
            });
        }
    }
}