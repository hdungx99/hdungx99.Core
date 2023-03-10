using hdungx99.Core.EF.Entity;

namespace hdungx99.Core.EF.IRepository
{
    public interface ICacheRepository<TEntity, TModel> where TEntity : BaseEntity, new() where TModel : BaseEntity, new()
    {
        Task<TModel> GetById(Guid Id);
        Task Insert(TModel model);
        Task Delete(Guid Id);
        Task<IEnumerable<TModel>> GetAll(string Key);
        Task InsertList(string Key, IEnumerable<TModel> models);
    }
}
