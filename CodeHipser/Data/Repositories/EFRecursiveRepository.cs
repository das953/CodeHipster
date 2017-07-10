using CodeHipser.Data.Repositories.Abstract;
using CodeHipser.Models.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CodeHipser.Data.Repositories
{
    public class EFRecursiveRepository<TEntity> : EFRepository<TEntity> where TEntity : RecursiveEntity<TEntity>
    {
        public EFRecursiveRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Remove(TEntity entity)
        {
            var children = Context.Set<TEntity>().Where(x => x.ParentId == entity.Id);
            if (children != null && children.Any())
            {
                foreach (var child in children)
                {
                    Remove(child);
                    Context.Set<TEntity>().Remove(child);
                }
            }
            Context.Set<TEntity>().Remove(entity);
        }

        public override void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
