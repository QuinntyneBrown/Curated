using System;
using System.Collections.Generic;

namespace Curated.Api.Features
{
    public abstract class CollectionDto<T>
    {        
        public List<T> Items { get; set; }
        public DateTime Created { get; set; }
    }
}
