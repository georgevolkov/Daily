using AutoMapper;
using Questionnaire.Data.Entities;
using Questionnaire.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Common.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Answer, AnswerModel>(MemberList.None).ReverseMap();
        }
    }
}
