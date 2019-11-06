﻿using System.Data.Entity.ModelConfiguration;

namespace PSS.Configuration
{
    public sealed class PurchaseOrderConfiguration : EntityTypeConfiguration<Models.PurchaseOrder>
    {
        public PurchaseOrderConfiguration()
        {
            HasRequired(o => o.Freight);
            HasRequired(o => o.Payment);
        }
    }
}