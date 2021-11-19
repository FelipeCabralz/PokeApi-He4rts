using PokeApi.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeApi.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(object id);
        Task<bool> SavechangesAsync();
    }
}
