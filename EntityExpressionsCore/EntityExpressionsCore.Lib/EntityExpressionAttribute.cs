using System;

namespace EntityExpressionsCore.Lib
{
    public class EntityExpressionAttribute : Attribute
    {
        public string[] Path { get; set; }

        public bool IsComplex { get; set; }

        public EntityExpressionAttribute(params string[] path)
        {
            Path = path;
        }
    }
}
