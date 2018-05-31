using Microsoft.EntityFrameworkCore;

namespace EntityExpressionsCore.DAL
{
    public class EntityExpressionContext : DbContext
    {
        public DbSet<SimpleEntity> SimpleEntities { get; set; }
        public DbSet<ComplexEntity> ComplexEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                if (optionsBuilder.IsConfigured == false) {
                    optionsBuilder.UseSqlServer(
                   @"Data Source=localhost;Initial Catalog=EntityExpressionDb;
                       Integrated Security=True;");
                }
                base.OnConfiguring(optionsBuilder);
            }
        }
        //public EntityExpressionContext(DbContextOptions<EntityExpressionContext> options)
        //  : base(options) { }
    }
}
