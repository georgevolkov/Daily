using System;
using Daily.Data.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Daily.Data.Entities
{
    public class Daily : EntityBase<Guid>
    {
        public string Yesterday { get; set; }
        public string Today { get; set; }
        public DateTime Date { get; set; }
        public string NotDone { get; set; } = "Нет";
        public string Problems { get; set; } = "Нет";
        public string LinesOfCode { get; set; } = "Нет";
        public Guid UserId { get; set; }
    }
}
