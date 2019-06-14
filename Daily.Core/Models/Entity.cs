using System.Collections.Generic;

namespace Daily.Core.Models
{
    public class Entity : IEqualityComparer<Entity>
    {
        public long Id { get; set; }

        public bool Equals(Entity x, Entity y)
        {
            if (ReferenceEquals(null, x) || ReferenceEquals(null, y)) return false;
            return ReferenceEquals(x, y);
        }

        public int GetHashCode(Entity obj)
        {
            return obj.GetHashCode();
        }
    }
}
