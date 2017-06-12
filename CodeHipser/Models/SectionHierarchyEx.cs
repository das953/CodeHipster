using CodeHipser.Models.EntityBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models
{
    public static class SectionHierarchyEx
    {
        // Y Combinator generic implementation
        private delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);
        private static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f)
        {
            Recursive<A, R> rec = r => a => f(r(r))(a);
            return rec(rec);
        }

        // Extension method for IEnumerable<Section>
        public static IEnumerable<Section> Traverse(this IEnumerable<Section> source, Func<Section, bool> predicate)
        {
            var traverse = SectionHierarchyEx.Y<IEnumerable<Section>, IEnumerable<Section>>(
            f => items =>
            {
                var r = new List<Section>(items.Where(predicate));
                r.AddRange(items.SelectMany(i => f(i.Children)));
                return r;
            });

            return traverse(source);
        }
    }
}
