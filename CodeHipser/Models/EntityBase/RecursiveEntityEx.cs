using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodeHipser.Models.EntityBase
{
    public static class RecursiveEntityEx
    {
        public static TEntity AddChild<TEntity>(this TEntity parent, TEntity child)
            where TEntity : RecursiveEntity<TEntity>
        {
            child.Parent = parent;
            if (parent.Children == null)
                parent.Children = new List<TEntity>();
            parent.Children.Add(child);
            return parent;
        }

        public static TEntity AddChildren<TEntity>(this TEntity parent, IEnumerable<TEntity> children)
        where TEntity : RecursiveEntity<TEntity>
        {
            children.ToList().ForEach(c => parent.AddChild(c));
            return parent;
        }

        public static IEnumerable<TEntity> GetHierarchy<TEntity>(this IQueryable<TEntity> hierarchy, Func<TEntity, bool> rootPredicate)
        where TEntity : RecursiveEntity<TEntity>
        {
            IEnumerable<TEntity> children = hierarchy?.Include(c => c.Children)?.Where(rootPredicate).ToList();
            if(children!=null)
            {
                foreach (var item in children)
                {
                    yield return item;
                    if (item.Children.Any())
                    {
                        foreach (var child in GetHierarchy<TEntity>(hierarchy, x => x.ParentId == item.Id))
                        {
                            yield return child;
                        }
                    }
                }
            }
        }
    }
}
