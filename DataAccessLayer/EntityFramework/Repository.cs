﻿using DataAccessLayer.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase , IRepository<T> where T : class
    {
        private DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = db.Set<T>();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);

            if (obj is BaseEntity)
            {
                BaseEntity o = obj as BaseEntity;
                DateTime now = DateTime.Now;
                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUserName = "emre";
            }
            return Save();
        }

        public int Update(T obj)
        {
            return Save();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
