using System;
using System.Data.Linq.Mapping;
using System.Windows.Markup;

namespace ZainGym.Model
{
	[Table(Name = "Person")]
	public class Person : BaseModel
	{
		#region Private Members
		private int _id;
		private string _firstName;
		private string _lastName;
		private DateTime _dateOfBirth;
		private string _mobileNumber = string.Empty;
		#endregion


		#region Public Properties

		[Column(Name = "Id",IsPrimaryKey = true)]
		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		[Column]
		public string FirstName
		{
			get { return _firstName;}
			set { _firstName = value; }
		}

		[Column]
		public string LastName
		{
			get{return _lastName;}
			set { _lastName = value; }
		}

		[Column]
		public DateTime DateOfBirth
		{
			get { return _dateOfBirth; }
			set { _dateOfBirth = value; }
		}

		[Column(Name="Mobile")]
		public string MobileNumber
		{
			get { return _mobileNumber; }
			set { _mobileNumber = value; }
		}
		#endregion

		#region Data Validations
		public override bool IsValid()
		{
			if (String.IsNullOrEmpty(FirstName))
			{
				ValidationMessages.Add("First Name should be provided.");
			}
			else
			{
				if (FirstName.Length < 2)
				{
					ValidationMessages.Add("First Name should be more then 1 characters.");
				}				
			}

			if (String.IsNullOrEmpty(LastName))
			{
				ValidationMessages.Add("Last Name should be provided.");
			}
			else
			{
				if (LastName.Length < 2)
				{
					ValidationMessages.Add("Last Name should be more then 1 characters");
				}
			}

			if (MobileNumber.Length != 10)
			{
				ValidationMessages.Add("Mobile number should be of 10 digits.");
			}

			return ValidationMessages.Count == 0;
		}
		#endregion

		
	}
}