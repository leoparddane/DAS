using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public class BaseDAL<T> where T : class, new()
    {

        //获取EF上下文对象
        protected DbContext DataContext
        {
            get { return EFContextFactory.GetDbContextFromContext(); }
        }


        /// <summary>
        /// 根据查询条件获取单个实体
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T GetModel(Expression<Func<T, bool>> condition)
        {
            return DataContext.Set<T>().Where(condition).FirstOrDefault();
        }
        public List<T> GetModelList()
        {
            return GetList();
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> condition)
        {
            return DataContext.Set<T>().AsNoTracking().Where(condition);
        }
        public List<T> GetList()
        {
            return (List<T>)DataContext.Set<T>().ToList();
        }
        public List<T> GetList(Expression<Func<T, bool>> condition)
        {
            return (List<T>)DataContext.Set<T>().Where(condition).ToList();
        }
        public virtual T GetModelById(params object[] keyValues)
        {
            return DataContext.Set<T>().Find(keyValues);
        }

        #region 新增
        public void Add(T model)
        {
            DataContext.Set<T>().Add(model);
            SaveChanges();
        }

        public bool Exist(Expression<Func<T, bool>> condition)
        {
            bool result = false;
            if (DataContext.Set<T>().Count(condition) == 1)
                result = true;
            return result;
        }
        #endregion

        #region 编辑
        public void Edit(T model, string[] propertyName)
        {
            if (model == null)
            {
                throw new Exception("model必须为实体的对象");
            }
            if (propertyName == null || propertyName.Any() == false)
            {
                throw new Exception("必须至少指定一个要修改的属性");
            }

            //将model追加到EF容器
            var entry = DataContext.Entry(model);

            //entry.State = EntityState.Unchanged;

            foreach (var item in propertyName)
            {
                //entry.Property(item)=model.
                entry.Property(item).IsModified = true; 
            }
            SaveChanges();
        }
        #endregion

        #region 物理删除
        //EntityState.Unchanged
        public void Delete(T model, bool isAddedEFContext)
        {
            if (isAddedEFContext == false)
            {
                DataContext.Set<T>().Attach(model);
            }
            //修改状态为deleted
            DataContext.Set<T>().Remove(model);
            SaveChanges();
        }
        #endregion

        #region 统一执行保存
        public int SaveChanges()
        {
            return DataContext.SaveChanges();
        }
        #endregion

        public int GetRecordCount()
        {
            return DataContext.Set<T>().Count();
        }
        public int GetRecordCount(Expression<Func<T, bool>> condition)
        {
            return DataContext.Set<T>().Count(condition);
        }
        #region 执行SQL语句
        /// <summary>  
        /// 执行带参数sql语句返回数据列表  
        /// </summary>  
        /// <typeparam name="T">泛型</typeparam>  
        /// <param name="sql">sql语句</param>  
        /// <param name="args">参数</param>  
        /// <returns>数据列表</returns>  
        public List<T> SqlQuery<T>(string sql, DbParameter[] args)
        {
            if (string.IsNullOrEmpty(sql))
                return new List<T>();
            try
            {
                using (JingMeiEntities db = new JingMeiEntities())
                {
                    return db.Database.SqlQuery<T>(sql, args).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
        /// <summary>  
        /// 执行不带参数sql语句返回数据列表  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="sql"></param>  
        /// <returns></returns>  
        public List<T> SqlQuery<T>(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                return new List<T>();
            try
            {
                using (JingMeiEntities db = new JingMeiEntities())
                {
                    return db.Database.SqlQuery<T>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
        /// <summary>  
        /// 执行带参数sql语句返回受影响行数  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <param name="args"></param>  
        /// <returns></returns>  
        public int ExecuteSqlCommand(string sql, DbParameter[] args)
        {
            if (string.IsNullOrEmpty(sql))
                return 0;
            try
            {
                using (JingMeiEntities db = new JingMeiEntities())
                {
                    return db.Database.ExecuteSqlCommand(sql, args);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>  
        /// 执行sql语句返回收影响行数  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <returns></returns>  
        public int ExecuteSqlCommand(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                return 0;
            try
            {
                using (JingMeiEntities db = new JingMeiEntities())
                {
                    return db.Database.ExecuteSqlCommand(sql);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
