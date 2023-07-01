using System;
using System.Collections.Generic;
using System.Linq;

namespace HappyFarm.Entities.Sources._0_Utils.Extensions
{
    public static partial class Extensions
    {
        public static IEnumerable<T> Diff<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T,T, bool> comparer)
        {
            List<T> result = new List<T>();
            List<T> targetList = target.ToList();

            foreach (var item in source)
            {
                var sameItem = targetList.FirstOrDefault(targetItem => comparer.Invoke(targetItem, item));
                
                if (sameItem == null)
                    result.Add(item);
                else
                    targetList.Remove(sameItem);
            }

            result.AddRange(targetList);
            
            return result;
        }
    }
}