using System;
using Daily.Service.Models.Base;

namespace Daily.Service.Models
{
    public class DailyModel : BaseModel
    {
        public string Yesterday { get; set; }
        public string Today { get; set; }
        public DateTime Date { get; set; }
        public string NotDone { get; set; }
        public string Problems { get; set; }
        public string LinesOfCode { get; set; }
        public Guid UserId { get; set; }
    }
}
