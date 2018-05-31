using System;
using System.Data.Entity;
using System.Linq;

//http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx
namespace EntityExpressions.DAL
{
    public class DbInitializer : CreateDatabaseIfNotExists<EntityExpressionContext>
    {
        protected override void Seed(EntityExpressionContext context)
        {
            Initialize(context);
            base.Seed(context);
        }

        public static void Initialize(EntityExpressionContext context)
        {
            // Look for any students.
            if (context.ComplexEntities.Any()) {
                return;   // DB has been seeded
            }

            var complexEntities = new ComplexEntity[]
            {
                new ComplexEntity{
                    Id = Guid.NewGuid(),
                    Property1 = new SimpleEntity(){ Id = Guid.NewGuid(), Name="Property1", Description="ComplexEntity1" },
                    Property2 = new SimpleEntity(){ Id = Guid.NewGuid(), Name="Property2", Description="ComplexEntity1" }
                },
                new ComplexEntity{
                    Id = Guid.NewGuid(),
                    Property1 = new SimpleEntity(){ Id = Guid.NewGuid(), Name="Property1", Description="ComplexEntity2" },
                    Property2 = new SimpleEntity(){ Id = Guid.NewGuid(), Name="Property2", Description="ComplexEntity2" }
                },
                new ComplexEntity{
                    Id = Guid.NewGuid(),
                    Property1 = new SimpleEntity(){ Id = Guid.NewGuid(), Name="Property1", Description="ComplexEntity3" },
                    Property2 = new SimpleEntity(){ Id = Guid.NewGuid(), Name="Property2", Description="ComplexEntity3" }
                },
            };

            foreach (var entity in complexEntities) {
                context.ComplexEntities.Add(entity);
            }

            context.SaveChanges();
        }
    }
}
