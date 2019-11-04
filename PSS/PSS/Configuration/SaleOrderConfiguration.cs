using System.Data.Entity.ModelConfiguration;

namespace PSS.Configuration
{
    public sealed class SaleOrderConfiguration : EntityTypeConfiguration<Models.SaleOrder>
    {
        public SaleOrderConfiguration()
        {
            HasRequired(o => o.Freight);
        }
    }
}