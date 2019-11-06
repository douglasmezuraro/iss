using System.Data.Entity.ModelConfiguration;

namespace PSS.Configuration
{
    public sealed class PurchaseOrderPaymentConfiguration : EntityTypeConfiguration<Models.PurchaseOrderPayment>
    {
        public PurchaseOrderPaymentConfiguration()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PurchaseOrderPayments");
            });
        }
    }
}