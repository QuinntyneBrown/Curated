using System;
using System.Collections.Generic;

namespace Curated.Api.Models
{
    public abstract class Collection<T>
        where T: CollectionItem
    {
        public List<T> Items { get; } = new List<T>();
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime? Deleted { get; private set; }
    }
}
