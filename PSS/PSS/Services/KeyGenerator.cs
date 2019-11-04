using SGCO.Context;
using System.Linq;

namespace PSS.Services
{
    public static class KeyGenerator
    {
        public static int Generate<TEntity>() where TEntity : Models.Base
        {
            DBContext db = new DBContext();

            int? value = db.Set<TEntity>().Max(e => (int?)e.Id);

            return value++ ?? 1;
        }
    }
}