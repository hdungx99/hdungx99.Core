using hdungx99.Core.EF.Entity;
using hdungx99.Core.EF.Models;
using System.Linq.Expressions;

namespace hdungx99.Core.EF.IRepository
{
    public interface IGenericRepository<TEntity, TModel> where TEntity : BaseEntity, new() where TModel : BaseModel, new()
    {
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(Guid Id);
        Task Insert(TModel model);
        Task Update(TModel model);
        Task Delete(Guid Id);
        Task InsertList(List<TModel> models);
        Task UpdateList(List<TModel> models);
        Task DeleteList(List<Guid> Ids);
        Task Save();
        IQueryable<TModel> Find(Expression<Func<TEntity, bool>> expression);
    }
}
