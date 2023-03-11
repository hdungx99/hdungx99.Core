using hdungx99.Core.EF.Entity;
using hdungx99.Core.EF.Models;

namespace hdungx99.Core.EF.IRepository
{
    public interface IBulkRepositoryy<TEntity, TModel> where TEntity : BaseEntity, new() where TModel : BaseModel, new()
    {
        Task InsertList(List<TModel> models);
        Task UpdateList(List<TModel> models);
        Task DeleteList(List<Guid> Ids);
        Task Save();
    }
}
