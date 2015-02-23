using System;
using System.Windows.Controls;
using System.Windows.Input;
using ZainGym.Business;
using ZainGym.DataAccess;
using ZainGym.Model;

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
				_personRepository.SaveAll();

				if (OnMemberCreated != null)
					OnMemberCreated(this, NewMember);

				RefreshNewMember();
			}
		}

		private void RefreshNewMember()
		{
			NewMember = _personRepository.CreateInstance();
			_newMembership = NewMember.Memberships[0]; //maybe get it from repository?
		}

		#endregion

	}
}
