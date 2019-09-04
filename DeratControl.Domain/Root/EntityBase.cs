using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Domain.Root
{
    public abstract class EntityBase<TKey> where TKey : struct
    {
        public virtual TKey Id { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime CreatedAt { get; set; }
    }
}
 