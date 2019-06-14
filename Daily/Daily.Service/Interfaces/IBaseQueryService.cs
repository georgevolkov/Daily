using Daily.Data.Interfaces;
using Daily.Service.Query;
using System.Threading.Tasks;

namespace Daily.Service.Interfaces
{
    public interface IBaseQueryService<TEntity, TModel, TSortType>
        where TEntity : class, IEntityBase, new()
    {
        Task<QueryResponse<TModel>> GetAsync(QueryRequest<TSortType> query);
    }
}
