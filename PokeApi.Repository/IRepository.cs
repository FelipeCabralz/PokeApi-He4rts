using PokeApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Repository
{
    public interface IRepository
    {
        List<T> GetAll<T>() where T : class;
        T GetById<T>(int id) where T : class;
        void Add<T>(T entity) where T : class;
        void Edit<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        //List<T> GetAll();
        //T GetById(int id);
        //void Add(T entity);
        //void Edit(T entity);
        //void Delete(int id);
        Task<bool> SavechangesAsync();

        //TREINADOR

        Task<Treinador[]> GetAllTreinadoresAsync();
        Task<Pokemon[]> GetAllPokemonsAsync();
    }
}
