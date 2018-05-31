using System;
using System.Linq;

//https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-2.1
namespace EntityExpressionsCore.DAL
{
    public static class DbInitializer {
        public static void Initialize(EntityExpressionContext context)
        {
            context.Database.EnsureCreated();

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
