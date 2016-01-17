using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DarkSeng.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// This method will get the name of a property. Can be used for INotifyPropertyChanged
        /// </summary>
        /// <typeparam name="TClass">The class of the Property</typeparam>
        /// <param name="propertyLambda">The Property Lambda expression. Bsp x => x.Name</param>
        /// <returns>The Name of the Property as a string</returns>
        /// <exception cref="ArgumentNullException">This gets thrown if the Lambda expression contains anything but a Property</exception>
        public static string GetPropertyName<TClass>(this object obj, Expression<Func<TClass, object>> propertyLambda)
        {
            LambdaExpression lambda = propertyLambda as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr.Member.Name;
        }

    }
}
