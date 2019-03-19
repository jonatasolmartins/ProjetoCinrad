using System;
using System.Collections.Generic;
using System.Text;

namespace Cinrad.Core.Entity
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
    }
}
