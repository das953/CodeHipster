using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.EntityBase
{
    public abstract class RecursiveEntity<TEntity> : Entity, IRecursiveEntity<TEntity>
    where TEntity : RecursiveEntity<TEntity>
    {
        public int? ParentId { get; set; }
        public virtual TEntity Parent { get; set; }
        public virtual ICollection<TEntity> Children { get; set; }
    }
}
