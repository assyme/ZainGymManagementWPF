using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

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

		private EntitySet<Membership> _memberships;
		private Binary _displayPic;

		#endregion

		#region Constructors

		public Person()
		{
			_memberships = new EntitySet<Membership>();
			_dateOfBirth = DateTime.UtcNow;
		}
		#endregion


		#region Public Properties

		[Column(Name = "Id",IsPrimaryKey = true,IsDbGenerated = true)]
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

		[Association(Storage = "_memberships",ThisKey = "Id",OtherKey = "PersonId")]
		public EntitySet<Membership> Memberships
		{
			get { return _memberships;}
			set
			{
				foreach (Membership membership in value)
				{
					_memberships.Add(membership);
				}
			}
		}
		
		[Column(Name = "DisplayPic")]
		public Binary DisplayPic
		{
			get
			{
				return _displayPic;
			}
			set { _displayPic = value; }
		}

		public string FullName
		{
			get { return FirstName + " " +LastName; }
		}

		public string ExpiresOn
		{
			get
			{
				DateTime latestDate = DateTime.UtcNow;
				foreach (Membership membership in Memberships)
				{
					if (membership.MemberExpiry > latestDate)
					{
						latestDate = membership.MemberExpiry;
					}
				}
				if (latestDate > DateTime.UtcNow)
				{
					return latestDate.ToString("dd/MM/yyyy");
				}
				else
				{
					return "Expired";
				}
			}
		}
		#endregion

		#region Data Validations
		public override bool IsValid()
		{
			ValidationMessages.Clear();
			
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
			
			if (!String.IsNullOrEmpty(MobileNumber) && (MobileNumber.Length != 10 || !Regex.IsMatch(MobileNumber, "[0-9]")))
			{
				ValidationMessages.Add("Mobile number should be of 10 digits.");
			}
			var validMemberships = (from membership in Memberships 
									let currentTime = DateTime.UtcNow 
									where currentTime >= membership.MemberFrom && currentTime <= membership.MemberExpiry 
									select membership).Count();
			
			if (validMemberships > 1)
			{
				ValidationMessages.Add("Too many valid memberships found for the user.");
			}

			return ValidationMessages.Count == 0;
		}
		#endregion

	}
}