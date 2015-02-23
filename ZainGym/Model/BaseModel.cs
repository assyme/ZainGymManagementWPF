using System.Collections.Generic;

namespace ZainGym.Model
{
	public abstract class BaseModel
	{
		#region Private Members
		private List<string> _validationMessages;
		#endregion

		#region Public Members
		public List<string> ValidationMessages
		{
			get { return _validationMessages; }
			protected set { _validationMessages = value; }
		} 
		#endregion

		#region Virtuals
		public abstract bool IsValid();
		#endregion

		#region Constructor
		protected BaseModel()
		{
			_validationMessages = new List<string>();
		}
		#endregion
	}
}
