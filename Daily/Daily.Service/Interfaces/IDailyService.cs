using System;
using System.Collections.Generic;
using System.Text;
using Daily.Data.Entities;
using Daily.Service.Models;
using Daily.Data.Enums;
using System.Threading.Tasks;

namespace Daily.Service.Interfaces
{
    public interface IDailyService : IBaseQueryService<Data.Entities.Daily, DailyModel, SortType>
    {
        Task AddDailyAsync(DailyModel dailyModel);
        Task<DailyModel> GetDailyByIdAsync(Guid id);
        Task<DailyModel> EditDailyAsync(DailyModel dailyModel);
    }
}
