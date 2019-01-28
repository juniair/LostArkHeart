using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkHeart.Core.Entities
{
    public class Database : DbContext
    {

        public override int SaveChanges()
        {
            UpdateTime();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            UpdateTime();
            return base.SaveChangesAsync();
        }

        private void UpdateTime()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is Base.EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var data = (entity.Entity as Base.EntityBase);
                if (entity.State == EntityState.Added)
                {
                    data.CreatedTime = DateTime.UtcNow;
                }

                data.ModifiedTime = DateTime.UtcNow;
            }
        }
    }
}
