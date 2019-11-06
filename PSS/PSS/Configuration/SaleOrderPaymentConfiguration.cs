using System.Data.Entity.ModelConfiguration;

namespace PSS.Configuration
{
    public sealed class SaleOrderPaymentConfiguration : EntityTypeConfiguration<Models.SaleOrderPayment>
    {
        public SaleOrderPaymentConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("SaleOrderPayments");
            });
        }
    }
}