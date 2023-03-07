using AutoMapper;
using hdungx99.Core.EF.Context;
using hdungx99.Core.EF.Entity;
using hdungx99.Core.EF.IRepository;
using hdungx99.Core.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hdungx99.Core.EF.Repository
{
    public abstract class Bulkrepository<TEntity, TModel> : IBulkRepositoryy<TEntity, TModel> where TEntity : BaseEntity, new() where TModel : BaseModel, new()
    {
        private readonly hdungx99Context _context;
        private readonly DbSet<TEntity> _entity;
        private IMapper _mapper;
        protected Bulkrepository(hdungx99Context context, DbSet<TEntity> entity, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _entity = entity;
        }

        public async Task DeleteList(List<Guid> Ids)
        {
            var data = _entity.Where(x => Ids.Contains(x.Id));
            var entities = _mapper.Map<List<TEntity>>(data);
            await _entity.BulkDeleteAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task InsertList(List<TModel> models)
        {
            var entities = _mapper.Map<List<TEntity>>(models);
            await _entity.BulkInsertAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.BulkSaveChangesAsync();
        }

        public async Task UpdateList(List<TModel> models)
        {
            var entities = _mapper.Map<List<TEntity>>(models);
            _entity.BulkUpdateAsync(entities);
            await _context.SaveChangesAsync();
        }
    }
}
