﻿using System;
using System.Data.Entity;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();

        Microsoft.EntityFrameworkCore.DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }
            
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
          //  _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
           // _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity =c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}

