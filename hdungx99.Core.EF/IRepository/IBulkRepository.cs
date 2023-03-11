using hdungx99.Core.EF.Entity;
using hdungx99.Core.EF.Models;
using hdungx99.Core.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
