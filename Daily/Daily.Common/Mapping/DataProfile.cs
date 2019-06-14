using AutoMapper;
using Daily.Service.Models;

namespace Daily.Common.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Data.Entities.Daily, DailyModel>(MemberList.None).ReverseMap();
        }
    }
}
