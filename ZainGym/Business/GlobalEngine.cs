using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZainGym.Business
{
	/// <summary>
	/// This class is meant to be a singleton having various 
	/// application properties. 
	/// </summary>
	public class GlobalEngine
	{
		#region Private members

		private static GlobalEngine _globalEngine;
		
		private DataContext _dataContext;

		#endregion

		#region Protected Constructor

		protected GlobalEngine()
		{
				
		}

		#endregion

		#region Static properties

		public static GlobalEngine TheGlobalEngine
		{
			get
			{
				if (_globalEngine == null)
				{
					_globalEngine = new GlobalEngine();
					_globalEngine.Load();
				}
				return _globalEngine;
			}	
		}

		#endregion

		#region Loading Global Engine
		public void Load()
		{
			//Loading Datacontext
			string connectionString = ConfigurationManager.ConnectionStrings["ZainDBContext"].ConnectionString;
			_dataContext = new DataContext(connectionString);
		}
		#endregion

		#region public properties

		public DataContext DataContext
		{
			get { return _dataContext; }
		}
		#endregion
	}
}
