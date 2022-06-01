using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace SqlSugar.Extra
{
    public class SqlSugarEntityFluent<T>
    {
        internal SugarTable SugarTable { get; } = new SugarTable(typeof(T).Name);


        internal Dictionary<PropertyInfo, SugarColumn> Columns { get; } = new Dictionary<PropertyInfo, SugarColumn>();


        internal SqlSugarEntityFluent()
        {
        }

        public SqlSugarEntityFluent<T> TableName(string val)
        {
            SugarTable.TableName = val;
            return this;
        }

        public SqlSugarEntityFluent<T> TableDescription(string val)
        {
            SugarTable.TableDescription = val;
            return this;
        }

        public SqlSugarEntityFluent<T> IsDisabledDelete(bool val = true)
        {
            SugarTable.IsDisabledDelete = val;
            return this;
        }

        public SqlSugarEntityFluent<T> IsDisabledUpdateAll(bool val = true)
        {
            SugarTable.IsDisabledUpdateAll = val;
            return this;
        }

        public SqlSugarColumnFluent Property<TProperty>(Expression<Func<T, TProperty>> selector)
        {
            MemberInfo memberInfo = FindMember(selector);
            SqlSugarColumnFluent sqlSugarColumnFluent = new SqlSugarColumnFluent();
            if (memberInfo is PropertyInfo propertyInfo)
            {
                sqlSugarColumnFluent.SugarColumn.ColumnName = propertyInfo.Name;
                Columns[propertyInfo] = sqlSugarColumnFluent.SugarColumn;
                return sqlSugarColumnFluent;
            }
            throw new ArgumentException("只能对属性进行配置");
            static MemberInfo FindMember(Expression expression)
            {
                Expression expression3;
                while (true)
                {
                    Expression expression2 = expression;
                    expression3 = expression2;
                    if (!(expression3 is UnaryExpression unaryExpression))
                    {
                        if (!(expression3 is LambdaExpression lambdaExpression))
                        {
                            break;
                        }
                        expression = lambdaExpression.Body;
                    }
                    else
                    {
                        expression = unaryExpression.Operand;
                    }
                }
                if (!(expression3 is MemberExpression memberExpression))
                {
                    throw new Exception("配置只支持类型自身定义或静态属性与字段");
                }
                if (memberExpression.Expression != null && memberExpression.Expression!.NodeType == ExpressionType.Parameter && memberExpression.Expression!.NodeType == ExpressionType.Convert)
                {
                    throw new ArgumentException("selector", "表达式必须为顶层级别的成员访问");
                }
                return memberExpression.Member;
            }
        }
    }
}
