using Spa.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Spa.Data.Configurations
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntityBase
    {
        public EntityBaseConfiguration()
        {
            HasKey(s => s.Id);
        }
    }
}
