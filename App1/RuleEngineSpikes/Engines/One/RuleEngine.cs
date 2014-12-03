using System;
using System.Linq.Expressions;

namespace RuleEngineSpikes.Engines.One
{
    public class RuleEngine
    {
        public Func<T, bool> CompileRule<T>(Rule rule)
        {
            if (string.IsNullOrEmpty(rule.PropertyName))
            {
                var expressionBuilder = new ExpressionBuilder();
                var param = Expression.Parameter(typeof(T));
                var expression = expressionBuilder.BuildExpression<T>(rule.Operator_, rule.Value, param);
                var func = Expression.Lambda<Func<T, bool>>(expression, param).Compile();

                return func;
            }
            else
            {
                var expressionBuilder = new ExpressionBuilder();
                var param = Expression.Parameter(typeof(T));
                var expression = expressionBuilder.BuildExpression<T>(rule.PropertyName, rule.Operator_, rule.Value, param);
                var func =Expression.Lambda<Func<T, bool>>(expression, param).Compile();

                return func;
            }
        }
    }
}