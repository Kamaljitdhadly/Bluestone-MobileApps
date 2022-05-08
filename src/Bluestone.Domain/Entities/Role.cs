using System;
using System.Collections.Generic;

namespace Bluestone.Domain.Entities
{
    public class Role : AggregateRoot<Guid>
    {
        public virtual string Name { get; set; }

        public virtual string NormalizedName { get; set; }

        public virtual string ConcurrencyStamp { get; set; }
    }
}
