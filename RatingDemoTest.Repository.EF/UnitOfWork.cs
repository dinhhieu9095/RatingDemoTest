using RatingDemoTest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using RatingDemoTest.Log;
using AutoMapper;
using System.Data;

namespace RatingDemoTest.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        protected DbContext Context { get; set; }

        #endregion
        #region Constructors
        public UnitOfWork(DbContext context)
        {
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
            this.Context = context;
        }

        public UnitOfWork()
        {
        }

        #endregion

        #region Methods
        #region Transaction
        public DbContextTransaction BeginTransaction()
        {
            return this.Context.Database.BeginTransaction();
        }

        public void Rollback(DbContextTransaction transaction)
        {
            transaction.Rollback();
        }

        public void Commit(DbContextTransaction transaction)
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        #endregion
        #region Get Item
        public TDTO GetItem<TDTO, TEntity>() where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                return Mapper.Map<TDTO>(dbSet.FirstOrDefault<TEntity>());
            }
            catch (Exception ex)
            {
                Logging.LogError("RatingDemoTest.Repository.EF-UnitOfWork-GetItem()", ex);
                return default(TDTO);
            }
        }

        public TDTO GetItem<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                queryDb = queryDb.Where(filter);
                return Mapper.Map<TDTO>(queryDb.FirstOrDefault());
            }
            catch (Exception ex)
            {
                Logging.LogError("RatingDemoTest.Repository.EF-UnitOfWork-GetItem(Expression<Func<TEntity, bool>> filter)", ex);
                return default(TDTO);
            }
        }
        public TEntity GetItem<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                queryDb = queryDb.Where(filter);
                TEntity entity = queryDb.FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                Logging.LogError("RatingDemoTest.Repository.EF-UnitOfWork-GetItem(Expression<Func<TEntity, bool>> filter)", ex);
                return default(TEntity);
            }
        }

        public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                return dbSet;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Get Items
        public IList<TDTO> GetItems<TDTO, TEntity>() where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                return Mapper.Map<IList<TDTO>>(dbSet.ToList<TEntity>());
            }
            catch (Exception ex)
            {
                Logging.LogError("RatingDemoTest.Repository.EF-UnitOfWork-GetItems()", ex);
                return default(IList<TDTO>);
            }
        }
        public IList<TDTO> GetItems<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                queryDb = queryDb.Where(filter);
                return Mapper.Map<IList<TDTO>>(queryDb.ToList());
            }
            catch (Exception ex)
            {
                Logging.LogError("RatingDemoTest.Repository.EF-UnitOfWork-GetItems(Expression<Func<TEntity, bool>> filter)", ex);
                return default(IList<TDTO>);
            }
        }
        #endregion
        #region Update
        public bool Update<TDTO, TEntity>(TDTO dTO) where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(dTO);
                dbSet.Attach(entity);
                this.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("RatingDemoTest.Repository.EF-UnitOfWork-Update(TDTO dTO)", ex);
                return false;
            }
        }
        public bool Update<TEntity>(TEntity entity) where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                dbSet.Attach(entity);
                this.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("RatingDemoTest.Repository.EF-UnitOfWork-Update(TEntity entity)", ex);
                return false;
            }
        }
        #endregion
        #region Insert
        public bool Insert<TDTO, TEntity>(TDTO dTO) where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(dTO);
                dbSet.Add(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)// (DbEntityValidationException dbex)
            {
                Logging.LogError("RatingDemoTest.Repository.EF-UnitOfWork-Insert(TDTO dTO)", ex);
                return false;
            }
        }
        public bool Insert<TEntity>(TEntity entity) where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = Context.Set<TEntity>();
                dbSet.Add(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)// (DbEntityValidationException dbex)
            {
                Logging.LogError("LacViet.HPS.SureDMS.Repository.EF-UnitOfWork-Insert(TEntity entity)", ex);
                return false;
            }
        }
        #endregion
        #endregion
    }
}
