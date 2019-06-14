using System;
using Daily.Service.Models.Base;

namespace Daily.Service.Models
{
    public class DailyModel : BaseModel
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
