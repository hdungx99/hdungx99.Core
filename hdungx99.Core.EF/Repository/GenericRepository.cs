using AutoMapper;
using hdungx99.Core.EF.Context;
using hdungx99.Core.EF.Entity;
using hdungx99.Core.EF.IRepository;
using hdungx99.Core.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hdungx99.Core.EF.Repository
{
    public abstract class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity, TModel> where TEntity : BaseEntity, new() where TModel : BaseModel, new()
    {
        private readonly hdungx99Context _context;
        private readonly DbSet<TEntity> _entity;
        private IMapper _mapper;
        protected GenericRepository(hdungx99Context context, DbSet<TEntity> entity, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _entity = entity;
        }

        public async Task Delete(Guid Id)
        {
            var entity = await _entity.FindAsync(Id);
            if (entity is not null)
            {
                _entity.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteList(List<Guid> Ids)
        {
            var data = _entity.Where(x=>Ids.Contains(x.Id));
            var entities=_mapper.Map<List<TEntity>>(data);
            _entity.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TModel> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            var data = _entity.Where(expression);
            return _mapper.Map<IQueryable<TModel>>(data);
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            var data = await _entity.ToListAsync();
            return _mapper.Map<IEnumerable<TModel>>(data);
        }

        public async Task<TModel> GetById(Guid Id)
        {
            var data=await _entity.FindAsync(Id);
            return _mapper.Map<TModel>(data);
        }

        public async Task Insert(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task InsertList(List<TModel> models)
        {
            var entities = _mapper.Map<List<TEntity>>(models);
            await _entity.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _entity.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateList(List<TModel> models)
        {
            var entities = _mapper.Map<List<TEntity>>(models);
            _entity.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
