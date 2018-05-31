using EntityExpressions.DAL;
using EntityExpressions.Lib;
using System.Linq;

namespace EntityExpressions.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EntityExpressionContext();
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

SELECT 
    1 AS [C1], 
    [Extent1].[Id] AS [Id], 
    [Extent1].[Name] AS [Name], 
    [Extent1].[Description] AS [Description]
    FROM [dbo].[SimpleEntities] AS [Extent1]



SELECT 
    1 AS [C1], 
    [Extent1].[Id] AS [Id], 
    [Extent1].[Property1_Id] AS [Property1_Id], 
    [Extent2].[Name] AS [Name], 
    [Extent2].[Description] AS [Description], 
    [Extent1].[Property2_Id] AS [Property2_Id], 
    [Extent3].[Name] AS [Name1], 
    [Extent3].[Description] AS [Description1]
    FROM   [dbo].[ComplexEntities] AS [Extent1]
    LEFT OUTER JOIN [dbo].[SimpleEntities] AS [Extent2] ON [Extent1].[Property1_Id] = [Extent2].[Id]
    LEFT OUTER JOIN [dbo].[SimpleEntities] AS [Extent3] ON [Extent1].[Property2_Id] = [Extent3].[Id]

     */
