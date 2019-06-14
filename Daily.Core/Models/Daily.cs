using System;

namespace Daily.Core.Models
{
    public class Daily : Entity
    {
        public string Before { get; set; }
        public string After { get; set; }
        public DateTime Date { get; set; }
    }
}
