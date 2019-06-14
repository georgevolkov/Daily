using System;
using Daily.Service.Models;
using Daily.Data.Enums;
using Daily.Service.Interfaces;
using Daily.Service.Query;
using System.Linq;
using AutoMapper;
using Daily.Data.Interfaces;
using System.Threading.Tasks;
using Daily.Service.Extensions;

namespace Daily.Service
{
    public class DailyService : BaseQueryService<Data.Entities.Daily, DailyModel, SortType>, IDailyService
    {
        public DailyService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public async Task AddDailyAsync(DailyModel dailyModel)
        {
            var daily = _uow.GetRepository<Data.Entities.Daily>().All().FirstOrDefault(x => x.Yesterday == dailyModel.Yesterday && x.Today == dailyModel.Today
                                                                            && x.UserId == dailyModel.UserId);
            if(daily != null)
            {
                throw new NotImplementedException();
            }

            daily = _mapper.Map<Data.Entities.Daily>(dailyModel);
            await _uow.GetRepository<Data.Entities.Daily>().InsertAsync(daily);
            await _uow.SaveChangesAsync();
        }

        public Task<DailyModel> EditDailyAsync(DailyModel dailyModel)
        {
            throw new NotImplementedException();
        }

        public async Task<DailyModel> GetDailyByIdAsync(Guid id)
        {
            var daily = await _uow.GetRepository<Data.Entities.Daily>().GetByIdAsync(id);
            return _mapper.Map<DailyModel>(daily);
        }

        protected override IQueryable<Data.Entities.Daily> Order(IQueryable<Data.Entities.Daily> items, bool isFirst, QueryOrder<SortType> order)
        {
            switch (order.OrderType)
            {
                case SortType.Date:
                    return items.OrderWithDirectionBy(isFirst, order.Direction, x => x.Date);
            }

            throw new ArgumentOutOfRangeException(nameof(order.OrderType));
        }

        protected override IQueryable<Data.Entities.Daily> Paging(IQueryable<Data.Entities.Daily> items, int? start, int? length)
        {
            return items.Skip(start.Value).Take(length.Value);
        }

        protected override IQueryable<Data.Entities.Daily> Search(IQueryable<Data.Entities.Daily> items, QuerySearch search)
        {
            if (!string.IsNullOrEmpty(search?.Value))
            {
                return items.Where(x => x.Yesterday.Contains(search.Value));
            }
            return items;
        }

        protected override IQueryable<Data.Entities.Daily> UserDailies(IQueryable<Data.Entities.Daily> items,
            QueryUser userId)
        {
            return items.Where(x => x.UserId == userId.Value);
        }
    }
}
