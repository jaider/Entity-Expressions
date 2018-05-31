using System.Data.Entity;

namespace EntityExpressions.DAL
{
    public class EntityExpressionContext : DbContext
    {
        public DbSet<SimpleEntity> SimpleEntities { get; set; }
        public DbSet<ComplexEntity> ComplexEntities { get; set; }

        public EntityExpressionContext()
          : base(@"Data Source=localhost;Initial Catalog=EntityExpressionEF6Db;
                       Integrated Security=True;")
        {
            Database.SetInitializer(new DbInitializer());
        }
    }
}
