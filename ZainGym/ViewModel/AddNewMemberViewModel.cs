using System;
using System.Configuration;
using System.Data.Linq;
using System.Security.AccessControl;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ZainGym.Business;
using ZainGym.DataAccess;
using ZainGym.Model;
using WebCam_Capture;

namespace ZainGym.ViewModel
{
	public class AddNewMemberViewModel : BaseViewModel
	{
		private readonly IRepository<Person> _personRepository;
		private ICommand _addNewMemberCommand;
		private DateTime _membershipFrom;
		private DateTime _membershipExpiry;
		private string _firstName;
		private string _lastName;
		private DateTime _dateBirth;
		private string _mobileNumber;

		#region Events

		public delegate void MemberCreated(Object sender, Person newMember);

		public event MemberCreated OnMemberCreated;
		#endregion


		#region Constructors
		public AddNewMemberViewModel(IRepository<Person> personRepository)
		{
			if (personRepository == null)
				throw new ArgumentNullException("personRepository");
			_personRepository = personRepository;

			RefreshNewMember();

			#region Camera Behavior
			#endregion
		}
		#endregion

		public DateTime MembershipFrom
		{
			get
			{
				return _membershipFrom;
			}
			set
			{
				_membershipFrom = value;
				OnPropertyChanged("MembershipFrom");
			}
		}

		public DateTime MembershipExpiry
		{
			get { return _membershipExpiry; }
			set
			{
				_membershipExpiry = value;
				OnPropertyChanged("MembershipExpiry");
			}
		}

		public string FirstName
		{
			get { return _firstName; }
			set
			{
				_firstName = value;
				OnPropertyChanged("FirstName");
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set
			{
				_lastName = value;
				OnPropertyChanged("LastName");
			}
		}

		public DateTime DateBirth
		{
			get { return _dateBirth; }
			set
			{
				_dateBirth = value; 
				OnPropertyChanged("DateBirth");
			}
		}

		public string MobileNumber
		{
			get { return _mobileNumber; }
			set
			{
				_mobileNumber = value;
				OnPropertyChanged("MobileNumber");
			}
		}
		#region Events
		public ICommand AddNewMemberCommand
		{
			get
			{
				if (_addNewMemberCommand == null)
				{
					_addNewMemberCommand = new RelayCommand(ExecuteAddNewMember, CanExecuteAddNewMember);
				}
				return _addNewMemberCommand;
			}
		}
		#endregion

		#region Private funtions

		private bool CanExecuteAddNewMember(object obj)
		{
			return true;
		}

		private void ExecuteAddNewMember(object obj)
		{
			Person memberToAdd = _personRepository.CreateInstance();
			memberToAdd.FirstName = FirstName;
			memberToAdd.LastName = LastName;
			memberToAdd.MobileNumber = MobileNumber;
			memberToAdd.DateOfBirth = DateBirth;
			memberToAdd.Memberships[0].MemberFrom = MembershipFrom;
			memberToAdd.Memberships[0].MemberExpiry = MembershipExpiry;
			memberToAdd.DisplayPic = ImageHelper.GetBinaryFromImageSource(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");
			if (memberToAdd.IsValid())
			{
				_personRepository.SaveAll();
				if (OnMemberCreated != null)
					OnMemberCreated(this, memberToAdd);
				RefreshNewMember();
			}
		}

		private void RefreshNewMember()
		{
			FirstName = LastName = MobileNumber = string.Empty;
			DateBirth = MembershipFrom = DateTime.UtcNow;
			MembershipExpiry = DateTime.UtcNow.AddMonths(1); // Default 1 month expiry. 
		}

		#endregion

	}
}
