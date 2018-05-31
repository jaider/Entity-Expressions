using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EntityExpressionsCore.Lib
{
    public static class EntityExpressionHelper
    {
        public static MemberInitExpression CreateInitExpression<TModel>(Expression parameterExp) //ParameterExpression or MemberExpression
            where TModel : class, new()
            => CreateInitExpression(typeof(TModel), parameterExp);

        public static MemberInitExpression CreateInitExpression(Type modelType, Expression parameterExp) //ParameterExpression or MemberExpression
        {
            var properties = modelType.GetProperties();
            var members = new List<MemberAssignment>(properties.Length);
            foreach (var prop in properties) {
                Attribute attribute = Attribute.GetCustomAttributes(prop).FirstOrDefault(a => a is EntityExpressionAttribute);
                if (attribute != null) {
                    var attr = attribute as EntityExpressionAttribute;
                    MemberAssignment member;
                    var exp = Expression.Property(parameterExp, attr.Path[0]);
                    foreach (var from in attr.Path.Skip(1)) {
                        exp = Expression.Property(exp, from);
                    }

                    if (attr.IsComplex) {
                        var toModelType = prop.PropertyType;
                        member = Expression.Bind(prop, CreateInitExpression(toModelType, exp));
                    }
                    else {
                        member = Expression.Bind(prop, exp);
                    }
                    members.Add(member);
                }
            }

            return Expression.MemberInit(Expression.New(modelType), members);
        }

        public static Expression<Func<TEntity, TModel>> CreateLambda<TEntity, TModel>()
            where TEntity : class //Entity
            where TModel : class, new()
        {
            var parameterExp = Expression.Parameter(typeof(TEntity), "p0");
            var body = CreateInitExpression<TModel>(parameterExp);
            return Expression.Lambda<Func<TEntity, TModel>>(body, parameterExp);
        }
    }
}
