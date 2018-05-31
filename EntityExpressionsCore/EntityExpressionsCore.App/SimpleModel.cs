using EntityExpressionsCore.DAL;
using EntityExpressionsCore.Lib;
using System;

namespace EntityExpressionsCore.App
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
