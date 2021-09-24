using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Database
{
    public static class Sort
    {
        public static List<Ordering<T>> ByAsc<T>(Expression<Func<T, object>> expression) => 
            new List<Ordering<T>>() { new Ascending<T>(expression) };
        public static List<Ordering<T>> ByDesc<T>(Expression<Func<T, object>> expression) => 
            new List<Ordering<T>>() { new Descending<T>(expression) };
        public static List<Ordering<T>> ThenByAsc<T>(this List<Ordering<T>> ordering, Expression<Func<T, object>> expression)
        {
            var newOrdering = new List<Ordering<T>>();
            newOrdering.AddRange(ordering);
            newOrdering.Add(new Ascending<T>(expression));
            return newOrdering;
        }
        public static List<Ordering<T>> ThenByDesc<T>(this List<Ordering<T>> ordering, Expression<Func<T, object>> expression)
        {
            var newOrdering = new List<Ordering<T>>();
            newOrdering.AddRange(ordering);
            newOrdering.Add(new Descending<T>(expression));
            return newOrdering;
        }
    }

    public abstract record Ordering<T>();
    public record Ascending<T>(Expression<Func<T, object>> Expression) : Ordering<T>();
    public record Descending<T>(Expression<Func<T, object>> Expression) : Ordering<T>();
}
