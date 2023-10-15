using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise13
{
      public static class CustomExtensions
        {
            
        public static bool CustomAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            {
                foreach (T element in source)
                {
                    if (!predicate(element))
                    {
                        return false;
                    }
                }
                return true;
            }

        
        public static bool CustomAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            {
                foreach (T element in source)
                {
                    if (predicate(element))
                    {
                        return true;
                    }
                }
                return false;
            }
         
        
        public static T CustomMax<T>(this IEnumerable<T> source, Func<T, T, int> comparer)
            {
                if (source == null)
                {
                    throw new ArgumentNullException(nameof(source));
                }
                if (comparer == null)
                {
                    throw new ArgumentNullException(nameof(comparer));
                }
                if (!source.Any())
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                T max = source.First(); foreach (T element in source.Skip(1))
                {
                    if (comparer(element, max) > 0)
                    {
                        max = element;
                    }
                }
                return max;
            }
       
        
        public static T CustomMin<T>(this IEnumerable<T> source, Func<T, T, int> comparer)
            {
                if (source == null)
                {
                    throw new ArgumentNullException(nameof(source));
                }
                if (comparer == null)
                {
                    throw new ArgumentNullException(nameof(comparer));
                }
                if (!source.Any())
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                T min = source.First(); foreach (T element in source.Skip(1))
                {
                    if (comparer(element, min) < 0)
                    {
                        min = element;
                    }
                }
                return min;
            }
        
        
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            {
                foreach (T element in source)
                {
                    if (predicate(element))
                    {
                        yield return element;
                    }
                }
            }
          
        
        public static IEnumerable<TResult> CustomSelect<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
            {
                foreach (T element in source)
                {
                    yield return selector(element);
                }
            }
        }
    }

