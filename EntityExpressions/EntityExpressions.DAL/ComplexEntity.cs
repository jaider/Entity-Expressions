using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityExpressions.DAL
{
    public class ComplexEntity
    {
        public Guid Id { get; set; }

        public SimpleEntity Property1 { get; set; }

        public SimpleEntity Property2 { get; set; }
    }
}
