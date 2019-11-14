using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PSS.Utils.Extensions
{
    public static class DbEntityEntryExtension
    {
        public static void DetachAllBut<TEntity>(this DbEntityEntry<TEntity> entry) where TEntity : class
        {   

        }
    }
}