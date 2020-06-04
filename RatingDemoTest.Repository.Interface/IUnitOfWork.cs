using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace RatingDemoTest.Repository.Interface
{
    public interface IUnitOfWork
    {
        #region Transaction

        /// <summary>
        /// Begin transaction
        /// </summary>
        /// <returns></returns>
        DbContextTransaction BeginTransaction();

        /// <summary>
        /// Rollback
        /// </summary>
        /// <param name="transaction"></param>
        void Rollback(DbContextTransaction transaction);

        /// <summary>
        /// Commit
        /// </summary>
        /// <param name="transaction"></param>
        void Commit(DbContextTransaction transaction);

        #endregion
        #region Get Item               

        /// <summary>
        /// Lấy biểu ghi.
        /// </summary>
        /// <returns>TDTO</returns>
        TDTO GetItem<TDTO, TEntity>() where TEntity : class, new();

        /// <summary>
        /// Lấy biểu ghi theo điều kiện trong fillter.
        /// </summary>
        /// <param name="filter">Điều kiện lọc</param>
        /// <returns>TDTO</returns>
        TDTO GetItem<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new();
        /// <summary>
        /// Lấy biểu ghi theo điều kiện trong fillter.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter">Điều kiện lọc</param>
        /// <returns></returns>
        TEntity GetItem<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new();
        /// <summary>
        /// Lấy truy vấn.
        /// </summary>
        /// <returns>IQueryable<TEntity></returns>
        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class, new();
        #endregion

        #region Get Items

        /// <summary>
        /// Lấy tất cả các biểu ghi.
        /// </summary>
        /// <returns>IList</returns>
        IList<TDTO> GetItems<TDTO, TEntity>() where TEntity : class, new();

        /// <summary>
        /// Lấy tất cả các biểu ghi theo điều kiện trong fillter.
        /// </summary>
        /// <param name="filter">Điều kiện lọc</param>
        /// <returns>IList</returns>
        IList<TDTO> GetItems<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new();
        
        #endregion
        #region Insert
        /// <summary>
        /// Thêm mới biểu ghi.
        /// </summary>
        /// <param name="dTO">Biểu ghi</param>
        /// <returns>True / False</returns>
        bool Insert<TDTO, TEntity>(TDTO dTO) where TEntity : class, new();
        /// <summary>
        /// Thêm mới biểu ghi.
        /// </summary>
        /// <param name="entity">Biểu ghi</param>
        /// <returns>TEntity</returns>
        bool Insert<TEntity>(TEntity entity) where TEntity : class, new();
        /// <summary>
        /// Thêm mới biểu ghi.
        /// </summary>
        /// <param name="dTO">Biểu ghi</param>
        /// <returns>TEntity</returns>
        TEntity InsertWidthResult<TDTO, TEntity>(TDTO dTO) where TEntity : class, new();
        #endregion
            #region Update
        /// <summary>
        /// Cập nhật biểu ghi.
        /// </summary>
        /// <param name="dTO">Biểu ghi</param>
        /// <returns>True / False</returns>
        bool Update<TDTO, TEntity>(TDTO dTO) where TEntity : class, new();

        /// <summary>
        /// Cập nhật biểu ghi.
        /// </summary>
        /// <param name="entity">Biểu ghi</param>
        /// <returns>True / False</returns>
        bool Update<TEntity>(TEntity entity) where TEntity : class, new();
        #endregion
    }
}
