using Questionnaire.Service.Models.Base;
using Questionnaire.Data.Enums;
using System;

namespace Questionnaire.Service.Models
{
    public class AnswerModel : BaseModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public Status Status { get; set; }
        public bool IsLikeProgramming { get; set; }
        public Guid? UserId { get; set; }
    }
}
