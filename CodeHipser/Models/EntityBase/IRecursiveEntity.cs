using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.EntityBase
{
    public interface IRecursiveEntity<TEntity> where TEntity : IEntity
    {
        int? ParentId { get; set; }
        TEntity Parent { get; set; }
        ICollection<TEntity> Children { get; set; }
    }
}
