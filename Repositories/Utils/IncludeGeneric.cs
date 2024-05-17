using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fuchonet.Repositories.Utils
{
    public static class IncludeGeneric
    {
        public static IQueryable<T> IncludeRelations<T>(this IQueryable<T> query, string include) where T : class
        {
            var includes = ParseIncludes(include);
            foreach (var includeString in includes)
            {
                query = query.Include(includeString);
            }
            return query;
        }

        private static IEnumerable<string> ParseIncludes(string includes)
        {
            var result = new List<string>();
            var stack = new Stack<char>();
            var currentInclude = new StringBuilder();
            var nestedInclude = new StringBuilder();

            foreach (var c in includes)
            {
                if (c == '[')
                {
                    stack.Push(c);
                    nestedInclude.Append('.');
                }
                else if (c == ']')
                {
                    stack.Pop();
                    currentInclude.Append(nestedInclude);
                    nestedInclude.Clear();
                }
                else if (c == ',' && stack.Count == 0)
                {
                    result.Add(currentInclude.ToString().Trim());
                    currentInclude.Clear();
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        nestedInclude.Append(c);
                    }
                    else
                    {
                        currentInclude.Append(c);
                    }
                }
            }

            if (currentInclude.Length > 0)
            {
                result.Add(currentInclude.ToString().Trim());
            }

            return result;
        }

        
    }
}