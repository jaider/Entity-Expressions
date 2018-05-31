using EntityExpressionsCore.DAL;
using EntityExpressionsCore.Lib;
using System;
using System.Linq;

namespace EntityExpressionsCore.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EntityExpressionContext();
            DbInitializer.Initialize(context);

            var simpleModels = context.SimpleEntities
                .Select(EntityExpressionHelper.CreateLambda<SimpleEntity, SimpleModel>())
                .ToList();

            var complexModels = context.ComplexEntities
                .Select(EntityExpressionHelper.CreateLambda<ComplexEntity, ComplexModel>())
                .ToList();
        }
    }
}

/* SQL Generated

     SELECT [p0].[Id], [p0].[Name], [p0].[Description]
FROM [SimpleEntities] AS [p0]
     


    SELECT [p0].[Id], [p0].[Property1Id] AS [Id0], [p0.Property1].[Name], [p0.Property1].[Description], [p0].[Property2Id] AS [Id1], [p0.Property2].[Name] AS [Name0], [p0.Property2].[Description] AS [Description0]
FROM [ComplexEntities] AS [p0]
LEFT JOIN [SimpleEntities] AS [p0.Property2] ON [p0].[Property2Id] = [p0.Property2].[Id]
LEFT JOIN [SimpleEntities] AS [p0.Property1] ON [p0].[Property1Id] = [p0.Property1].[Id]
     */
