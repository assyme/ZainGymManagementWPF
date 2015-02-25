using System;
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
		private Person _newMember;
		private Membership _newMembership; 
		private ICommand _addNewMemberCommand;
		
		#region Events

		public delegate void MemberCreated(Object sender, Person newMember);

		public event MemberCreated OnMemberCreated;
		#endregion

		public AddNewMemberViewModel(IRepository<Person> personRepository)
		{
			if (personRepository == null)
				throw new ArgumentNullException("personRepository");
			_personRepository = personRepository;

			RefreshNewMember();

			#region Camera Behavior
			#endregion
		}

		
		public DateTime MembershipFrom
		{
			get
			{
				return _newMembership.MemberFrom;
			}
			set
			{
				_newMembership.MemberFrom = value;
				OnPropertyChanged("MembershipFrom");
			}
		}

		public DateTime MembershipTo
		{
			get { return _newMembership.MemberExpiry; }
			set
			{
				_newMembership.MemberExpiry = value;
				OnPropertyChanged("MembershipTo");
			}
		}

		public Person NewMember
		{
			get { return _newMember; }
			set
			{
				_newMember = value;
				OnPropertyChanged("NewMember");
			}
		}

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

		#region Private funtions

		private bool CanExecuteAddNewMember(object obj)
		{
			return true;
		}

		private void ExecuteAddNewMember(object obj)
		{
			if (NewMember.IsValid())
			{
				Person memberToAdd = _personRepository.CreateInstance();
				memberToAdd.FirstName = NewMember.FirstName;
				memberToAdd.LastName = NewMember.LastName;
				memberToAdd.MobileNumber = NewMember.MobileNumber;
				memberToAdd.DateOfBirth = NewMember.DateOfBirth;
				memberToAdd.Memberships = NewMember.Memberships;

				#region Save Image

				memberToAdd.DisplayPic = ImageHelper.GetBinaryFromImageSource(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");
				
				#endregion

				_personRepository.SaveAll();
				if (OnMemberCreated != null)
					OnMemberCreated(this, NewMember);

				RefreshNewMember();
			}
		}

		private void RefreshNewMember()
		{
			NewMember = new Person();
			_newMembership = new Membership {MemberExpiry = DateTime.UtcNow.AddMonths(1), MemberFrom = DateTime.UtcNow,Person = NewMember};
			NewMember.Memberships.Add(_newMembership);
		}

		#endregion

	}
}
