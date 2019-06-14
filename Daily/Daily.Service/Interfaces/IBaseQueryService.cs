using Questionnaire.Data.Interfaces;
using Questionnaire.Service.Query;
using System.Threading.Tasks;

namespace Questionnaire.Service.Interfaces
{
    public interface IBaseQueryService<TEntity, TModel, TSortType>
        where TEntity : class, IEntityBase, new()
    {
        Task<QueryResponse<TModel>> GetAsync(QueryRequest<TSortType> query);
    }
}
