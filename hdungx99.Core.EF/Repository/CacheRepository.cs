using hdungx99.Core.EF.Entity;
using hdungx99.Core.EF.IRepository;
using hdungx99.Core.EF.Models;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace hdungx99.Core.EF.Repository
{
    public class CacheRepository<TEntity, TModel> : ICacheRepository<TEntity, TModel> where TEntity : BaseEntity, new() where TModel : BaseModel, new()
    {
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;
        public CacheRepository(IDistributedCache cache, IMapper mapper)
        {
            _cache = cache;
            _mapper = mapper;

        }
        public async Task Delete(Guid Id)
        {
            await _cache.RemoveAsync(Id.ToString());
        }

        public async Task<IEnumerable<TModel>> GetAll(string Key)
        {
            var data = await _cache.GetAsync(Key);
            var result = JsonSerializer.Deserialize<IEnumerable<TEntity>>(data, GetJsonSerializerOptions());
            return _mapper.Map<IEnumerable<TModel>>(result);
        }

        public async Task<TModel> GetById(Guid Id)
        {
            var data = await _cache.GetAsync(Id.ToString());
            var result = JsonSerializer.Deserialize<TEntity>(data, GetJsonSerializerOptions());
            return _mapper.Map<TModel>(result);
        }

        public async Task Insert(TModel model)
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(10)).SetSlidingExpiration(TimeSpan.FromMinutes(5));
            var entity=_mapper.Map<TEntity>(model);
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(entity, GetJsonSerializerOptions()));
            await _cache.SetAsync(model.Id.ToString(), bytes, options);
        }
        public async Task InsertList(string Key,IEnumerable<TModel> models)
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(10)).SetSlidingExpiration(TimeSpan.FromMinutes(5));
            var entity = _mapper.Map<IEnumerable<TEntity>>(models);
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(entity, GetJsonSerializerOptions()));
            await _cache.SetAsync(Key, bytes, options);
        }
        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions()
            {
                PropertyNamingPolicy = null,
                WriteIndented = true,
                AllowTrailingCommas = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
        }

    }
}
