using Questionnaire.Data.Entities.Base;
using Questionnaire.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Data.Entities
{
    public class Answer : EntityBase<Guid>
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
