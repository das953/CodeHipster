using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Models.EntityBase
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
