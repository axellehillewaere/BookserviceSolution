using Bookservice.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    //verduidelijken welke types erin zullen komen
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> GetById(int id);
        IQueryable<T> GetAll(); //pas uitgevoerd op moment dat je data nodg hebt of ophaalt
        Task<IEnumerable<T>> ListAll();
        Task<T> Add(T entity);
        Task<T> Delete(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);

        IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate);

    }
}
