﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TvShowWebApp.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllIncluding(params string[] includeProperties);
        IEnumerable<TEntity> GetAllSorted<TType>(Expression<Func<TEntity, TType>> sortCondition, bool sortDesc);
        TEntity GetById(object id);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(object id);
        bool Delete(TEntity entityToDelete);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> condition);
        bool Any(Expression<Func<TEntity, bool>> condition);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entityList);

    }
}
