using System;
using System.Collections.Generic;

namespace ZainGym.DataAccess
{
	public interface IRepository<T> where T : class
	{
		/// <summary>
		/// Returns all instances of T.
		/// </summary>
		/// <returns></returns>
		IEnumerable<T> GetAll();

		/// <summary>
		/// Returns all instance of T which matches the expression.
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		IEnumerable<T> FindAll(Func<T, bool> expression);

		/// <summary>
		/// Returns a single instance of T matching the expression. 
		/// Throws an exception if multiple instances are found.
		/// </summary>
		/// <param name="expression"></param>
		/// <returns>T</returns>
		T Single(Func<T, bool> expression);

		/// <summary>
		/// Matches the first instance of T that matches the expression. 
		/// </summary>
		/// <param name="expression"></param>
		/// <returns>T</returns>
		T First(Func<T, bool> expression);

		/// <summary>
		/// Create an instance of T
		/// </summary>
		/// <returns>T</returns>
		T CreateInstance();

		/// <summary>
		/// Persist the data context. 
		/// </summary>
		void SaveAll();

		/// <summary>
		/// Mark an item to be deleted when an entity is saved. 
		/// </summary>
		/// <param name="entity"></param>
		void MarkForDeletion(T entity);
	}
}