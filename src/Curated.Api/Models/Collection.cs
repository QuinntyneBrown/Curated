using System;
using System.Collections.Generic;

namespace Curated.Api.Models
{
    public abstract class Collection<T>
        where T: CollectionItem
    {
        public List<T> Items { get; } = new List<T>();
        public DateTime Created { get; protected set; } = DateTime.UtcNow;
        public DateTime? Deleted { get; protected set; }
        public string CoverImageUrl { get; protected set; }
    }
}
