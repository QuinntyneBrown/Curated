using System;

namespace Curated.Api.Models
{
    public abstract class CollectionItem
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string CoverImageUrl { get; protected set; }
        public DateTime Created { get; protected set; } = DateTime.UtcNow;
        public DateTime? Deleted { get; protected set; }
    }
}
