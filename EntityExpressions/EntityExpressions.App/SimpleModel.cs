using EntityExpressions.DAL;
using EntityExpressions.Lib;
using System;

namespace EntityExpressions.App
{
    public class SimpleModel
    {
        [EntityExpression(nameof(SimpleEntity.Id))]
        public Guid Id { get; set; }

        [EntityExpression(nameof(SimpleEntity.Name))]
        public string Name { get; set; }

        [EntityExpression(nameof(SimpleEntity.Description))]
        public string Description { get; set; }
    }
}
