using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace ZainGym.DataAccess
{
	public class Repository<T> : IRepository<T>
		where T : class
	{
		private readonly DataContext _dataContext;

		#region Public properties
		public IEnumerable<T> GetAll()
		{
			return GetTable;
		}

		public IEnumerable<T> FindAll(Func<T, bool> expression)
		{
			return GetTable.Where(expression);
		}

		public T Single(Func<T, bool> expression)
		{
			return GetTable.Single(expression);
		}

		public T First(Func<T, bool> expression)
		{
			return GetTable.First(expression);
		}

		public virtual T CreateInstance()
		{
			T entity = Activator.CreateInstance<T>();
			GetTable.InsertOnSubmit(entity);
			return entity;
		}

		public void SaveAll()
		{
			_dataContext.SubmitChanges();
		}
		#endregion

		#region Constructor
		public Repository(DataContext dataContext)
		{
			_dataContext = dataContext;
		} 
		#endregion

		#region Private Properties
		private Table<T> GetTable
		{
			get { return _dataContext.GetTable<T>(); }
		} 
		#endregion
	}
}